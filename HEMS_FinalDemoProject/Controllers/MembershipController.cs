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
    public class MembershipController : ApiController
    {
        [HttpGet]
        [Route("api/MembershipDetails")]
        public HttpResponseMessage MembershipDetails()
        {
            try
            {
                var data = MembershipService.Get();
                var successMessage = "Membership details retrieved successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while retrieving Membership details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/MembershipCreate")]
        public HttpResponseMessage InsertMembershipDetail(MembershipDTO MembershipDTO)
        {
            try
            {
                MembershipService.Create(MembershipDTO);
                var successMessage = "Membership created successfully";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while creating the Membership. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpGet]
        [Route("api/MembershipDetails/{id}")]
        public HttpResponseMessage GetByIDMembership(int id)
        {
            try
            {
                var data = MembershipService.Get(id);

                if (data != null)
                {
                    var successMessage = $"Membership details with ID {id} retrieved successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
                }
                else
                {
                    var notFoundMessage = $"Membership with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while retrieving Membership details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/MembershipDetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDMembership(int id)
        {
            try
            {
                var deleted = MembershipService.Delete(id);

                if (deleted)
                {
                    var successMessage = $"Membership with ID {id} deleted successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
                }
                else
                {
                    var notFoundMessage = $"Membership with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while deleting the Membership with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
        [HttpPost]
        [Route("api/MembershipDetails/update")]
        public HttpResponseMessage UpdateMembershipDetail(MembershipDTO MembershipDTO)
        {
            try
            {
                MembershipService.Update(MembershipDTO);
                var successMessage = $"Membership with ID {MembershipDTO.id} updated successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while updating the Membership with ID {MembershipDTO.id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
    }
}
