using System;
using System.Collections.Generic;
using CodePasswordDLL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class VariablesClass
    {
        public static Dictionary<string,string> Senders
        {
            get { return dicSenders; }
        }
        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            { "79257443993@yandex.ru" , CodePassword.getPassword ( "1234l;i" ) },
            { "sok74@yandex.ru" , CodePassword.getPassword ( ";liq34tjk" ) },
        };
    }
    public static class VariablesSmtp
    {
        public static Dictionary<string,int> Smtpserv
        {
            get { return dicServers; }
        }
        private static Dictionary<string, int> dicServers = new Dictionary<string, int>()
        {
            {"smtp.mail.ru",465 },
            {"smtp.yandex.ru", 25 },
            {"smtp.gmail.com", 25 }
        };
    }
}
