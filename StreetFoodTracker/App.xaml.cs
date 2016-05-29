using System;
using System.Collections.Generic;

using Xamarin.Forms;
using StreetFoodTracker.Infrastructure;

namespace StreetFoodTracker
{
	public partial class App : Application
	{
		public App()
		{
			var bootstraper = new AppBootstrapper ();

			bootstraper.Run(this);
		}
	}
}

