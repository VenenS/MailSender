using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class Server
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSSL { get; set; } = true;

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
