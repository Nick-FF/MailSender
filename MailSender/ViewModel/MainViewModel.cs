using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using MailSender.Services;

namespace MailSender.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private ObservableCollection<Email> _emails;
		private IDataAccessService _serviceProxy;
		private Email _emailInfo;

		public MainViewModel()
		{
			_serviceProxy = new DataAccessService();
			Emails = new ObservableCollection<Email>();
			EmailInfo = new Email();
			ReadAllCommand = new RelayCommand(GetEmails);
			SaveCommand = new RelayCommand<Email>(SaveEmail);
		}

		public RelayCommand ReadAllCommand { get; set; }
		public RelayCommand<Email> SaveCommand { get; set; }

		public ObservableCollection<Email> Emails
		{
			get { return _emails; }
			set
			{
				_emails = value;
				RaisePropertyChanged(nameof(Emails));
			}
		}

		public Email EmailInfo
		{
			get { return _emailInfo; }
			set
			{
				_emailInfo = value;
				RaisePropertyChanged(nameof(EmailInfo));
			}
		}


		private void GetEmails()
		{
			Emails.Clear();
			foreach (var item in _serviceProxy.GetEmails())
			{
				Emails.Add(item);
			}
		}

		private void SaveEmail(Email email)
		{
			EmailInfo.Id = _serviceProxy.CreateEmail(email);
			if (EmailInfo.Id != 0)
			{
				Emails.Add(EmailInfo);
				RaisePropertyChanged(nameof(EmailInfo));
			}
		}
	}
}