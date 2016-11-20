namespace StreetFoodTracker.Data.Models
{
	public class Location
	{
		public int Id {
			get;
			set;
		}

		public Place Place {
			get;
			set;
		}

		public int PlaceId {
			get;
			set;
		}

		public bool IsOpen {
			get;
			set;
		}

		public bool IsMainLocation {
			get;
			set;
		}

		public string Address {
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