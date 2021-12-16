using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Services
{
    public class EmailService : IEmailService
    {
        public async Task<SendGrid.Response> SendEmailAsync(string subject, string toEmail, string toName, string confirmationEmailLink)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mohammedomran312@gmail.com", "Mohammed Ali");
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = "Welcome to Mohandisy";
            var htmlContent = $"<strong>Click here to confirm your email <a href='{confirmationEmailLink}'>{confirmationEmailLink}</a></strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}
