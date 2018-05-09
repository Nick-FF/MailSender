using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace MailSender
{
	public class SchedulerClass
	{
		private readonly DispatcherTimer _timer = new DispatcherTimer(); // таймер
		private EmailSendServiceClass _emailSender; // экземпляр класса отвечающего за отправку писем
		private DateTime _dtSend; // дата и время отправки
		private ObservableCollection<Email> _emails; // коллекция email'ов адресатов
		/// <summary>
		/// Методе который превращаем строку из текстбокса tbTimePicker в TimeSpan
		/// </summary>
		/// <param name="strSendTime"></param>
		/// <returns></returns>
		public TimeSpan GetSendTime(string strSendTime)
		{
			TimeSpan tsSendTime = new TimeSpan();
			try
			{
				tsSendTime = TimeSpan.Parse(strSendTime);
			}
			catch
			{
				// ignored
			}

			return tsSendTime;
		}
		/// <summary>
		////Непостредственно отправка писем
		/// </summary>
		/// <param name="dtSend"></param>
		/// <param name="emailSender"></param>
		/// <param name="emails"></param>
		public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender,
			ObservableCollection<Email> emails)
		{
			_emailSender = emailSender; // Экземпляр класса отвечающего за отправку писем присваиваем
			_dtSend = dtSend;
			_emails = emails;
			_timer.Tick += Timer_Tick;
			_timer.Interval = new TimeSpan(0, 0, 1);
			_timer.Start();
		}
		private void Timer_Tick(object sender, EventArgs e)
		{
			if (_dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
			{
				_emailSender.SendMails(_emails);
				_timer.Stop();
				MessageBox.Show("Письма отправлены.");
			}
		}

	}
}