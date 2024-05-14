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
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("api/PaymentDetails")]
        public HttpResponseMessage PaymentDetails()
        {
            try
            {
                var data = PaymentService.Get();
                var successMessage = "Payment details retrieved successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while retrieving Payment details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/PaymentCreate")]
        public HttpResponseMessage InsertPaymentDetail(PaymentDTO PaymentDTO)
        {
            try
            {
                PaymentService.Create(PaymentDTO);
                var successMessage = "Payment details created successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while creating the Payment details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpGet]
        [Route("api/PaymentDetails/{id}")]
        public HttpResponseMessage GetByIDPayment(int id)
        {
            try
            {
                var data = PaymentService.Get(id);

                if (data != null)
                {
                    var successMessage = $"Payment details with ID {id} retrieved successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
                }
                else
                {
                    var notFoundMessage = $"Payment details with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while retrieving Payment details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/PaymentDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDPayment(int id)
        {
            try
            {
                var deleted = PaymentService.Delete(id);

                if (deleted)
                {
                    var successMessage = $"Payment details with ID {id} deleted successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
                }
                else
                {
                    var notFoundMessage = $"Payment details with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while deleting the Payment details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/PaymentDetails/update")]
        public HttpResponseMessage UpdatePaymentDetail(PaymentDTO PaymentDTO)
        {
            try
            {
                PaymentService.Update(PaymentDTO);
                var successMessage = $"Payment details with ID {PaymentDTO.id} updated successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while updating buyer details with ID {PaymentDTO.id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
    }
}
