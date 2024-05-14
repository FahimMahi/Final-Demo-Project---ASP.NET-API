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
    public class FeedbackController : ApiController
    {


        [HttpGet]
        [Route("api/FeedbackDetails")]
        public HttpResponseMessage FeedbackDetails()
        {
            try
            {
                var data = FeedbackService.Get();
                var successMessage = "Feedback details retrieved successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while retrieving Feedback details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/FeedbackCreate")]
        public HttpResponseMessage InsertFeedbackDetail(FeedbackDTO FeedbackDTO)
        {
            try
            {
                FeedbackService.Create(FeedbackDTO);
                var successMessage = "Feedback details created successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while creating the Feedback details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpGet]
        [Route("api/FeedbackDetails/{id}")]
        public HttpResponseMessage GetByIDFeedback(int id)
        {
            try
            {
                var data = FeedbackService.Get(id);

                if (data != null)
                {
                    var successMessage = $"Feedback details with ID {id} retrieved successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
                }
                else
                {
                    var notFoundMessage = $"Feedback details with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while retrieving Feedback details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/FeedbackDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDFeedback(int id)
        {
            try
            {
                var deleted = FeedbackService.Delete(id);

                if (deleted)
                {
                    var successMessage = $"Feedback details with ID {id} deleted successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
                }
                else
                {
                    var notFoundMessage = $"Feedback details with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while deleting the Feedback details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/FeedbackDetails/update")]
        public HttpResponseMessage UpdateFeedbackDetail(FeedbackDTO FeedbackDTO)
        {
            try
            {
                FeedbackService.Update(FeedbackDTO);
                var successMessage = $"Feedback details with ID {FeedbackDTO.id} updated successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while updating buyer details with ID {FeedbackDTO.id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
    }
}
