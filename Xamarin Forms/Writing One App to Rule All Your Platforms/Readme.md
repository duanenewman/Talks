# Xamarin Forms
## Writing One App to Rule All Your Platforms

# Synopsis

Are you seeking the Holy Grail of Write Once Run Anywhere app development? Then Xamarin Forms might be what you are looking for. This session will give you the information you need to understand Xamarin Forms and how it can be used to lower the friction of cross platform mobile development. You will see how easy it is to simultaneously create your app for iOS, Android, and Windows Phone.

# Code

The below code will take you through the progression of steps taken during the talk (and any we didn't get to).

1. Create a new project called ***XFTalk1***
2. Upgrade the nuget packages (if you get errors, try running it a second time to resolve reference conflicts and locked files)

		Update-Packages

## Demo 1 - Coded UI

3. Modify ***App.cs*** by replacing the constructor with the following

		private Label message;
		public App()
		{

			message = new Label
			{
				Text = "This space left intentionally blank",
				FontSize = 18,
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

## DEMO 2 - XAML UI

2. Add new *Forms Xaml Page* called ***HelloXamlPage***
3. Repalce the contents of the XAML page with:

```
<StackLayout>
	<Label x:Name="message"
		 Text="This space left intentionally blank"
		 Font="12,Bold" TextColor="Accent"
		 VerticalOptions="CenterAndExpand"
		 HorizontalOptions="CenterAndExpand" />
	<Button Text="View message" Clicked="ViewMessageClicked" />
</StackLayout>
```

4. In the code-behind for the new page add the following code:

		public void ViewMessageClicked(object sender, EventArgs args)
		{
			message.Text = "Hello KCDC Developers (with XAML)!";
		}

5. Change the App.cs constructor to load the new page:

		MainPage = new HelloXamlPage();
		
## DEMO 3 Hi/Lo Game
# PHASE 1

MAINPAGE
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage …    x:Class="HiLoGame.MainPage">
	<StackLayout>
		<StackLayout VerticalOptions="CenterAndExpand" HorizontalOptions="CenterAndExpand" >
			<Label Text="Will the next number be high or low?"/>
			<Label Text="{Binding CurrentValue}" HorizontalOptions="CenterAndExpand" />
		</StackLayout>
		<StackLayout>
			<Label Text="{Binding ResultMessage}"
					 VerticalOptions="CenterAndExpand"
					 HorizontalOptions="CenterAndExpand" />
			<StackLayout Orientation="Horizontal"
					 VerticalOptions="CenterAndExpand"
					 HorizontalOptions="CenterAndExpand">
				<Label Text="Your score is: " />
				<Label Text="{Binding CurrentScore}" />
			</StackLayout>
		</StackLayout>
		<Button Text="High" Command="{Binding GuessHighCommand}" />
		<Button Text="Low" Command="{Binding GuessLowCommand}"  />
	</StackLayout>
</ContentPage>

VIEW MODEL
this.BindingContext = new MainPageViewModel();
-------
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

PHASE 2 – STORE LAST NUMBER AND SCORE
Add JSon.NET NuGet

install-package newtonsoft.json
ADD IDATASERVICE INTERFACE		
public interface IDataService
{
	string GetScoreData();
	void SetScoreData(string data);
}
ADD CLASS: SCORES
public class Scores
{
	public int CorrectGuesses { get; set; }
	public int TotalGuesses { get; set; }
	public int LastValue { get; set; }
}
ADD PROPERTY & UPDATE OTHERS
private Scores Scores { get; set; }

public string CurrentScore
{
	get
	{
		return string.Format("{0} of {1} correct", CorrectGuesses, TotalGuesses);
	}
}
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
CTOR
var ds = DependencyService.Get<IDataService>();
Scores = Newtonsoft.Json.JsonConvert.DeserializeObject<Scores>(ds.GetScoreData());
ADD TO SHOWRESULT METHOD (REPLACE CURRENTSCORE = …)
var ds = DependencyService.Get<IDataService>();
ds.SetScoreData(Newtonsoft.Json.JsonConvert.SerializeObject(Scores));
ADD ANDROID IMPLEMENTATION
[assembly: Dependency(typeof(AndroidDataService))]
public class AndroidDataService : IDataService
{
	readonly string scoreFilePath ;

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
LOADING BLANK VALUES
ShowResults – move CurrentValue and CurrentScore to the property getter (KEEP LastValue!!)
public string CurrentValue
{
	get { return LastValue.ToString(); }
}
public string CurrentScore
{
	get { return string.Format("{0} of {1} correct", CorrectGuesses, TotalGuesses); }
}

PHASE 3 – ONPLATFORM
MAIN PAGE XAML
<StackLayout>
	<StackLayout.Orientation>
		<OnPlatform x:TypeArguments="StackOrientation" 
Android="Vertical" WinPhone="Horizontal" />
	</StackLayout.Orientation>
	<Button Text="High" Command="{Binding GuessHighCommand}" />
	<Button Text="Low" Command="{Binding GuessLowCommand}"  />
</StackLayout>

WINPHONE PROJECT
[assembly: Dependency(typeof(WinPhoneDataService))]

class WinPhoneDataService : IDataService
{
	readonly string scoreFilePath ;

	public WinPhoneDataService()
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

