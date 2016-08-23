using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Demo
{
	public class HiLoGamePageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Random RandomNumberMachine { get; set; }
		public string ResultMessage { get; set; }
		public string CurrentValue => LastValue.ToString();

		public string CurrentScore => $"{CorrectGuesses} of {TotalGuesses} correct";

		public int CorrectGuesses
		{
			get { return Scores.CorrectGuesses; }
			set { Scores.CorrectGuesses = value; }
		}

		public int TotalGuesses
		{
			get { return Scores.TotalGuesses; }
			set { Scores.TotalGuesses = value; }
		}

		public int LastValue
		{
			get { return Scores.LastValue; }
			set { Scores.LastValue = value; }
		}
		private Scores Scores { get; set; }

		public HiLoGamePageViewModel()
		{
			RandomNumberMachine = new Random();
			var ds = DependencyService.Get<IDataService>();
			Scores = Newtonsoft.Json.JsonConvert.DeserializeObject<Scores>(ds.GetScoreData());
		}

		private Command guessHighCommand;
		public ICommand GuessHighCommand => guessHighCommand ??
		                                    (guessHighCommand = new Command(ExecuteGuessHigh));

		private void ExecuteGuessHigh()
		{
			var nextNumber = GetNextNumber();
			var success = LastValue < nextNumber;
			ShowResult(nextNumber, success);
		}

		private Command guessLowCommand;
		public ICommand GuessLowCommand => guessLowCommand ??
		                                   (guessLowCommand = new Command(ExecuteGuessLow));

		private void ExecuteGuessLow()
		{
			var nextNumber = GetNextNumber(); 
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
			LastValue = nextNumber;
			ResultMessage = success ? "You Guessed Correct!" : "Wrong Answer!";
			var ds = DependencyService.Get<IDataService>();
			ds.SetScoreData(Newtonsoft.Json.JsonConvert.SerializeObject(Scores));

			//This line cheats and tells the binding system that every field has changed.
			//I typically use either KindOfMagic or Fody.PropertyChanged nuget packages to automate the PropertyChanged call from my automatic properties
			PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
		}
	}
}