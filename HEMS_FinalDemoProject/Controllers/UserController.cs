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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/userdetails")]
        public HttpResponseMessage GetUsers()
        {
            try
            {
                var data = UserService.Get();
                var successMessage = "User details retrieved successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while retrieving user details. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }

        [HttpPost]
        [Route("api/usercreate")]
        public HttpResponseMessage InsertUserDetail(UserDTO userDTO)
        {
            try
            {
                /*var mailService = new MailService(); // Directly instantiate the mail service
                var emailSubject = "Welcome to Our Service!";
                var emailMessage = $"Hello {userDTO.uname},<br/><br/>Your account has been created successfully with ID {userDTO.id}.<br/><br/>Thank you,<br/>Your Company Name";
                await mailService.SendEmailAsync(userDTO.email, emailSubject, emailMessage);*/
                UserService.Create(userDTO);
                var successMessage = "User created successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = "An unexpected error occurred while creating the user. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }

        [HttpGet]
        [Route("api/userdetails/{id}")]
        public HttpResponseMessage GetByIDUser(int id)
        {
            try
            {
                var data = UserService.Get(id);

                if (data != null)
                {
                    var successMessage = $"User details with ID {id} retrieved successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage, Data = data });
                }
                else
                {
                    var notFoundMessage = $"User details with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while retrieving user details with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }

        [HttpPost]
        [Route("api/userdetails/delete/{id}")]
        public HttpResponseMessage DeleteByIDUser(int id)
        {
            try
            {
                var deleted = UserService.Delete(id);

                if (deleted)
                {
                    var successMessage = $"User with ID {id} deleted successfully.";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });
                }
                else
                {
                    var notFoundMessage = $"User with ID {id} not found.";
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = notFoundMessage });
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An unexpected error occurred while deleting the user with ID {id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }

        [HttpPost]
        [Route("api/userdetails/update")]
        public HttpResponseMessage UpdateUserDetail(UserDTO userDTO)
        {
            try
            {
                UserService.Update(userDTO); 
                var successMessage = $"User details with ID {userDTO.id} updated successfully.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = successMessage });

            }
            catch (Exception ex){
                var errorMessage = $"An unexpected error occurred while updating the user details with ID {userDTO.id}. Please try again later.";
                var detailedErrorMessage = $"Error: {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{errorMessage} {detailedErrorMessage}");
            }
        }
    }
}