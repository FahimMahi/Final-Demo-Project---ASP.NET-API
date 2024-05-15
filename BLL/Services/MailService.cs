using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }

    public class MailService : IMailService
    {
        private readonly string _mailServer = "smtp.gmail.com";
        private readonly int _mailPort = 465;
        private readonly string _senderName = "Fahim Mahmud Mahi";
        private readonly string _senderEmail = "fahim.mahi@gmail.com";
        private readonly string _username = "fahim.mahi";
        private readonly string _password = "";

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            using (var client = new SmtpClient(_mailServer, _mailPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_username, _password);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_senderEmail, _senderName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
