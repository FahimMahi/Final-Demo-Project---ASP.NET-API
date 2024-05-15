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
            try
            {
                var data = BuyerService.Get();
                var successMessage = "Buyer details retrieved successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while retrieving buyer details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/BuyerCreate")]
        public HttpResponseMessage InsertBuyerDetail(BuyerDTO buyerDTO)
        {
            try
            {
                BuyerService.Create(buyerDTO);
                var successMessage = "Buyer details created successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while creating buyer details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpGet]
        [Route("api/BuyerDetails/{id}")]
        public HttpResponseMessage GetByIDBuyer(int id)
        {
            try
            {
                var data = BuyerService.Get(id);

                if (data != null)
                {
                    var message = $"Buyer {id} data found";
                    var response = Request.CreateResponse(HttpStatusCode.OK, new { message, data });
                    return response;
                }
                else
                {
                    var errorMessage = $"Buyer {id} data not found";
                    var errorResponse = Request.CreateResponse(HttpStatusCode.NotFound, new { errorMessage });
                    return errorResponse;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/BuyerDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDBuyer(int id)
        {
            try
            {
                var data = BuyerService.Delete(id);

                if (data)
                {
                    var successMessage = $"Buyer details with ID {id} deleted successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
                }
                else
                {
                    var notFoundMessage = $"Buyer details with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while deleting buyer details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }

        [HttpPost]
        [Route("api/BuyerDetails/update")]
        public HttpResponseMessage UpdateBuyerDetail(BuyerDTO buyerDTO)
        {
            try
            {   
                BuyerService.Update(buyerDTO);
                var successMessage = $"Buyer details with ID {buyerDTO.id} updated successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while updating buyer details with ID {buyerDTO.id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
    }
}
