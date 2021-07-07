using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebApi.Authentication;
using WebApi.Models;

namespace WebApi.Service
{
    public class EmailService : IEmailService
    {
        private readonly SMTPConfigModel _smtpConfig;
        private readonly IConfiguration Configuration;

        public EmailService(IOptions<SMTPConfigModel> smtpConfig, IConfiguration configuration) 
        {
            _smtpConfig = smtpConfig.Value;
            Configuration = configuration;
        }

        public async Task SendConfirmationEmail(ApplicationUser user, UserEmailOptions userEmailOptions, string token)
        {
            string message = "";
            var encodedToken = Uri.EscapeDataString(token);

            var verifyUrl = $"{Configuration["Origin"]}/api/authentication/confirmemail?userId={user.Id}&token={encodedToken}";
            message = $@"<p>Please click the below link to verify your email address:</p>
                            <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";

            userEmailOptions.Subject = "Confirm Email";
            userEmailOptions.Body = $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}";

            await SendEmail(userEmailOptions);

        }


        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML,

            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential,
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }
    }
}
