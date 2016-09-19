using System;
using System.Collections.Generic;
using GFramework.Core;

namespace StreetFoodTracker.Features.Home.DrawerMenu
{
	public class DrawerMenuViewModel : ViewModelBase
	{
		public DrawerMenuViewModel ()
		{
			GenerateOptions ();
		}
		IList<DrawerMenuItemViewModel> _options;

		public IList<DrawerMenuItemViewModel> Options {
			get {
				return _options;
			}

			set {
				SetProperty(ref _options,value);
			}
		}

		void GenerateOptions ()
		{
			if (Options == null)
				Options = new List<DrawerMenuItemViewModel> ();
			
			Options.Add (new DrawerMenuItemViewModel { 
				OptionTitle = "Option 1",
				Image="Image 1"
			});

			Options.Add (new DrawerMenuItemViewModel { 
				OptionTitle = "Option 2",
				Image="Image 2"
			});

			Options.Add (new DrawerMenuItemViewModel {
				OptionTitle = "Option 3",
				Image = "Image 3"
			});

			Options.Add (new DrawerMenuItemViewModel {
				OptionTitle = "Option 4",
				Image = "Image 4"
			});

		}

	}
}
