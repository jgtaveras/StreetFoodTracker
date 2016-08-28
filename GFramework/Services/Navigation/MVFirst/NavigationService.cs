using System;
using Xamarin.Forms;
using GFramework.Core;
using GFramework.Factory;
using GFramework.Services.Dialog;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GFramework.Services.Navigation.MVFirst
{
	public class NavigationService : INavigationService
	{
		private readonly IPage _page;
		private readonly IViewFactory _viewFactory;

		public NavigationService(IPage page , IViewFactory viewFactory)
		{
			_page = page;
			_viewFactory = viewFactory;
		}

		private INavigation Navigation
		{
			get { return _page.Navigation; }
		}

		public async Task<IViewModel> PopAsync()
		{
			Page view = await Navigation.PopAsync();
			return view.BindingContext as IViewModel;
		}

		public async Task<IViewModel> PopModalAsync()
		{
			Page view = await Navigation.PopModalAsync();
			return view.BindingContext as IViewModel;
		}

		public async Task PopToRootAsync()
		{
			await Navigation.PopToRootAsync();
		}

		public async Task<TViewModel> PushAsync<TViewModel> (Action<TViewModel> setStateAction = null, bool resetNavigationStack = false) 
			where TViewModel : class, IViewModel
		{
			TViewModel viewModel;
			var view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);

			await Navigation.PushAsync(view);

			if (resetNavigationStack) {
				ResetNavigationStack (view);;
			}

			return viewModel;
		}

		public async Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel, bool resetNavigationStack = false) 
			where TViewModel : class, IViewModel
		{
			var view = _viewFactory.Resolve(viewModel);
			await Navigation.PushAsync(view);

			if (resetNavigationStack) {
				ResetNavigationStack (view);
			}
			return viewModel;
		}

		public async Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel
		{
			TViewModel viewModel;
			var view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);
			await Navigation.PushModalAsync(view);


			return viewModel;
		}

		public async Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel
		{
			var view = _viewFactory.Resolve(viewModel);
			await Navigation.PushModalAsync(view);
			return viewModel;
		}


		private void ResetNavigationStack (Page currentPage) { 
			var existingPages = Navigation.NavigationStack
			                              .Where(p => !p.Equals(currentPage))
			                              .ToList ();
			foreach (var page in existingPages) {
				Navigation.RemovePage (page); 
			} 
		}
	}
}

