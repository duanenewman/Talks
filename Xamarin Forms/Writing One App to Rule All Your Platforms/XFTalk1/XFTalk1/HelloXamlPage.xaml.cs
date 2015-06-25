using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFTalk1
{
	public partial class HelloXamlPage : ContentPage
	{
		public HelloXamlPage()
		{
			InitializeComponent();
		}

		public void ViewMessageClicked(object sender, EventArgs args)
		{
			message.Text = "Hello KCDC Developers (with XAML)!";
		}

	}
}
