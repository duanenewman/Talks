using Microsoft.Practices.Unity;
using Prism.Unity;
using HowToDebug.Views;
using System.Windows;

namespace HowToDebug
{
	class Bootstrapper : UnityBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void InitializeShell()
		{
			Application.Current.MainWindow.Show();
		}
	}
}
