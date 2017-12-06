using BeeCard.API.Models;
using BeeCard.Application.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeeCard.API.Controllers
{
    public class UserController : BaseController
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/users/")]
        public HttpResponseMessage GetAll([FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var users = _userService.GetAll(_page, _size);

                CollectionModel<ResponseUserModel> response = new CollectionModel<ResponseUserModel>
                {
                    Total = users.Item1,
                    Items = users.Item2.Select(c => new ResponseUserModel(c)).ToList(),
                    Page = _page,
                    Size = _size
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/users/")]
        public HttpResponseMessage AddUser(RequestUserModel model)
        {
            try
            {
                _userService.RegisterUser(model.Email, model.Firstname, model.Lastname, model.Password, model.Birthdate, model.PhoneNumber, model.AvatarFileName, model.AvatarContent);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/users/{userId}/groups")]
        public HttpResponseMessage GetAllUserGroups(Guid userId, [FromUri] string page = "1", [FromUri] string size = "20")
        {
            try
            {
                int _page = 0;
                int _size = 0;

                int.TryParse(page, out _page);
                int.TryParse(size, out _size);

                _page = _page < 1 ? 1 : _page;
                _size = _size > 50 ? 50 : _size;

                var userGroups = _userService.GetAllUserGroups(userId, _page, _size);

                CollectionModel<ResponseUserGroupModel> response = new CollectionModel<ResponseUserGroupModel>
                {
                    Total = userGroups.Item1,
                    Items = userGroups.Item2.Select(c => new ResponseUserGroupModel(c)).ToList(),
                    Page = _page,
                    Size = _size
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "NotFound")
                    return SendResponse(HttpStatusCode.NotFound);
                else
                    return SendResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return SendResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
