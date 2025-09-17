using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MailKit.Net.Smtp;



namespace Utility
{
    public class EmailSender : IEmailSender
    {        

        public EmailSender()
        {            
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {            
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Lazmek Store", "Lazmekstore@gmail.com"));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = subject;

                message.Body = new TextPart("html")
                {
                    Text = htmlMessage
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync("Lazmekstore@gmail.com", "******");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"error throw send email :{ex.Message}");
            }
        }

    }
}
