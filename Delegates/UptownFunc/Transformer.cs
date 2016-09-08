using System.Runtime.CompilerServices;
using PropertyChanged;

namespace UptownFunc
{
	public delegate string RollCallResponse(Transformer transformer);

	[ImplementPropertyChanged]
	public class Transformer
	{
		private bool isTransformed = false;

		public string Name { get; set; }
		public string AlternateForm { get; set; }
		public Affiliation Affiliation { get; set; }
		public int Rating { get; set; }
		public string CurrentState { get; private set; } = "Robot";

		public override string ToString()
		{
			return Name;
		}

		public string RollCall(RollCallResponse response)
		{
			return response(this);
		}

		public void Transform()
		{
			isTransformed = !isTransformed;
			CurrentState = isTransformed
				? AlternateForm
				: "Robot";
		}
	}
}