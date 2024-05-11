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
    public class PropertyController : ApiController
    {
        [HttpGet]
        [Route("api/properties/all")]
        public HttpResponseMessage Properties()
        {
            var data = PropertyService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/properties/{param}")]
        public HttpResponseMessage GetProperty(string param)
        {
            if (int.TryParse(param, out int id))
            {
                var data = PropertyService.PropertyWithBidding(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                var data = PropertyService.Get(param);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }

        [HttpPost]
        [Route("api/properties/create")]
        public HttpResponseMessage Properties(PropertyDTO property)
        {
            PropertyService.Create(property);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("api/properties/update")]
        public HttpResponseMessage UpdateProperties(PropertyDTO property)
        {
            PropertyService.Update(property);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
