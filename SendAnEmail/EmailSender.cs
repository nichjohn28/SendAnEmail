using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SendAnEmail
{
    public interface IEmailSender
    {
        bool SendMessage(string from, string recipient, string subject, string body);
    }

    public class EmailSender : IEmailSender
    {
        private MessageDetails _details;
        static bool mailSent = false;
        // contructor
        public EmailSender() { }

        public bool SendMessage(string from, string recipient, string subject, string body)
        {
            var result = false;
            _details = SetMessageDetails(from, recipient, subject, body);

            var mail = new MailMessage();
            mail.From = new MailAddress(_details.Sender);
            mail.To.Add(new MailAddress(_details.Recipient));
            mail.Subject = _details.Subject;
            mail.Body = _details.Body;

            var smtpClient = new SmtpClient();
            Object state = mail;

            //event handler for asynchronous call
            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);

            // attempt to send three times
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    //smtpClient.SendAsync(mail, state);
                    _details.Status = true;
                    break;
                }
                catch (Exception ex)
                {
                    // log failed attempts
                    string log = ex.ToString();
                    continue;
                }
            }

            // save message to the email table
            _details.Save();

            result = mailSent;
            return result;
        }

        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var mail = e.UserState as MailMessage;

            if (!e.Cancelled && e.Error == null)
            {
                mailSent = true;
            }
            
        }

        private MessageDetails SetMessageDetails(string from, string recipient, string subject, string body)
        {
            return new MessageDetails(
                    from,
                    recipient,
                    subject,
                    body);
        }
    }

    public class MessageSender
    {
        private readonly IEmailSender _sender;

        public MessageSender(IEmailSender sender)
        {
            _sender = sender;
        }

        public bool SendMessage(string from, string sendTo, string subject, string body)
        {
            bool status = _sender.SendMessage(from, sendTo, subject, body);
            return status;
        }
    }

    public class MessageDetails
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public MessageDetails() { }
        public MessageDetails(string sender,
            string recipient,
            string subject,
            string body)
        {
            this.Sender = sender;
            this.Recipient = recipient;
            this.Subject = subject;
            this.Body = body;
            this.Date = DateTime.Now;
            this.Status = false;
        }

        public bool Save()
        {
            var result = false;

            try
            {
                using (var conn = new SqlConnection(@"Data Source=DEVENDRA\SQLEXPRESS;Initial Catalog=csharp4;Integrated Security=True"))
                using (var command = new SqlCommand("sp_insert_email_data", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter("@sender", Sender));
                    command.Parameters.Add(new SqlParameter("@recipient", Recipient));
                    command.Parameters.Add(new SqlParameter("@subject", Subject));
                    command.Parameters.Add(new SqlParameter("@body", Body));
                    command.Parameters.Add(new SqlParameter("@date", Date));
                    command.Parameters.Add(new SqlParameter("@status", Status));
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // log the failed database operation
                string log = ex.Message;
            }
            return result;
        }

    }
}