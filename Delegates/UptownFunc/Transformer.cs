namespace UptownFunc
{
	public class Transformer
	{
		public string Name { get; set; }
		public string AlternateForm { get; set; }
		public Affiliation Affiliation { get; set; }
		public int Rating { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}