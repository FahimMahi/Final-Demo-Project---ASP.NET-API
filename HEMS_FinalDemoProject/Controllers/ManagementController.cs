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
    public class ManagementController : ApiController
    {

        [HttpGet]
        [Route("api/ManagementDetails")]
        public HttpResponseMessage ManagementDetails()
        {
            var data = ManagementService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/ManagementCreate")]
        public HttpResponseMessage InsertManagementDetail(ManagementDTO ManagementDTO)
        {
            ManagementService.Create(ManagementDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("api/ManagementDetails/{id}")]
        public HttpResponseMessage GetByIDManagement(int id)
        {
            var data = ManagementService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/ManagementDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDManagement(int id)
        {
            var data = ManagementService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/ManagementDetails/update")]
        public HttpResponseMessage UpdateManagementDetail(ManagementDTO ManagementDTO)
        {
            ManagementService.Update(ManagementDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
