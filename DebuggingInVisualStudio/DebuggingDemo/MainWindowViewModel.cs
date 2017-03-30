using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;

namespace DebuggingDemo
{
	[ImplementPropertyChanged]
	public class MainWindowViewModel
	{
		public string Message { get; set; }

		public MainWindowViewModel()
		{
			//ICommand UpdateMessageCommand = 
		}
	}
}
