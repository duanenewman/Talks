using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace HelloKC
{
	public class HelloPage : ContentPage
	{
		private Label message;
		public HelloPage()
		{

			var stack = new StackLayout();
			stack.Children.Add(
				message = new Label
				{
					Text = "This space left intentionally blank",
					Font = Font.SystemFontOfSize(12, FontAttributes.Bold),
					TextColor = Color.Accent,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				});

			var btn = new Button()
			{
				Text = "View message"
			};

			btn.Clicked += ViewMessageClicked;
			stack.Children.Add(btn);

			this.Content = stack;
		}

		public void ViewMessageClicked(object sender, EventArgs args)
		{
			message.Text = "Hello KC Mobile .NET Developers!";
		}

	}
}
