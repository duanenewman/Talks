using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGame
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = new MainPageViewModel();
		}
	}
}
