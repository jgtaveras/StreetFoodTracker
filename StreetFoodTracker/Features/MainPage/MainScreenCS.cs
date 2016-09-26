using System;
using GFramework.Factory;
using StreetFoodTracker.Features.AppInfo;
using StreetFoodTracker.Features.FavoriteLocations;
using StreetFoodTracker.Features.StreetFoodLocations;
using Xamarin.Forms;

namespace StreetFoodTracker.Features.MainPage
{
	public class MainScreenCS : TabbedPage
	{
		readonly IViewFactory _viewFactory;

		public MainScreenCS (IViewFactory viewFactory )
		{
			_viewFactory = viewFactory;
		}

		protected override void OnAppearing ()
		{
			var about = _viewFactory.Resolve<AboutViewModel> ();
			var locations = _viewFactory.Resolve<StreetFoodLocationsViewModel> ();
			var favorites = _viewFactory.Resolve<FavoriteLocationsViewModel> ();

			Children.Add (favorites);
			Children.Add (locations);
			Children.Add (about);

			SelectedItem = locations;
		}
	}
}
