using PropertyChanged;

namespace UptownFunc
{
	[ImplementPropertyChanged]
	public class ActionOption
	{
		public bool IsChecked { get; set; }
		public string Name { get; set; }
	}
}