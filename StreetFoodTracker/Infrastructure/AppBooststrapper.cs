using System;
using GFramework.Bootstrapping;
using Autofac;
using GFramework.Factory;
using StreetFoodTracker.Features.Home;
using StreetFoodTracker.Features.OnBoarding;
using StreetFoodTracker.Features.SignUp;
using Xamarin.Forms;
using StreetFoodTracker.Features.Home.DrawerMenu;
using StreetFoodTracker.Features.TempTest;

namespace StreetFoodTracker.Infrastructure
{
	public class AppBootstrapper : BootstrapperBase
	{
		#region implemented abstract members of BootstrapperBase

		protected override void RegisterViews (GFramework.Factory.IViewFactory viewFactory)
		{
			viewFactory.Register<HomeScreenViewModel, HomeScreen> ();
			viewFactory.Register<OnBoardingViewModel, OnBoardingScreen> ();
			viewFactory.Register<SignUpViewModel, SignUpScreen> ();
			viewFactory.Register<DrawerMenuViewModel, DrawerMenuScreen> ();

			viewFactory.Register<SamplePage1ViewModel, SamplePage1> ();
			viewFactory.Register<SamplePage2ViewModel, SamplePage2> ();
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

			//app.MainPage = new NavigationPage(mainPage);
			app.MainPage = viewFactory.Resolve<HomeScreenViewModel> ();

		}

		#endregion

	}
}

