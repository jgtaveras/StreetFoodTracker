using System;
using System.Collections.Generic;
using StreetFoodTracker.Features.OnBoarding.DotBottons;
using Xamarin.Forms;
using System.Collections;
using System.Linq;

namespace StreetFoodTracker.Features.OnBoarding
{
	public partial class OnBoardingScreen : ContentPage
	{
		public OnBoardingScreen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
		}

		void Handle_PositionSelected (object sender, Xamarin.Forms.SelectedPositionChangedEventArgs e)
		{
				var selected = e.SelectedPosition;
				var position = (int)selected;
				//Set all buttons opacity to 0.5 but the selected one, which we set to 1
				for (int i = 0; i < dotsControl.dots.Length; i++)
					if (position == i)
						dotsControl.dots [i].Opacity = 1;
					else
						dotsControl.dots [i].Opacity = 0.5;
		}

	}
}

