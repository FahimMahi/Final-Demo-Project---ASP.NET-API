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
    public class ComplainController : ApiController
    {
        [HttpGet]
        [Route("api/complain/all")]
        public HttpResponseMessage Complains()
        {
            var data = ComplainService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/complain/create")]
        public HttpResponseMessage Create(ComplainDTO complain)
        {
            ComplainService.Create(complain);
            return Request.CreateResponse(HttpStatusCode.OK, "Agreement Created Successfully");
        }

        [HttpGet]
        [Route("api/complain/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            ComplainService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        
         [HttpPut]
        [Route("api/complain/update/{id}")]
        public HttpResponseMessage Update(int id, ComplainDTO complain)
        {
            ComplainService.Update(id, complain);
            return Request.CreateResponse(HttpStatusCode.OK, "Complain Updated Successfully");
        }
    }
}
