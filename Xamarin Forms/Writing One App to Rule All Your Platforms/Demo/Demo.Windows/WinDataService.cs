using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.ApplicationSettings;
using Demo.Windows;
using Xamarin.Forms;

[assembly: Dependency(typeof(WinDataService))]
namespace Demo.Windows
{
	class WinDataService : IDataService
	{
		readonly string scoreFilePath;

		public WinDataService()
		{
			scoreFilePath = "ScoreData";
		}

		public string GetScoreData()
		{
			try
			{
				StorageFile file = ApplicationData.Current.LocalFolder.GetFileAsync(scoreFilePath).GetResults();
				IRandomAccessStream readStream = file.OpenAsync(FileAccessMode.Read).GetResults();
				using (Stream inStream = Task.Run(() => readStream.AsStreamForRead()).Result)
				using (var tr = new StreamReader(inStream))
				{
					return tr.ReadToEnd();
				}
			}
			catch (FileNotFoundException)
			{
				//file not existing is perfectly valid so simply return the default 
				return "{}";
			}
		}


		public void SetScoreData(string data)
		{
			StorageFile file = ApplicationData.Current.LocalFolder.CreateFileAsync(scoreFilePath, CreationCollisionOption.ReplaceExisting).GetResults();
			IRandomAccessStream writeStream = file.OpenAsync(FileAccessMode.ReadWrite).GetResults();
			using (Stream outStream = Task.Run(() => writeStream.AsStreamForWrite()).Result)
			using (var tw = new StreamWriter(outStream))
			{
				tw.WriteAsync(data).Wait();
			}
		}

	}

}