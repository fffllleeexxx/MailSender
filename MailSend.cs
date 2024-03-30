using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class MailSend
    {
        public static void SendMail(string recipient, string subject, string body)
        {
            // Sender
            MailAddress fromM = new MailAddress("emilsaidasev@gmail.com", "Emil");
            // Recipient
            MailAddress toM = new MailAddress(recipient);

            using (MailMessage message = new MailMessage(fromM, toM))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                message.Subject = subject; // Subject
                message.Body = body; // Email body

                // SMTP settings
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;

                // Sender's credentials (email address and password)
                smtpClient.Credentials = new NetworkCredential(fromM.Address, "jgdx vnjv ztsv zrbm");

                smtpClient.Send(message);
            }
        }
    }
}
