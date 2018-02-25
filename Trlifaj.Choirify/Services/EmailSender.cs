using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSettings EmailSettings { get; private set; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                var mail = ComposeMail(email, subject, message);
                await SendMail(mail);
            }
            catch (Exception)
            {

            }
        }

        public Task SendEmailAsync(List<string> emails, string subject, string message)
        {
            Execute(emails, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(List<string> emails, string subject, string message)
        {
            try
            {
                var mail = ComposeMail(emails, subject, message);
                await SendMail(mail);
            }
            catch (Exception)
            {

            }
        }


        private MailMessage ComposeMail(string email, string subject, string message)
        {
            return ComposeMail(new List<string> { email }, subject, message);
        }

        private MailMessage ComposeMail(List<string> emails, string subject, string message)
        {
            var mail = PrepareMail(subject, message);
            foreach (var email in emails)
            {
                mail.To.Add(new MailAddress(email));
            }
            return mail;
        }

        private MailMessage PrepareMail(string subject, string message)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(EmailSettings.UsernameEmail, EmailSettings.DisplayName)
            };

            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            return mail;
        }

        private async Task SendMail(MailMessage mail)
        {
            using (SmtpClient smtp = new SmtpClient(EmailSettings.PrimaryDomain, EmailSettings.PrimaryPort))
            {
                smtp.Credentials = new NetworkCredential(EmailSettings.UsernameEmail, EmailSettings.UsernamePassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
