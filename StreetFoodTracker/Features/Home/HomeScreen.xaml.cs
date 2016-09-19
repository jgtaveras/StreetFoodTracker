using System;
using System.Collections.Generic;
using GFramework.Services.Navigation.MVFirst;
using StreetFoodTracker.Features.Home.DrawerMenu;
using Xamarin.Forms;

namespace StreetFoodTracker.Features.Home
{
	public partial class HomeScreen : MasterDetailPage
	{
		readonly INavigationService _navigationService;

		public HomeScreen (INavigationService navigationService)
		{
			_navigationService = navigationService;
			InitializeComponent ();

			drawerScreen.DrawerOptions.ItemSelected += DrawerOptions_ItemSelected;
		}



		void DrawerOptions_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as DrawerMenuItemViewModel;
			if (item != null) {

				var x = Detail as NavigationPage;
				if (x != null) {
					x.PushAsync (new TempTest.SamplePage1 ());
				}

				IsPresented = false;
			}

			drawerScreen.DrawerOptions.SelectedItem = null;
		}
	}
}
