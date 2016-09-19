using System;
using GFramework.Core;
using StreetFoodTracker.Features.Home.DrawerMenu;

namespace StreetFoodTracker.Features.Home
{
	public class HomeScreenViewModel : ViewModelBase
	{


		public HomeScreenViewModel ()
		{
			Drawer = new DrawerMenuViewModel ();
		}
		DrawerMenuViewModel _drawer;

		public DrawerMenuViewModel Drawer {
			get {
				return _drawer;
			}

			set {
				SetProperty(ref _drawer, value);
			}
		}
	}
}

