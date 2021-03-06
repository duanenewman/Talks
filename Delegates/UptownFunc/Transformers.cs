using System.Collections.Generic;
using System.Linq;

namespace UptownFunc
{
	public static class Transformers
	{
		public static List<Transformer> GetTransformers()
		{
			return new List<Transformer>()
			{
				new Transformer()
				{
					Name = "Optimus Prime",
					AlternateForm = "1984 Freightliner Semi",
					Affiliation = Affiliation.Autobot,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Bumblebee",
					AlternateForm = "1979 VW Beetle",
					Affiliation = Affiliation.Autobot,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Cliffjumper",
					AlternateForm = "1979 VW Beetle",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Wheeljack",
					AlternateForm = "1977 Lancia Stratos Turbo",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Prowl",
					AlternateForm = "1979 Nissan 280ZX Police Car",
					Affiliation = Affiliation.Autobot,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Jazz",
					AlternateForm = "1976 Porsche 935",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Sideswipe",
					AlternateForm = "1974 Lamborghini LP500S",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Ratchet",
					AlternateForm = "1979 Nissan Ambulance",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Ironhide",
					AlternateForm = "1979 Nissan Van",
					Affiliation = Affiliation.Autobot,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Hot Rod",
					AlternateForm = "Cybertronian sports car",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Springer",
					AlternateForm = "Cybertronian Helicopter",
					Affiliation = Affiliation.Autobot,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Kup",
					AlternateForm = "Cybertronian Pickup Truck",
					Affiliation = Affiliation.Autobot,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Ultra Magnus",
					AlternateForm = "1985 Mack Car Carrier",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Blurr",
					AlternateForm = "Cybertronian Hover Car",
					Affiliation = Affiliation.Autobot,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Arcee",
					AlternateForm = "Cybertronian Convertible",
					Affiliation = Affiliation.Autobot,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Wheelie",
					AlternateForm = "Cybertronian Car",
					Affiliation = Affiliation.Autobot,
					Rating = 3
				},



				new Transformer()
				{
					Name = "Megatron",
					AlternateForm = "1913 U.N.C.L.E. Walther P38",
					Affiliation = Affiliation.Decepticon,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Soundwave",
					AlternateForm = "Microcassette recorder",
					Affiliation = Affiliation.Decepticon,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Shockwave",
					AlternateForm = "Laser Cannon",
					Affiliation = Affiliation.Decepticon,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Skywarp",
					AlternateForm = "1975 F-15 Eagle",
					Affiliation = Affiliation.Decepticon,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Starscream",
					AlternateForm = "1975 F-15 Eagle",
					Affiliation = Affiliation.Decepticon,
					Rating = 5
				},
				new Transformer()
				{
					Name = "Thundercracker",
					AlternateForm = "1975 F-15 Eagle",
					Affiliation = Affiliation.Decepticon,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Reflector",
					AlternateForm = "1981 Kodak Camera",
					Affiliation = Affiliation.Decepticon,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Hook",
					AlternateForm = "1970 Crane Vehicle",
					Affiliation = Affiliation.Decepticon,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Scrapper",
					AlternateForm = "1971 Front End Loader",
					Affiliation = Affiliation.Decepticon,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Bonecrusher",
					AlternateForm = "1972 Bulldozer",
					Affiliation = Affiliation.Decepticon,
					Rating = 4
				},
				new Transformer()
				{
					Name = "Long Haul",
					AlternateForm = "1973 Dump truck",
					Affiliation = Affiliation.Decepticon,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Scavenger",
					AlternateForm = "1974 Excavator",
					Affiliation = Affiliation.Decepticon,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Mixmaster",
					AlternateForm = "1975 Cement Truck",
					Affiliation = Affiliation.Decepticon,
					Rating = 3
				},
				new Transformer()
				{
					Name = "Lockdown",
					AlternateForm = "Lamborghini Aventador",
					Affiliation = Affiliation.Decepticon,
					Rating = 4
				},

			}.OrderByDescending(t => t.Rating).ToList();
		}
	}
}