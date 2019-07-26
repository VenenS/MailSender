﻿using System;
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
    }
    public class DataAccessService : IDataAccessService
    {
        EmailsDataContext context;
        public DataAccessService()
        {
            context = new EmailsDataContext();
        }
        public ObservableCollection<Email> GetEmails()
        {
            ObservableCollection<Email> Emails = new ObservableCollection<Email>();
            foreach(var item in context.Email)
            {
                Emails.Add(item);
            }
            return Emails;
        }
    }
}
