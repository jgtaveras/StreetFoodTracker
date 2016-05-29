using System;
using GFramework.Bootstrapping;
using Autofac;
using GFramework.Factory;
using StreetFoodTracker.Main;


namespace StreetFoodTracker.Infrastructure
{
	public class AppBootstrapper : BootstrapperBase
	{
		#region implemented abstract members of BootstrapperBase

		protected override void RegisterViews (GFramework.Factory.IViewFactory viewFactory)
		{
			viewFactory.Register<HomeScreenViewModel, HomeScreen> ();
			viewFactory.Register<OnBoarding.OnBoardingScreenViewModel, OnBoarding.OnBoardingScreen> ();
		}

		protected override void ConfigureApplication (IContainer container, Xamarin.Forms.Application app)
		{
			var viewFactory = container.Resolve<IViewFactory> ();
			var mainPage = viewFactory.Resolve<HomeScreenViewModel> ();

			app.MainPage = mainPage;

		}

		protected override void ConfigureContainer (ContainerBuilder builder)
		{
			base.ConfigureContainer (builder);

			builder.RegisterModule<StreetFoodTrackerAutofacModule> ();
		}

		#endregion

	}
}

