using System;
using GFramework.Core;
using GFramework.Services.Navigation.MVFirst;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using GFramework.Factory;
using System.Collections.ObjectModel;

namespace StreetFoodTracker.Features.OnBoarding
{
	public class OnBoardingViewModel : ViewModelBase
	{
		INavigationService navigationService;
		IViewFactory viewFactory;


		public ICommand GoToSignUpCommand{ get; set; }
		public ObservableCollection<OnBoardingContent> OnBoardingContentList { get; set; }

		public OnBoardingViewModel (INavigationService navigationService, IViewFactory viewFactory)
		{
			this.viewFactory = viewFactory;
			this.navigationService = navigationService;

			GoToSignUpCommand = new Command (async () => { await DoGoToSignUpCommand ();});
			BuildOnBoardingPages ();
		}

		private async Task DoGoToSignUpCommand ()
		{
			Helpers.Settings.HasSeenOnBoarding = true;
			await navigationService.PushAsync<SignUp.SignUpViewModel> (resetNavigationStack: true);
		}

		private void BuildOnBoardingPages () {
			OnBoardingContentList = new ObservableCollection<OnBoardingContent> ();

			OnBoardingContentList.Add (new OnBoarding.OnBoardingContent { 
				BackGroundImageName = "portrait_onboarding_2"
			});

			OnBoardingContentList.Add (new OnBoarding.OnBoardingContent {
				BackGroundImageName = "portrait_onboarding_3",
				IsSkipButtonPresent = true
			});

		}
	}
}

