using System;
using GFramework.Bootstrapping;
using Autofac;
using GFramework.Factory;
using StreetFoodTracker.Features.Home;
using StreetFoodTracker.Features.OnBoarding;
using StreetFoodTracker.Features.SignUp;
using Xamarin.Forms;

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

			//if (Helpers.Settings.HasSeenOnBoarding) {
			//	mainPage = viewFactory.Resolve<SignUpViewModel> ();
			//} else {
				mainPage = viewFactory.Resolve<OnBoardingViewModel> ();
			//}

			//app.MainPage = new NavigationPage(mainPage);
			app.MainPage = new HomeScreen ();

		}

		#endregion

	}
}

