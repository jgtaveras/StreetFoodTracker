using System;
using GFramework.Core;

namespace StreetFoodTracker.Features.StreetFoodLocations
{
	public class StreetFoodLocationItemViewModel : ViewModelBase
	{
		int _locationId;
		public int LocationId {
			get { return _locationId; }
			set { SetProperty (ref _locationId, value); }
		}

		string _name;
		public string Name {
			get { return _name; }
			set { SetProperty (ref _name, value); }
		}

		string _coverImageURL;
		public string CoverImageURL {
			get { return _coverImageURL; }
			set { SetProperty (ref _coverImageURL, value); }
		}


	}
}
