using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Services;


namespace MailSender.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        ObservableCollection<Email> _Emails;
        public ObservableCollection<Email> Emails
        {
            get { return _Emails; }
            set
            {
                _Emails = value;
                RaisePropertyChanged(nameof(Emails));
            }
        }

        IDataAccessService _serviceProxy;
        void GetEmails()
        {
            Emails.Clear();
            foreach(var item in _serviceProxy.GetEmails())
            {
                Emails.Add(item);
            }
        }

        public RelayCommand ReadAllCommand { get; set; }

        public MainViewModel(IDataAccessService servProxy)
        {
            _serviceProxy = servProxy;
            Emails = new ObservableCollection<Email>();
            ReadAllCommand = new RelayCommand(GetEmails);
        }
    }
}