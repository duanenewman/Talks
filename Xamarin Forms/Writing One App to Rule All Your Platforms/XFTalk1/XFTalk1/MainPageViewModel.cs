using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFTalk1
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Random RandomNumberMachine { get; set; }
		public string CurrentValue { get; set; }
		public string ResultMessage { get; set; }
		public string CurrentScore { get; set; }
		public int CorrectGuesses { get; set; }
		public int TotalGuesses { get; set; }
		public int LastValue { get; set; }

		public MainPageViewModel()
		{
			RandomNumberMachine = new Random();
		}

		private Command guessHighCommand;
		public ICommand GuessHighCommand
		{
			get
			{
				return guessHighCommand ??
					(guessHighCommand = new Command(ExecuteGuessHigh));
			}
		}

		private void ExecuteGuessHigh()
		{
			var nextNumber = GetNextNumber(); //RandomNumberMachine.Next(0, 10);
			var success = LastValue < nextNumber;
			ShowResult(nextNumber, success);
		}

		private Command guessLowCommand;
		public ICommand GuessLowCommand
		{
			get
			{
				return guessLowCommand ??
				(guessLowCommand = new Command(ExecuteGuessLow));
			}
		}

		private void ExecuteGuessLow()
		{
			var nextNumber = GetNextNumber(); //RandomNumberMachine.Next(0, 10);
			var success = LastValue > nextNumber;
			ShowResult(nextNumber, success);
		}

		private int GetNextNumber()
		{
			var nextNumber = LastValue;
			while (nextNumber == LastValue)
			{
				nextNumber = RandomNumberMachine.Next(0, 10);
			}
			return nextNumber;
		}

		public void ShowResult(int nextNumber, bool success)
		{
			CorrectGuesses += success ? 1 : 0;
			TotalGuesses++;
			CurrentValue = (LastValue = nextNumber).ToString();
			ResultMessage = success ? "You Guessed Correct!" : "Wrong Answer!";
			CurrentScore = string.Format("{0} of {1} correct", CorrectGuesses, TotalGuesses);
			PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
		}
	}

}
