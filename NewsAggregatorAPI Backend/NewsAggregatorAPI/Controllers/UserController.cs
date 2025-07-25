using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace NewsAggregatorAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/CreateUser")]
        public HttpResponseMessage CreateUser([FromBody] UserDTO userDto)
        {
            try
            {
                if (userDto == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "User data is null." });

                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

                var createdUser = UserService.Create(userDto);

                if (createdUser == null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);

                return Request.CreateResponse(HttpStatusCode.Created, createdUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetAllUsers")]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                var users = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateUser/{uname}")]
        public HttpResponseMessage UpdateUser(string uname, [FromBody] UserDTO userDto)
        {
            try
            {
                if (userDto == null || userDto.Uname != uname)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid user data." });

                var updatedUser = UserService.Update(userDto);

                if (updatedUser == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found or update failed." });

                return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteUser/{uname}")]
        public HttpResponseMessage DeleteUser(string uname)
        {
            try
            {
                var deleted = UserService.Delete(uname);

                if (!deleted)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found." });

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}