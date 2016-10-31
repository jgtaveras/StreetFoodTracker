using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GFramework.Core;
using GFramework.Services.Navigation.MVFirst;
using StreetFoodTracker.Data.Repositories;
using StreetFoodTracker.Features.AppInfo;
using StreetFoodTracker.Features.StreetFoodLocationDetail;
using Xamarin.Forms;

namespace StreetFoodTracker.Features.StreetFoodLocations
{
	public class StreetFoodLocationsViewModel : ViewModelBase
	{
		readonly INavigationService _navigationService;
		readonly IPlaceRepository _placesRepository;

		public StreetFoodLocationsViewModel (INavigationService navigationService, IPlaceRepository placesRepository)
		{
			Title = "Locations";

			_placesRepository = placesRepository;
			_navigationService = navigationService;
			GetLatestLocations = new Command (async () => await OnGetLatestLocations ());
			NavigateToLocationDetail = new Command<StreetFoodLocationItemViewModel> (OnNavigateToLocationDetail);

		//	if (GetLatestLocations.CanExecute (null)) {
		//		GetLatestLocations.Execute (null);
		//	}
		}

		ObservableCollection<StreetFoodLocationItemViewModel> _locations;
		public ObservableCollection<StreetFoodLocationItemViewModel> LocationsList {
			get { return _locations; }

			set { SetProperty (ref _locations, value); }
		}

		public ICommand GetLatestLocations { get; set; }

		public ICommand NavigateToLocationDetail { get; set; }

		async void OnNavigateToLocationDetail (StreetFoodLocationItemViewModel itemSelected)
		{
			if (itemSelected != null) {
				var locationVmSelected = LocationsList.FirstOrDefault (p => p.Name == itemSelected.Name);

				var location = new Data.Models.Place {
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

			var places = await _placesRepository.GetAll ();

			var locations = from p in places
							from l in p.Locations
							select new StreetFoodLocationItemViewModel {
								LocationId = l.Id,
								Name = p.Name

							};

			LocationsList.Clear ();
			foreach (var item in locations) {
				LocationsList.Add (item);
			}

			//TODO: Catch no data found exception
			IsBusy = false;
		}
	}
}
