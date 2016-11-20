using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreetFoodTracker.Data.Models;

namespace StreetFoodTracker.Data.Repositories
{

	//TODO: Temp implementation

	public interface IPlaceRepository
	{
		Task<List<Place>> GetAll ();
	}
}
