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
    public class SupportTicketController : ApiController
    {

        [HttpGet]
        [Route("api/SupportTicketDetails")]
        public HttpResponseMessage SupportTicketDetails()
        {
            try
            {
                var data = SupportTicketService.Get();
                var successMessage = "Support ticket details retrieved successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while retrieving support ticket details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/SupportTicketCreate")]
        public HttpResponseMessage InsertSupportTicketDetail(SupportTicketDTO SupportTicketDTO)
        {
            try
            {
                SupportTicketService.Create(SupportTicketDTO);
                var successMessage = "Support ticket created successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            { 
                var errorMessage = "An unexpected error occurred while creating the support ticket. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpGet]
        [Route("api/SupportTicketDetails/{id}")]
        public HttpResponseMessage GetByIDSupportTicket(int id)
        {
            try
            {
                var data = SupportTicketService.Get(id);

                if (data != null)
                {
                    var successMessage = $"Support ticket details with ID {id} retrieved successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
                }
                else
                {
                    var notFoundMessage = $"Support ticket with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while retrieving support ticket details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/SupportTicketDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDSupportTicket(int id)
        {
            try
            {
                var deleted = SupportTicketService.Delete(id);

                if (deleted)
                {
                    var successMessage = $"Support ticket with ID {id} deleted successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
                }
                else
                {
                    var notFoundMessage = $"Support ticket with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while deleting the support ticket with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/SupportTicketDetails/update")]
        public HttpResponseMessage UpdateSupportTicketDetail(SupportTicketDTO SupportTicketDTO)
        {
            try
            {
                SupportTicketService.Update(SupportTicketDTO);
                var successMessage = $"Support ticket with ID {SupportTicketDTO.id} updated successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while updating the support ticket with ID {SupportTicketDTO.id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
    }
}
