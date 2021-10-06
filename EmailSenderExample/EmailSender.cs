using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderExample
{
    static class EmailSender
    {
        public static void Send(string to, string message)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("unutulacakhesap9999@gmail.com","1q2w3e4r!'");
            smtpClient.Credentials = credential;

            MailAddress from = new MailAddress("unutulacakhesap9999@gmail.com", "Mail Gönderen Hesabın Adı (:");
            MailAddress alici = new MailAddress(to);
            MailMessage mail = new MailMessage(from, alici);
            mail.Subject = "Örnek";
            mail.Body = message;
            smtpClient.Send(mail);
        }
    }
}
