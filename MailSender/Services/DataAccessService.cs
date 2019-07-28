using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Email> GetEmails();
        int CreateEmail(Email email);
    }
    public class DataAccessService : IDataAccessService
    {
        private readonly EmailsDataContext context = new
            EmailsDataContext();

        public ObservableCollection<Email> GetEmails()
        {
            ObservableCollection<Email> Emails = new ObservableCollection<Email>();
            foreach(var item in context.Email)
            {
                Emails.Add(item);
            }
            return Emails;
        }
        public int CreateEmail(Email email)
        {
            if (context.Email.Contains(email)) return email.Id;
            context.Email.InsertOnSubmit(email);
            context.SubmitChanges();
            return email.Id;
        }
    }
}
