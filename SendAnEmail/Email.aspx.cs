using System;

namespace SendAnEmail
{
    public partial class Email : System.Web.UI.Page
    {
        IEmailSender _messageSender = new EmailSender();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }        

        protected void send_Click(object sender, EventArgs e)
        {
            string from = Request.Form["txtSender"];
            string to = Request.Form["txtRecipient"];
            string subject = Request.Form["txtSubject"];
            string body = Request.Form["txtBody"];

            MessageSender ms = new MessageSender(_messageSender);
            ms.SendMessage(from, to, subject, body);
        }
    }
}