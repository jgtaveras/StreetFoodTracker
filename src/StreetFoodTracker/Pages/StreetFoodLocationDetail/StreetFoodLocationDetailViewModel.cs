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

		Place _location;
		public Place Location {
			get {
				return _location;
			}

			set {
				SetProperty (ref _location, value);
			}
		}
	}
}
