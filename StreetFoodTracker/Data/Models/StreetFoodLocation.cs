using System;
using System.Collections.Generic;

namespace StreetFoodTracker.Data.Models
{
	public class StreetFoodLocation
	{
		public int Id {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Location {
			get;
			set;
		}

		public string CoverImageURL {
			get;
			set;
		}

		public string PinImageUrl {
			get;
			set;
		}

		public bool IsOpen {
			get;
			set;
		}

		public double Latitude {
			get;
			set;
		}

		public double Longitude {
			get;
			set;
		}



	}
}
