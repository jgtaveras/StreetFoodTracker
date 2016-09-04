using System;
using Xamarin.Forms;

namespace StreetFoodTracker.Features.OnBoarding.DotBottons
{
	//Implemntation: https://hot-totem.com/blog/post/carouselview-pageindicators-xamarinforms
	 public class DotButton : BoxView
    {
        public int index;
        public DotButtonsControl layout;
        public event ClickHandler Clicked;
        public delegate void ClickHandler(DotButton sender);
        public DotButton()
        {
            var clickCheck = new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                        {
                            if (Clicked != null)
                            {
                                Clicked(this);
                            }
                        })
                };
            GestureRecognizers.Add(clickCheck);
        }
    }
}

