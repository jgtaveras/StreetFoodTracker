using System;
using Autofac;

namespace StreetFoodTracker.Infrastructure
{
	public class StreetFoodTrackerAutofacModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			LoadViews (builder);
			LoadViewModels (builder);
		}

		void LoadViews (ContainerBuilder builder)
		{
			builder.RegisterType<Main.HomeScreen> ().SingleInstance ();
			builder.RegisterType<OnBoarding.OnBoardingScreen> ().SingleInstance ();
		}

		void LoadViewModels (ContainerBuilder builder)
		{
			builder.RegisterType<Main.HomeScreenViewModel> ().SingleInstance ();
			builder.RegisterType<OnBoarding.OnBoardingScreenViewModel> ().SingleInstance ();		
		}
	}
}

