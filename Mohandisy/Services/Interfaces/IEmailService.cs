using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Services
{
    public interface IEmailService
    {
        Task<SendGrid.Response> SendEmailAsync(string subject, string toEmail, string toName, string confirmationEmail);

    }
}
