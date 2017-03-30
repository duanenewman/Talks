using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            RollcallOptions = SetupRollcallOptions();
            ActionOptions = SetupActionOptions();
			SelectedRollcallOption = RollcallOptions.First();

			CallRollCommand = new RelayCommand<object>(CallRollCommandExecute);
			TakeActionCommand = new RelayCommand<object>(TakeActionCommandExecute);
		}

        // Rollcall step 1
        private static List<RollcallOption> SetupRollcallOptions()
        {
            return new List<RollcallOption>()
            {
                new RollcallOption() {
                    Name = "Name"
                },
                new RollcallOption()
                {
                    Name = "Affiliation"
                },
                new RollcallOption()
                {
                    Name = "Alternate Form"
                },
                new RollcallOption()
                {
                    Name = "Rating"
                },
            };
        }

        // Rollcall step 2
        //private static List<RollcallOption> SetupRollcallOptions()
        //{
        //	return new List<RollcallOption>()
        //	{
        //		new RollcallOption() {
        //			Name = "Name",
        //			RollCallResponse = t => t.Name
        //		},
        //		new RollcallOption()
        //		{
        //			Name = "Affiliation",
        //			RollCallResponse = RollCallAffiliation
        //		},
        //		new RollcallOption()
        //		{
        //			Name = "Alternate Form",
        //			RollCallResponse = RollCallAlternateForm
        //		},
        //		new RollcallOption()
        //		{
        //			Name = "Rating",
        //			RollCallResponse = RollCallRating
        //		},
        //	};
        //}

        // // RollCall Step 3
        //private static List<RollcallOption> SetupRollcallOptions()
        //{
        //	return new List<RollcallOption>()
        //	{
        //		new RollcallOption() {
        //			Name = "Name",
        //			RollCallResponse = t => t.Name
        //		},
        //		new RollcallOption()
        //		{
        //			Name = "Affiliation",
        //			RollCallResponse = t => $"{t.Name} is a {t.Affiliation.ToString()}"
        //		},
        //		new RollcallOption()
        //		{
        //			Name = "Alternate Form",
        //			RollCallResponse = t => t.AlternateForm
        //		},
        //		new RollcallOption()
        //		{
        //			Name = "Rating",
        //			RollCallResponse = t => $"{t.Rating.ToString()} - {t.Name}"
        //		},
        //	};
        //}


        // Action Step 1
        private List<ActionOption> SetupActionOptions()
        {
            return new List<ActionOption>()
            {
                new ActionOption()
                {
                    Name = "Transform"
                },
                new ActionOption()
                {
                    Name = "Top Rated"
                },
                new ActionOption()
                {
                    Name = "Average Rating"
                },
                new ActionOption()
                {
                    Name = "First By Name"
                }
            };
        }

        // // Action Step 2
        //private List<ActionOption> SetupActionOptions()
        //{
        //	return new List<ActionOption>()
        //	{
        //		new ActionOption()
        //		{
        //			Name = "Transform",
        //			Action = t =>
        //			{
        //				foreach (var transformer in t)
        //				{
        //					transformer.Transform();
        //				}
        //			}
        //		},
        //		new ActionOption()
        //		{
        //			Name = "Top Rated",
        //			Action = t =>
        //			{
        //				MessageBox.Show($"Top rated transformer: {t.OrderByDescending(t1 => t1.Rating).First().Name}");
        //			}
        //		},
        //		new ActionOption()
        //		{
        //			Name = "Average Rating",
        //			Action = t =>
        //			{
        //				Results.Add($"Average Rating: {t.Average(t1 => t1.Rating).ToString()}");
        //			}
        //		},
        //		new ActionOption()
        //		{
        //			Name = "First By Name",
        //			Action = t =>
        //			{
        //				Results.Add(t.OrderBy(t1 => t1.Name).First().Name);
        //			}
        //		}
        //	};
        //}

        private void CallRollCommandExecute(object obj)
		{
			Results.Clear();
            Results.Add("Nothing to do");

        }

        // // Rollcall 1
        //foreach (var transformer in AllTransformers)
        //{
        //	if (SelectedRollCallOption.Name == "Name")
        //	{
        //		Results.Add(transformer.RollCall(RollCallName));
        //	}
        //	else if (SelectedRollCallOption.Name == "Affiliation")
        //	{
        //		Results.Add(transformer.RollCall(RollCallAffiliation));
        //	}
        //	else if (SelectedRollCallOption.Name == "Alternate Form")
        //	{
        //		Results.Add(transformer.RollCall(RollCallAlternateForm));
        //	}
        //	else if (SelectedRollCallOption.Name == "Rating")
        //	{
        //		Results.Add(transformer.RollCall(RollCallRating));
        //	}
        //}

        // // Rollcall 2 (with variable)
        //RollCallDelegate rollcallMethod = null;
        //
        //if (SelectedRollCallOption.Name == "Name")
        //{
        //    rollcallMethod = RollCallName;
        //}
        //else if (SelectedRollCallOption.Name == "Affiliation")
        //{
        //    rollcallMethod = RollCallAffiliation;
        //}
        //else if (SelectedRollCallOption.Name == "Alternate Form")
        //{
        //    rollcallMethod = RollCallAlternateForm;
        //}
        //else if (SelectedRollCallOption.Name == "Rating")
        //{
        //    rollcallMethod = RollCallRating;
        //}
        //
        //foreach (var transformer in AllTransformers)
        //{
        //    transformer.RollCall(rollcallMethod);
        //}

        // // Rollcall 3 (with func)
        //foreach (var transformer in AllTransformers)
        //{
        //	Results.Add(SelectedRollcallOption.RollCallResponse(transformer));
        //}

        #region RollCall Methods
        private static string RollCallName(Transformer transformer)
		{
			return transformer.Name;
		}

		private static string RollCallAffiliation(Transformer transformer)
		{
			return $"{transformer.Name} is a {transformer.Affiliation}";
		}

		private static string RollCallAlternateForm(Transformer transformer)
		{
			return transformer.AlternateForm;
		}

		private static string RollCallRating(Transformer transformer)
		{
			return $"{transformer.Rating} - {transformer.Name}";
		}

		#endregion

		private void TakeActionCommandExecute(object obj)
		{
			Results.Clear();
            Results.Add("Nothing to do");
            
        }

        // // Action Base
        //Action<List<Transformer>> action = null;
        //
        //foreach (var actionOption in ActionOptions)
        //{
        //    if (actionOption.IsChecked)
        //        action += actionOption.Action;
        //}
        //
        //action.Invoke(AllTransformers);
    }
}