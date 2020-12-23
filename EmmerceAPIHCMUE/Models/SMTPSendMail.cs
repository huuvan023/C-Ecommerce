using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Models
{
    public class SMTPSendMail
    {
        private static SMTPSendMail instance;
        public static SMTPSendMail Instance
        {
            get
            {
                if (instance == null) instance = new SMTPSendMail();
                return SMTPSendMail.instance;
            }
            private set
            {
                SMTPSendMail.instance = value;
            }
        }
        private SMTPSendMail() { }
        // public IFormFile Attachment { get; set; }

        private const string FromEmail = "huu.van.23tg@gmail.com";
        private const string FromPassword = "cbuqrkomjsxcwwrk";

        public bool SendEmail(string To, string Subject, string Body)
        {
            try
            {
                using (MailMessage message = new MailMessage(FromEmail, To))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential cred = new NetworkCredential(FromEmail, FromPassword);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = cred;
                        smtp.Port = 587;
                        smtp.Send(message);
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
