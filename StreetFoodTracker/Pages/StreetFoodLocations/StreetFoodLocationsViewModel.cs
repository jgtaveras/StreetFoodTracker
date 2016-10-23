using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GFramework.Core;
using GFramework.Services.Navigation.MVFirst;
using StreetFoodTracker.Features.AppInfo;
using StreetFoodTracker.Features.StreetFoodLocationDetail;
using Xamarin.Forms;

namespace StreetFoodTracker.Features.StreetFoodLocations
{
	public class StreetFoodLocationsViewModel : ViewModelBase
	{
		readonly INavigationService _navigationService;

		public StreetFoodLocationsViewModel (INavigationService navigationService)
		{
			_navigationService = navigationService;
			Title = "Locations";
			GetLatestLocations = new Command (async () => await OnGetLatestLocations());
			NavigateToLocationDetail = new Command<StreetFoodLocationItemViewModel> (OnNavigateToLocationDetail);
			GenerateTempData ();
		}

		ObservableCollection<StreetFoodLocationItemViewModel> _locations;
		public ObservableCollection<StreetFoodLocationItemViewModel> Locations {
			get { return _locations; }

			set { SetProperty (ref _locations, value); }
		}

		public ICommand GetLatestLocations { get; set;}

		public ICommand NavigateToLocationDetail { get; set; }

		void GenerateTempData ()
		{

			Locations = new ObservableCollection<StreetFoodLocationItemViewModel> ();
			Locations.Add (new StreetFoodLocationItemViewModel { 
				Name = "Wicho a very long name this is" ,
				CoverImageURL="http://loremflickr.com/640/340"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "El Chapo",
				CoverImageURL = "http://loremflickr.com/640/341"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Foodtruck",
				CoverImageURL = "http://loremflickr.com/640/342"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Los Jefes",
				CoverImageURL = "http://loremflickr.com/640/343"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Oveja Negra",
				CoverImageURL = "http://loremflickr.com/640/344"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "El Chapo",
				CoverImageURL = "http://loremflickr.com/640/345"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Foodtruck",
				CoverImageURL = "http://loremflickr.com/640/346"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Los Jefes",
				CoverImageURL = "http://loremflickr.com/640/347"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Oveja Negra",
				CoverImageURL = "http://loremflickr.com/641/340"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "El Chapo",
				CoverImageURL = "http://loremflickr.com/641/341"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Foodtruck",
				CoverImageURL = "http://loremflickr.com/641/342"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Los Jefes",
				CoverImageURL = "http://loremflickr.com/641/343"
			});

			Locations.Add (new StreetFoodLocationItemViewModel {
				Name = "Oveja Negra",
				CoverImageURL = "http://loremflickr.com/641/344"
			});
		}

		async void OnNavigateToLocationDetail (StreetFoodLocationItemViewModel itemSelected)
		{
			if (itemSelected != null) {
				var locationVmSelected = Locations.FirstOrDefault (p => p.Name == itemSelected.Name);

					var location = new Data.Models.StreetFoodLocation {
						Id = 1,
						Name = locationVmSelected.Name,
						CoverImageURL = locationVmSelected.CoverImageURL
					};

					await _navigationService
						.PushAsync<StreetFoodLocationDetailViewModel> (vm => {
							vm.Title = location.Name;
							vm.Location = location;
						});
				}

		}

		async Task OnGetLatestLocations ()
		{
			IsBusy = true;

			await Task.Delay (4000);

			IsBusy = false;
		}
	}
}
