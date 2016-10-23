using System;
using GFramework.Core;
using StreetFoodTracker.Data.Models;

namespace StreetFoodTracker.Features.StreetFoodLocationDetail
{
	public class StreetFoodLocationDetailViewModel : ViewModelBase
	{
		public StreetFoodLocationDetailViewModel ()
		{
			
		}

		StreetFoodLocation _location;
		public StreetFoodLocation Location {
			get {
				return _location;
			}

			set {
				SetProperty (ref _location, value);
			}
		}
	}
}
