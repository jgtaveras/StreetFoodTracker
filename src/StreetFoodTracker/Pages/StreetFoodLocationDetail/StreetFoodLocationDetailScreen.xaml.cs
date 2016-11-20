using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace StreetFoodTracker.Features.StreetFoodLocationDetail
{
	public partial class StreetFoodLocationDetailScreen : ContentPage
	{
		public StreetFoodLocationDetailScreen ()
		{
			InitializeComponent ();

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			LocationMap.MoveToRegion (
				MapSpan.FromCenterAndRadius (new Position (18.4664172, -69.9503068), 
				                             new Distance (300)
				                            ));
		}
	}
}
