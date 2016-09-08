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

		public ICommand ProcessCommand { get; private set; }

		public ObservableCollection<string> Results { get; set; } = new ObservableCollection<string>();
		#endregion

		public MainWindowViewModel()
		{
			AllTransformers = Transformers.GetTransformers();
			SelectedTransformer = AllTransformers.First();
			RollcallOptions = new List<RollcallOption>()
			{
				new RollcallOption() {Name = "Silence"},
				new RollcallOption() {Name = "Affiliation"},
				new RollcallOption() {Name = "Alternate Form"},
				new RollcallOption() {Name = "Rating"},
			};
			SelectedRollcallOption = RollcallOptions.First();

			ProcessCommand = new RelayCommand<object>(ProcessCommandExecute);
		}

		private void ProcessCommandExecute(object obj)
		{

			Results.Clear();
			Results.Add("Nothing to do here yet");

		}
	}
}