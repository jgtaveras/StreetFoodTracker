using System;
using Xamarin.Forms;

namespace StreetFoodTracker.Features.OnBoarding.DotBottons
{
	//Implemntation: https://hot-totem.com/blog/post/carouselview-pageindicators-xamarinforms
	public class DotButtonsControl : StackLayout
	{
		public DotButton [] dots;

		public DotButtonsControl ()
		{
			//Temp
			var dotCount = 2;
			var dotColor = Color.White;
			var dotSize = 10;
			
			dots = new DotButton [dotCount];
			Orientation = StackOrientation.Horizontal;
			VerticalOptions = LayoutOptions.Center;
			HorizontalOptions = LayoutOptions.Center;

			for (int i = 0; i < dotCount; i++) {
				dots [i] = new DotButton {
					HeightRequest = dotSize,
					WidthRequest = dotSize,
					BackgroundColor = dotColor,
					Opacity = 0.5
				};
				dots [i].index = i;
				dots [i].layout = this;
				Children.Add (dots [i]);
			}
			dots [0].Opacity = 1;

		}
	}
}

