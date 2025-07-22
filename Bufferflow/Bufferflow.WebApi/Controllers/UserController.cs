using Bufferflow.BLL;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bufferflow.WebApi.Controllers
{
    public class UserController : ApiController
    {
        UserBLL userBLL = new UserBLL();
        /// <summary>
        /// Request to add user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("api/User/Add")]
        [HttpPost]
        public IHttpActionResult Add(UserDTO userDTO)
        {
            if(!userBLL.AddUser(userDTO))
                return Content(HttpStatusCode.BadRequest, "User Not added");
            else return Content(HttpStatusCode.OK, "Added");
        }
    
        /// <summary>
        /// Api service to get User data 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("User/Get/{id}")]
        [HttpGet]
        public IHttpActionResult GetUser(string id)
        {
            return Ok(userBLL.GetUserById(id));
        }
        /// <summary>
        /// Api service to check validate the login
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [Route("api/Users/Login")]
        [HttpPost]
        public HttpResponseMessage IsValidUser(LoginDTO loginDTO)
        {
            UserDTO userdto = userBLL.IsValidUser(loginDTO);
            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK,userdto);
            return response;
        }
    }
}
