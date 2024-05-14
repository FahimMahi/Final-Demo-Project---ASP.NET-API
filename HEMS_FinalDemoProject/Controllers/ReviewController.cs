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
    public class ReviewController : ApiController
    {
        [HttpGet]
        [Route("api/ReviewDetails")]
        public HttpResponseMessage ReviewDetails()
        {
            try
            {
                var data = ReviewService.Get();
                var successMessage = "Review details retrieved successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while retrieving Review details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/ReviewCreate")]
        public HttpResponseMessage InsertReviewDetail(ReviewDTO ReviewDTO)
        {
            try
            {
                ReviewService.Create(ReviewDTO);
                var successMessage = "Review created successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while creating the Review. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpGet]
        [Route("api/ReviewDetails/{id}")]
        public HttpResponseMessage GetByIDReview(int id)
        {
            try
            {
                var data = ReviewService.Get(id);

                if (data != null)
                {
                    var successMessage = $"Review details with ID {id} retrieved successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
                }
                else
                {
                    var notFoundMessage = $"Review with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while retrieving Review details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/ReviewDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDReview(int id)
        {
            try
            {
                var deleted = ReviewService.Delete(id);

                if (deleted)
                {
                    var successMessage = $"Review with ID {id} deleted successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
                }
                else
                {
                    var notFoundMessage = $"Review with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while deleting the Review with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/ReviewDetails/update")]
        public HttpResponseMessage UpdateReviewDetail(ReviewDTO ReviewDTO)
        {
            try
            {
                ReviewService.Update(ReviewDTO);
                var successMessage = $"Review with ID {ReviewDTO.id} updated successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while updating the Review with ID {ReviewDTO.id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
    }
}
