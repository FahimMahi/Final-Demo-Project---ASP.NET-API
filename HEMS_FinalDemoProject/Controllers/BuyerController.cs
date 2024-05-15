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
    public class BuyerController : ApiController
    {
        [HttpGet]
        [Route("api/BuyerDetails")]
        public HttpResponseMessage BuyerDetails()
        {
            var data = BuyerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/BuyerCreate")]
        public HttpResponseMessage InsertBuyerDetail(BuyerDTO buyerDTO)
        {
            BuyerService.Create(buyerDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("api/BuyerDetails/{id}")]
        public HttpResponseMessage GetByIDBuyer(int id)
        {
            var data = BuyerService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/BuyerDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDBuyer(int id)
        {
            var data = BuyerService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/BuyerDetails/update")]
        public HttpResponseMessage UpdateBuyerDetail(BuyerDTO buyerDTO)
        {
            BuyerService.Update(buyerDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //feature API(tahmeed)..................................................
        [HttpGet]
        [Route("api/buyer/likelist/{id}")]
        public HttpResponseMessage AllBiddings(string id)
        {
            var data = BuyerService.LikedProperty(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/property/liked")]
        public HttpResponseMessage UpdateBuyerDetail(LikedPropertyDTO obj)
        {
            BuyerService.PropertyLiked(obj);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
