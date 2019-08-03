using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MailSender
{
    public class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer();
        EmailSendServiceClass emailSender;

        DateTime dtSend;
        ObservableCollection<Email> emails;

        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }
            return tsSendTime;
        }
        public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender,
            ObservableCollection<Email> emails)
        {
            this.emailSender = emailSender;
            this.dtSend = dtSend;
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    if(dtSend.ToShortTimeString()==DateTime.Now.ToShortTimeString())
        //    {
        //        emailSender.SendMails(emails);
        //        timer.Stop();
        //        MessageBox.Show("Письма отправлены");
        //    }
        //}

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dicDates.Count == 0)
            {
                timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
            else if (dicDates.Keys.First<DateTime>().ToShortTimeString() ==
                DateTime.Now.ToShortTimeString())
            {
                emailSender.strBody = dicDates[dicDates.Keys.First<DateTime>()];
                emailSender.strSubject = $"Рассылка от {dicDates.Keys.First<DateTime>().ToShortTimeString()}";
                emailSender.SendMails(emails);
                dicDates.Remove(dicDates.Keys.First<DateTime>());
            }
        }


        Dictionary<DateTime, string> dicDates = new Dictionary<DateTime, string>();
        public Dictionary<DateTime, string> DatesEmailTexts
        {
            get { return dicDates; }
            set
            {
                dicDates = value;
                dicDates = dicDates.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
    }
}
