using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using PropertyChanged;

namespace UptownFunc
{
	
	[ImplementPropertyChanged]
	public class Transformer
	{
		private bool isTransformed = false;

		public string Name { get; set; }
		public string AlternateForm { get; set; }
		public Affiliation Affiliation { get; set; }
		public int Rating { get; set; }
        public string CurrentState => isTransformed ? AlternateForm : "Robot";


        public override string ToString()
		{
			return Name;
		}
        		
		public void Transform()
		{
			isTransformed = !isTransformed;
			//CurrentState = isTransformed
			//	? AlternateForm
			//	: "Robot";
		}
	}
}