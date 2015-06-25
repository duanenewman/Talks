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

			message = new Label
			{
				Text = "This space left intentionally blank",
				FontSize = 24,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Accent,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			var stack = new StackLayout();
			stack.Children.Add(message);

			var btn = new Button()
			{
				Text = "View message"
			};

			btn.Clicked += ViewMessageClicked;
			stack.Children.Add(btn);

			MainPage = new ContentPage
			{
				Content = stack
			};
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
