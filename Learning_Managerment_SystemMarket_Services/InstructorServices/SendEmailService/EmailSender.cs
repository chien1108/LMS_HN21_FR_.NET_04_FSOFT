using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.SendEmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        { }
        
        public string SendEmail(string from, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("User", from));
            message.To.Add(new MailboxAddress("Admin", "zangaga197@gmail.com"));
            message.Subject = "Feedback";
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            string emailAddress = "zangaga197@gmail.com";
            string password = "congchuaxuka0201";

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);
                client.Send(message);

                return "Success";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
