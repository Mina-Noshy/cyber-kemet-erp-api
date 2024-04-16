using System.Net;
using System.Net.Mail;

namespace Kemet.ERP.Shared.Utilities
{
    public static class EmailHelper
    {
        public static bool Send(string[] recipientEmails, string[]? ccEmails, string subject, string body, bool isBodyHtml = false, params string[]? attachments)
        {
            return SEND_EMAIL(recipientEmails, ccEmails, subject, body, isBodyHtml, attachments);
        }

        public static bool Send(string recipient, string[]? ccEmails, string subject, string body, bool isBodyHtml = false, params string[]? attachments)
        {
            string[] recipientEmails = { recipient };

            return SEND_EMAIL(recipientEmails, ccEmails, subject, body, isBodyHtml, attachments);
        }

        public static bool Send(string recipient, string subject, string body, bool isBodyHtml = false, params string[]? attachments)
        {
            string[] recipientEmails = { recipient };
            string[]? ccEmails = null;

            return SEND_EMAIL(recipientEmails, ccEmails, subject, body, isBodyHtml, attachments);
        }

        public static bool Send(string recipient, string subject, string body, params string[]? attachments)
        {
            string[] recipientEmails = { recipient };
            string[]? ccEmails = null;
            bool isBodyHtml = false;

            return SEND_EMAIL(recipientEmails, ccEmails, subject, body, isBodyHtml, attachments);
        }

        public static bool Send(string recipient, string subject, string body)
        {
            string[] recipientEmails = { recipient };
            string[]? ccEmails = null;
            bool isBodyHtml = false;
            string[]? attachments = null;

            return SEND_EMAIL(recipientEmails, ccEmails, subject, body, isBodyHtml, attachments);
        }









        private static bool SEND_EMAIL(string[] recipientEmails, string[]? ccEmails, string subject, string body, bool isBodyHtml = false, params string[]? attachments)
        {
            // Sender's email address and password
            string senderEmail = ConfigurationHelper.GetSMTP("SenderEmail");
            string senderPassword = ConfigurationHelper.GetSMTP("SenderPassword");

            // Create a MailMessage object
            MailMessage mail = new MailMessage();

            // Set the sender's email address
            mail.From = new MailAddress(senderEmail);

            // Add recipients to the "To" list
            foreach (string recipient in recipientEmails)
            {
                mail.To.Add(recipient);
            }

            // Add CC recipients
            if (ccEmails != null && ccEmails.Length > 0)
            {
                foreach (string ccRecipient in ccEmails)
                {
                    mail.CC.Add(ccRecipient);
                }
            }

            // Set the subject and body of the email
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;


            // Add an attachment using FileStream
            if (attachments != null && attachments.Length > 0)
            {
                foreach (var file in attachments)
                {
                    Attachment attachment = new Attachment(file);
                    mail.Attachments.Add(attachment);
                }
            }

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
