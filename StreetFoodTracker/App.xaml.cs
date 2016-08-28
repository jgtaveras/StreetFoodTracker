using System;
using System.Collections.Generic;

using Xamarin.Forms;
using StreetFoodTracker.Infrastructure;
using StreetFoodTracker.Converters;

namespace StreetFoodTracker
{
	public partial class App : Application
	{
		public App ()
		{
			RegisterConveters ();
			RegisterStyles ();

			var bootstraper = new AppBootstrapper ();

			bootstraper.Run (this);
		}

		void RegisterConveters ()
		{
			if (Current.Resources == null) {
				Current.Resources = new ResourceDictionary ();
			}

			Current.Resources.Add ("validationStatusToImage", new ValidationStatusToImageConverter ());
		}

		void RegisterStyles ()
		{
			if (Current.Resources == null) {
					Current.Resources = new ResourceDictionary ();
			}

			var signUpInputs = new Style (typeof (Entry)) {
				Setters = {
					new Setter{
						Property = Entry.PlaceholderColorProperty ,
						Value = Color.FromHex("#353535")
					},
					new Setter {
						Property = Entry.TextColorProperty,
						Value = Color.FromHex("#353535")
					},
					new Setter {
						Property = Entry.HorizontalOptionsProperty,
						Value = LayoutOptions.FillAndExpand
					}
				}
			};



			Current.Resources.Add ("signUpInputs", signUpInputs);


		}
	}
}

