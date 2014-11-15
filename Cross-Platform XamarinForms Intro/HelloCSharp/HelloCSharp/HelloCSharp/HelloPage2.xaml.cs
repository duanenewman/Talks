using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp
{
	public partial class HelloPage2
	{
		public HelloPage2()
		{
			InitializeComponent();
		}


		public void ViewMessageClicked(object sender, EventArgs args)
		{
			message.Text = "Hello STLDODN!";
		}
	}
}
