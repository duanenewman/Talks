using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFTalk1
{
	public class App : Application
	{
		private Label message;
		public App()
		{
			MainPage = new HelloXamlPage();
		}

		public void ViewMessageClicked(object sender, EventArgs args)
		{
			message.Text = "Hello KCDC Developers!";
		}


		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
