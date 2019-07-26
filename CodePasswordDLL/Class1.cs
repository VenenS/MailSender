using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePasswordDLL
{
    public class CodePassword
    {
        public static string getPassword(string p_sPassw)
        {
            string password = "";
            foreach (char a in p_sPassw)
            {
                char ch = a;
                ch--;
                password += ch;
            }
            return password;
        }
        public static string getCodPassword(string p_sPassword)
        {
            string sCode = "";
            foreach (char a in p_sPassword)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }
    }
}
