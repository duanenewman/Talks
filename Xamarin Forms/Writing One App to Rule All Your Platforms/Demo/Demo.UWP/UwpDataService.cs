using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpDataService))]
namespace Demo.UWP
{
	class UwpDataService : IDataService
	{
		readonly string scoreFilePath;

		public UwpDataService()
		{
			scoreFilePath = "ScoreData";
		}
		public string GetScoreData()
		{
			if (System.IO.File.Exists(scoreFilePath))
			{
				using (var tr = System.IO.File.OpenText(scoreFilePath))
				{
					return tr.ReadToEnd();
				}
			}

			return "{}";
		}

		public void SetScoreData(string data)
		{
			using (var tw = System.IO.File.CreateText(scoreFilePath))
			{
				tw.Write(data);
			}
		}
	}

}
