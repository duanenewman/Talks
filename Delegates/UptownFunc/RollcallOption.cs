using System;

namespace UptownFunc
{
	public class RollcallOption
	{
		public string Name { get; set; }
		public Func<Transformer, string> RollCallResponse { get; set; }
	}
}