using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
//using SendGrid;
//using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace plathora.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task  SendEmailAsync(string email, string subject, string htmlMessage)
        {
            
            string fromemail = "info@tingtongindia.com";
            string password = "Plethora@123";

            

            bool send = false;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);

            mail.From = new MailAddress(fromemail, "Reset Password");
            mail.Subject = subject;
            StringBuilder strBul = new StringBuilder("<div>");
            strBul = strBul.Append("<div>You can use the following link to reset your password: " + htmlMessage + ",</div>");
            
            mail.Body = strBul.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "103.250.184.62";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(fromemail, password);
            try
            {
                smtp.Send(mail);
                send = true;
            }
            catch (Exception ex)
            {
                send = false;
                //  ErrHandler.writeError(ex.Message, ex.StackTrace);
            }
            
            
           //  throw new NotImplementedException();
        }
    }
}
