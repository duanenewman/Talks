using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using PropertyChanged;

namespace UptownFunc
{
	
	public class Transformer : INotifyPropertyChanged
	{
		private bool isTransformed = false;

        public string Name { get; set; }
		public string AlternateForm { get; set; }
		public Affiliation Affiliation { get; set; }
		public int Rating { get; set; }
		public string CurrentState => isTransformed ? AlternateForm : "Robot";

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
		{
			return Name;
		}
        		
		public void Transform()
		{
            isTransformed = !isTransformed;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentState)));
        }

	}
}