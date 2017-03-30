using System;
using System.Threading;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PropertyChanged;

namespace HowToDebug.ViewModels
{
	[ImplementPropertyChanged]
	public class MainWindowViewModel : BindableBase, INavigationAware
	{
		public string Title { get; set; } = "How To Debug!";
		public bool ChangingCondition { get; set; } = false;
		public bool BreakInBackgroundThread { get; set; } = false;
		public bool UpdateTimeAutomatically { get; set; } = true;

		public DateTime CurrentTime { get; set; }

		public MainWindowViewModel()
		{
			UpdateTimeCommand = new DelegateCommand(() =>
			{
				CurrentTime = GetCurrentTime();
			});

			BackgroundWorker = new Thread(() =>
			{
				while (IsRunning)
				{
					if (UpdateTimeAutomatically)
					{
						CurrentTime = GetCurrentTime();
					}
					Thread.Sleep(250);
				}
			});

			BackgroundWorker.Name = "MyBgThread";
			BackgroundWorker.Start();
			
		}

		public DelegateCommand UpdateTimeCommand { get; set; }

		private DateTime GetCurrentTime()
		{
			return DateTime.Now;
		}

		#region magic curtain
		private bool IsRunning { get; set; } = true;
		private Thread BackgroundWorker { get; set; }

		public void OnNavigatedTo(NavigationContext navigationContext)
		{

		}

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			IsRunning = false;
		} 
		#endregion
	}
}
