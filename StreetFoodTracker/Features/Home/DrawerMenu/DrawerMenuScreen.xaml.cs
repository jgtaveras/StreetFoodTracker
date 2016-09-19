using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StreetFoodTracker.Features.Home.DrawerMenu
{
	public partial class DrawerMenuScreen : ContentPage
	{

		public ListView DrawerOptions { get { return drawerOptions;} }

		public DrawerMenuScreen ()
		{
			InitializeComponent ();

		}
	}
}

