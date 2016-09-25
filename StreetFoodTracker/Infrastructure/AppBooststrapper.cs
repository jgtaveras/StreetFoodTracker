using System;
using GFramework.Bootstrapping;
using Autofac;
using GFramework.Factory;
using StreetFoodTracker.Features.OnBoarding;
using StreetFoodTracker.Features.SignUp;
using Xamarin.Forms;
using StreetFoodTracker.Features.MainPage;
using StreetFoodTracker.Features.FavoriteLocations;
using StreetFoodTracker.Features.StreetFoodLocations;

namespace StreetFoodTracker.Infrastructure
{
	public class AppBootstrapper : BootstrapperBase
	{
		#region implemented abstract members of BootstrapperBase

		protected override void RegisterViews (IViewFactory viewFactory)
		{
			viewFactory.Register<OnBoardingViewModel, OnBoardingScreen> ();
			viewFactory.Register<SignUpViewModel, SignUpScreen> ();
			viewFactory.Register<MainPageViewModel, MainPageScreen> ();
			viewFactory.Register<FavoriteLocationsViewModel, FavoriteLocationsScreen> ();
			viewFactory.Register<StreetFoodLocationsViewModel, StreetFoodLocationsListScreen> ();
		}



		protected override void ConfigureContainer (ContainerBuilder builder)
		{
			base.ConfigureContainer (builder);

			builder.RegisterModule<StreetFoodTrackerAutofacModule> ();
		}

		protected override void ConfigureApplication (IContainer container, Xamarin.Forms.Application app)
		{
			var viewFactory = container.Resolve<IViewFactory> ();

			Page mainPage = null;

			if (Helpers.Settings.HasSeenOnBoarding) {
				mainPage = viewFactory.Resolve<SignUpViewModel> ();
			} else {
				mainPage = viewFactory.Resolve<OnBoardingViewModel> ();
			}

			app.MainPage = viewFactory.Resolve<MainPageViewModel> ();

		}

		#endregion

	}
}

