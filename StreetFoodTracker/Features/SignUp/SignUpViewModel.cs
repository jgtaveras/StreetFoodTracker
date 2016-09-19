using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GFramework.Core;
using GFramework.Factory;
using GFramework.Services.Dialog;
using GFramework.Services.Navigation.MVFirst;
using StreetFoodTracker.Features.Home;
using Xamarin.Forms;

namespace StreetFoodTracker.Features.SignUp
{
	public class SignUpViewModel : ViewModelBase
	{
		#region Fields
		string _userEmail;
		string _userPassword;
		INavigationService _navigationService;
		IDialogService _dialogService;
		readonly IViewFactory _viewFactory;

		#endregion

		#region Properties
		public ICommand CreateLocalAccountCommand {
			get;
			set;
		}

		public string UserEmail {
			get {
				return _userEmail;
			}

			set {
				SetProperty(ref _userEmail,value);
			}
		}

		public string UserPassword {
			get {
				return _userPassword;
			}

			set {
				SetProperty (ref _userPassword, value);
			}
		}

	
		#endregion




		public SignUpViewModel (INavigationService navigationService, 
		                        IDialogService dialogService,
		                       	IViewFactory viewFactory
		                       )
		{
			this._viewFactory = viewFactory;
			this._dialogService = dialogService;
			_navigationService = navigationService;
			CreateLocalAccountCommand = new Command (async () => {
				await OnCreateLocalAccount ();
			});
		}



		async Task OnCreateLocalAccount ()
		{
			if (string.IsNullOrEmpty (_userEmail) || string.IsNullOrEmpty (_userPassword)) {
				await _dialogService.DisplayAlert ("Sign Up Error", "Please complete all the fields", "Ok");
			} else {
				var mainScreen = _viewFactory.Resolve<HomeScreenViewModel> ();
				Application.Current.MainPage = mainScreen;
			}
		}

	}
}

