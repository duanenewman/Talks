using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFTalk1.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDataService))]

namespace XFTalk1.Droid
{
	public class AndroidDataService : IDataService
	{
		readonly string scoreFilePath;

		public AndroidDataService()
		{
			scoreFilePath = System.IO.Path.Combine(
				System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
				"ScoreData");
		}
		public string GetScoreData()
		{
			if (System.IO.File.Exists(scoreFilePath))
			{
				return System.IO.File.ReadAllText(scoreFilePath);
			}

			return "{}";
		}

		public void SetScoreData(string data)
		{
			System.IO.File.WriteAllText(scoreFilePath, data);
		}
	}

}