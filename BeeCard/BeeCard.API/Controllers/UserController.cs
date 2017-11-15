using BeeCard.API.Models;
using BeeCard.Application.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeeCard.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/users/{userId}")]
        public HttpResponseMessage Get(Guid userId)
        {
            try
            {
                var user = _userService.GetUser(userId);

                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseUserModel(user));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);                
            }
        }

        [HttpGet]
        [Route("api/users/")]
        public HttpResponseMessage GetAll([FromUri] string page = null, [FromUri] string size = null)
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                return Request.CreateResponse(HttpStatusCode.OK, _userService.GetAll(_page, _size).Select(u => new ResponseUserModel(u)).ToList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/users/")]
        public HttpResponseMessage AddUser(RequestUserModel model)
        {
            try
            {
                _userService.RegisterUser(model.Email, model.Firstname, model.Lastname, model.Password, model.Birthdate, model.PhoneNumber, model.AvatarFileName, model.AvatarContent);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/users/{userId}")]
        public HttpResponseMessage UpdateUser(Guid userId, RequestUserModel model)
        {
            try
            {
                _userService.UpdateUser(userId, model.Email, model.Firstname, model.Lastname, model.Birthdate, model.PhoneNumber, model.AvatarFileName, model.AvatarContent, model.Status);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/users/{userId}")]
        public HttpResponseMessage RemoveUser(Guid userId)
        {
            try
            {
                _userService.RemoveUser(userId);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/users/{userid}/groups/{userGroupId}")]
        public HttpResponseMessage GetUserGroup(Guid userId, Guid userGroupId)
        {
            try
            {
                var userGroup = _userService.GetUserGroup(userId, userGroupId);

                if (userGroup == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseUserGroupModel(userGroup));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/users/{userId}/groups")]
        public HttpResponseMessage GetAllUserGroups(Guid userId, [FromUri] string page = null, [FromUri] string size = null)
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                return Request.CreateResponse(HttpStatusCode.OK, _userService.GetAllUserGroups(userId, _page, _size).Select(u => new ResponseUserGroupModel(u)).ToList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/users/{userId}/groups")]
        public HttpResponseMessage AddUserGroup(Guid userId, RequestUserGroupModel model)
        {
            try
            {
                _userService.CreateUserGroup(userId, model.Name);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/users/{userId}/groups/{userGroupId}")]
        public HttpResponseMessage UpdateUserGroup(Guid userId, Guid userGroupId, RequestUserGroupModel model)
        {
            try
            {
                _userService.UpdateUserGroup(userId, userGroupId, model.Name, model.Status);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/users/{userId}/groups/{userGroupId}")]
        public HttpResponseMessage RemoveUserGroup(Guid userId, Guid userGroupId)
        {
            try
            {
                _userService.RemoveUserGroup(userId, userGroupId);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
