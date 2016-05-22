using System;
using GFramework.Core;
using System.Threading.Tasks;

namespace GFramework.Services.Navigation.MVFirst
{
	public interface INavigationService
	{
		Task<IViewModel> PopAsync();

		Task<IViewModel> PopModalAsync();

		Task PopToRootAsync();

		Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel;

		Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel;

		Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel;

		Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel;
	}
}

