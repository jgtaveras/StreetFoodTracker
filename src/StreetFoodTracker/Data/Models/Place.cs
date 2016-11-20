using System;
using System.Collections.Generic;

namespace StreetFoodTracker.Data.Models
{
	public class Place
	{
		public int Id {
			get;
			set;
		}

		public string Name {
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


		public List<Location> Locations {
			get;
			set;
		}

		public bool IsPremiun {
			get;
			set;
		}

		public string InstagramHandler {
			get;
			set;
		}

	}
}
