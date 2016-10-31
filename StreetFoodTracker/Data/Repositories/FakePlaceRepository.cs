using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreetFoodTracker.Data.Models;

namespace StreetFoodTracker.Data.Repositories
{
	public class FakePlaceRepository : IPlaceRepository
	{

		public async Task<List<Place>> GetAll ()
		{
			await Task.Delay (3000);

			var result = Task.Run (() => {
				var locations = new List<Place> ();

				locations.Add (PlaceFactory.Create ("Wicho a very long name this is"));
				locations.Add (PlaceFactory.Create ("Los Jefes"));
				locations.Add (PlaceFactory.Create ("El Chapo"));
				locations.Add (PlaceFactory.Create ("Oveja Negra"));
				locations.Add (PlaceFactory.Create ("El Chapo"));
				locations.Add (PlaceFactory.Create ("Cuates"));
				locations.Add (PlaceFactory.Create ("Don Camarón"));
				locations.Add (PlaceFactory.Create ("Gigi Delicias Argentinas"));
				locations.Add (PlaceFactory.Create ("Media Noche Cuban Café"));
				locations.Add (PlaceFactory.Create ("Rinconcito de los García"));
				locations.Add (PlaceFactory.Create ("Sammy Sabor de la India"));
				locations.Add (PlaceFactory.Create ("Shaggy's Grill"));
				locations.Add (PlaceFactory.Create ("KogiTruck"));
				locations.Add (PlaceFactory.Create ("Hillbilly's Foodtruck"));
				locations.Add (PlaceFactory.Create ("Papiao Foodtruck"));

				return locations;

			});

			return await result;
		}


	}

	//TODO: Temp implementation
	public static class PlaceFactory
	{
		public static Place Create (string locationName)
		{
			var rnd = new Random ();

			var locationId = rnd.Next (1, 100000);
			var placeId = rnd.Next (1, 10000);
			var trailingImg = rnd.Next (20, 60);

			return new Place {
				Id = placeId,

				Name = locationName,
				PinImageUrl = "",
				CoverImageURL = $"http://loremflickr.com/640/{trailingImg}",
				InstagramHandler = "",
				IsPremiun = true,
				Locations = new List<Location> {
						new Location {
							Id = locationId,
							PlaceId = placeId,
							Address="Avenida Gustavo Mejia Ricart 62-66, Santo Domingo",
							Latitude = 18.4758475,
							Longitude = -69.9316334,
							IsOpen = true,
							IsMainLocation = true
						}
					}
			};
		}
	}
}
