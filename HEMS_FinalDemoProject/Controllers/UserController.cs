using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HEMS_FinalDemoProject.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/userdetails")]
        public HttpResponseMessage GetUsers()
        {
            var data = UserService.Get(); 
            return Request.CreateResponse(HttpStatusCode.OK, data);
            
        }

        [HttpPost]
        [Route("api/usercreate")]
        public HttpResponseMessage InsertUserDetail(UserDTO userDTO)
        {
            UserService.Create(userDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
            
        }

        [HttpGet]
        [Route("api/userdetails/{id}")]
        public HttpResponseMessage GetByIDUser(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/userdetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDUser(int id)
        {
            var data = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/userdetails/update")]
        public HttpResponseMessage UpdateUserDetail(UserDTO userDTO)
        {
            UserService.Update(userDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
            
        }
    }
}