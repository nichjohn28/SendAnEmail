using System;

namespace SendAnEmail
{
    public partial class Email : System.Web.UI.Page
    {
        IEmailSender _messageSender = new EmailSender();

        protected void Page_Load(object sender, EventArgs e)
        {
        }        

        protected void send_Click(object sender, EventArgs e)
        {
            var from = Request.Form["txtSender"];
            var to = Request.Form["txtRecipient"];
            var subject = Request.Form["txtSubject"];
            var body = Request.Form["txtBody"];

            var ms = new MessageSender(_messageSender);
            if (ms.SendMessage(from, to, subject, body))
            {
                Lblstatus.Text = "Message sent!";
                Lblstatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Lblstatus.Text = "Message failed to send.";
                Lblstatus.ForeColor = System.Drawing.Color.Red;                
            }
            Lblstatus.Style["font-style"] = "italic";
            Lblstatus.Visible = true;
        }
    }
}