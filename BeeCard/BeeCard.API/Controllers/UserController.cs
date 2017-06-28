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
        [Route("api/users/{id}")]
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                var user = _userService.GetUser(id);

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
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _userService.GetAll().Select(u => new ResponseUserModel(u)).ToList());
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
    }
}
