using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void ViewMessageClicked(object sender, EventArgs e)
		{
			message.Text = "Hello Music City Code Developers (with XAML)!";
		}
	}
}
