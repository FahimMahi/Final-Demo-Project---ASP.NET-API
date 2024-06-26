﻿using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HEMS_FinalDemoProject.Controllers
{
    public class BiddingController : ApiController
    {

        [HttpPost]
        [Route("api/property/bidding/create")]
        public HttpResponseMessage Biddings(BiddingDTO bid)
        {
            BiddingService.Create(bid);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //all biddings of an individual property
        [HttpGet]
        [Route("api/bidding/all/{id}")]
        public HttpResponseMessage AllBiddings(string id)
        {
            var data = BiddingService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }



        //landlord can see the heighest bidding of a individual property

        [HttpGet]
        [Route("api/bidding/landlord/{id}")]
        public HttpResponseMessage HeighestBidding(int id)
        {
            var data = BiddingService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //if anyone want to take leave the bidding 
        [HttpGet]
        [Route("api/bidding/leave/{pid}/{bid}")]
        public HttpResponseMessage DeleteBidding(int pid, int bid)
        {
            var data = BiddingService.Delete(pid, bid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
