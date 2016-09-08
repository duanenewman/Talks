using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;

namespace UptownFunc
{
	[ImplementPropertyChanged]
	public class MainWindowViewModel
	{
		#region properties
		public List<Transformer> AllTransformers { get; set; }
		public Transformer SelectedTransformer { get; set; }

		public List<RollcallOption> RollcallOptions { get; set; }
		public RollcallOption SelectedRollcallOption { get; set; }
		public ICommand CallRollCommand { get; private set; }

		public List<ActionOption> ActionOptions { get; set; }
		public ICommand TakeActionCommand { get; private set; }

		public ObservableCollection<string> Results { get; set; } = new ObservableCollection<string>();
		#endregion

		public MainWindowViewModel()
		{
			AllTransformers = Transformers.GetTransformers();
			SelectedTransformer = AllTransformers.First();
			RollcallOptions = new List<RollcallOption>()
			{
				new RollcallOption() {
					Name = "Name",
					RollCallResponse = t => t.Name
				},
				new RollcallOption()
				{
					Name = "Affiliation",
					RollCallResponse = t => $"{t.Name} is a {t.Affiliation.ToString()}"
				},
				new RollcallOption()
				{
					Name = "Alternate Form",
					RollCallResponse = t => t.AlternateForm
				},
				new RollcallOption()
				{
					Name = "Rating",
					RollCallResponse = t => $"{t.Rating.ToString()} - {t.Name}"
				},
			};
			ActionOptions = new List<ActionOption>()
			{
				new ActionOption() { Name = "Transform" },
				new ActionOption() { Name = "Top Rated" },
				new ActionOption() { Name = "Average Rating" }
			};
			SelectedRollcallOption = RollcallOptions.First();

			CallRollCommand = new RelayCommand<object>(CallRollCommandExecute);
			TakeActionCommand = new RelayCommand<object>(TakeActionCommandExecute);
		}


		private void CallRollCommandExecute(object obj)
		{
			Results.Clear();
			foreach (var transformer in AllTransformers)
			{
				Results.Add(transformer.RollCall(SelectedRollcallOption.RollCallResponse));

			}
		}

		private void TakeActionCommandExecute(object obj)
		{

			Results.Clear();
			Results.Add("Nothing to do here yet");

		}
	}
}