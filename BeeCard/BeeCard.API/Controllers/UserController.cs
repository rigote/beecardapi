using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public User Get(Guid id)
        {
            try
            {
                var user = _userService.GetUser(id);

                if (user == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                else
                    return user;
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, new StringContent(JsonConvert.SerializeObject(ex))));
            }
        }

        [HttpGet]
        [Route("api/users/")]
        public IEnumerable<User> GetAll()
        {
            try
            {
                return _userService.GetAll();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, new StringContent(JsonConvert.SerializeObject(ex))));
            }
        }

        [HttpPost]
        [Route("api/users/")]
        public IHttpActionResult AddUser(User user)
        {
            try
            {
                _userService.AddUser(user);

                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent(JsonConvert.SerializeObject(ex)) });
            }
        }

        [HttpPut]
        [Route("api/users/")]
        public IHttpActionResult UpdateUser(User user)
        {
            try
            {
                _userService.UpdateUser(user);

                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent(JsonConvert.SerializeObject(ex)) });
            }
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IHttpActionResult RemoveUser(Guid id)
        {
            try
            {
                var user = _userService.GetUser(id);

                if (user != null)
                    _userService.RemoveUser(user);
                else
                    return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound });

                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent(JsonConvert.SerializeObject(ex)) });
            }
        }
    }
}
