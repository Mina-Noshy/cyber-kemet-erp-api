using System.Net;
using System.Net.Mail;

namespace Kemet.ERP.Shared.Utilities
{
    public static class EmailHelper
    {
        public static bool Send(string[] recipientEmails, string[]? ccEmails, string subject, string body)
        {

            // Sender's email address and password
            string senderEmail = ConfigurationHelper.GetSMTP("SenderEmail");
            string senderPassword = ConfigurationHelper.GetSMTP("SenderPassword");

            // Create a MailMessage object
            MailMessage mail = new MailMessage();

            // Add recipients to the "To" list
            foreach (string recipient in recipientEmails)
            {
                mail.To.Add(recipient);
            }

            // Add CC recipients
            if (ccEmails != null && ccEmails.Count() > 0)
            {
                foreach (string ccRecipient in ccEmails)
                {
                    mail.CC.Add(ccRecipient);
                }
            }

            // Set the subject and body of the email
            mail.Subject = subject;
            mail.Body = body;

            // Set the sender's email address
            mail.From = new MailAddress(senderEmail);

            // Create and configure the SMTP client
            SmtpClient smtpClient = new SmtpClient(ConfigurationHelper.GetSMTP("SmtpHost"));
            smtpClient.Port = int.Parse(ConfigurationHelper.GetSMTP("Port"));
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = bool.Parse(ConfigurationHelper.GetSMTP("EnableSsl"));

            try
            {
                // Send the email
                smtpClient.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Failed to send email to '{senderEmail}': {ex.Message}";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
