using Application.IService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            var email = new MimeMessage();

            // Thiết lập thông tin người gửi và người nhận
            email.From.Add(new MailboxAddress(smtpSettings["SenderName"], smtpSettings["SenderEmail"]));
            email.To.Add(MailboxAddress.Parse(toEmail));

            email.Subject = subject;

            // Thiết lập nội dung email
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();

            try
            {
                //await smtp.ConnectAsync(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), bool.Parse(smtpSettings["EnableSsl"]));
                // STARTTLS (Port 587)
                if (bool.Parse(smtpSettings["UseStartTls"]))
                {
                    await smtp.ConnectAsync(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), SecureSocketOptions.StartTls);
                }
                // SSL (Port 465)
                else if (bool.Parse(smtpSettings["EnableSsl"]))
                {
                    await smtp.ConnectAsync(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), SecureSocketOptions.SslOnConnect);
                }
                // Không có SSL/TLS
                else
                {
                    await smtp.ConnectAsync(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), SecureSocketOptions.None);
                }
                await smtp.AuthenticateAsync(smtpSettings["Username"], smtpSettings["Password"]);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Email could not be sent.", ex);
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
