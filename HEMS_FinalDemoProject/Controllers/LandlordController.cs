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
    public class LandlordController : ApiController
    {
        [HttpGet]
        [Route("api/LandlordDetails")]
        public HttpResponseMessage LandlordDetails()
        {
            var data = LandlordService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/LandlordCreate")]
        public HttpResponseMessage InsertLandlordDetail(LandlordDTO LandlordDTO)
        {
            LandlordService.Create(LandlordDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("api/LandlordDetails/{id}")]
        public HttpResponseMessage GetByIDLandlord(int id)
        {
            var data = LandlordService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/LandlordDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDLandlord(int id)
        {
            var data = LandlordService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/LandlordDetails/update")]
        public HttpResponseMessage UpdateLandlordDetail(LandlordDTO LandlordDTO)
        {
            LandlordService.Update(LandlordDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
