using System;
using GFramework.Core;
using GFramework.Services.Navigation.MVFirst;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using GFramework.Factory;

namespace StreetFoodTracker.Features.OnBoarding
{
	public class OnBoardingViewModel : ViewModelBase
	{
		INavigationService navigationService;
		IViewFactory viewFactory;


		public ICommand GoToSignUpCommand{ get; set; }

		public OnBoardingViewModel (INavigationService navigationService, IViewFactory viewFactory)
		{
			this.viewFactory = viewFactory;
			this.navigationService = navigationService;

			GoToSignUpCommand = new Command (DoGoToSignUpCommand);
		}

		private void DoGoToSignUpCommand ()
		{
			var view = viewFactory.Resolve<SignUp.SignUpViewModel> ();

			Application.Current.MainPage = new NavigationPage (view);

			//await navigationService.PushAsync<SignUp.SignUpViewModel> ();
		}
	}
}

