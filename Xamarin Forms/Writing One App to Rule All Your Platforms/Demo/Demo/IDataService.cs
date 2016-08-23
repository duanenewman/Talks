using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
	public interface IDataService
	{
		string GetScoreData();
		void SetScoreData(string data);
	}
	public class Scores
	{
		public int CorrectGuesses { get; set; }
		public int TotalGuesses { get; set; }
		public int LastValue { get; set; }
	}

}
