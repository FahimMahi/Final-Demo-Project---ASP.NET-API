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
    
        public class AgreementController : ApiController
    {


        [HttpGet]
        [Route("api/agreement/{id:int}")]
        public HttpResponseMessage Properties(int id)
        {
            var data = AgreementService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/agreement/create")]
        public HttpResponseMessage Properties(AgreementDTO Agreement)
        {
            AgreementService.Create(Agreement);
            return Request.CreateResponse(HttpStatusCode.OK, "Agreement Created Successfully");
        }

        [HttpDelete]
        [Route("api/agreement/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            AgreementService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK,"Agreement Deleted Successfully");
        }

        [HttpPut]
        [Route("api/agreement/update/{id}")]
        public HttpResponseMessage Update(int id, AgreementDTO updatedAgreement)
        {
            AgreementService.Update(id, updatedAgreement);
            return Request.CreateResponse(HttpStatusCode.OK, "Agreement Updated Successfully");
        }

    }


}


    
