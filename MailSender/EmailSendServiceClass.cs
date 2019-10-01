using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    public class EmailSendServiceClass
    {
        private string strLogin;
        private string strPassword;
        private string strSmtp;
        private int iSmtpPort;
        public string strBody;
        public string strSubject;

        public EmailSendServiceClass(string sLogin, string sPassword, string sBody, string sSubject,
            string sSmtp, int sPort)
        {
            strLogin = sLogin;
            strPassword = sPassword;
            strBody = sBody;
            strSubject = sSubject;
            strSmtp = sSmtp;
            iSmtpPort = sPort;
        }
        private void SendMail(string mail, string name)
        {
            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = strBody;
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                //sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                //sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
                try
                {
                    sc.Send(mm);
                    MessageBox.Show("Почта успешно отправлена",
                            "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                }
            }


        }
        public void SendMails(ObservableCollection<Email> emails)
        {
            foreach (Email email in emails)
            {
                SendMail(email.Address, email.Name);
            }
        }


    }
}
