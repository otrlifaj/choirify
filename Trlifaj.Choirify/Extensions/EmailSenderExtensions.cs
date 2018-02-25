using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Trlifaj.Choirify.Services;

namespace Trlifaj.Choirify.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Potvrzení emailu",
                $"Potvrï svùj úèet kliknutím <a href='{HtmlEncoder.Default.Encode(link)}'>zde</a>");
        }
    }
}
