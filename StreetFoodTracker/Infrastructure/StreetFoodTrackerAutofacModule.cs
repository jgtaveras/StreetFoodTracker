using System;
using Autofac;
using StreetFoodTracker.Features.Home;
using StreetFoodTracker.Features.OnBoarding;
using StreetFoodTracker.Features.SignUp;

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
			builder.RegisterType<HomeScreen> ().SingleInstance ();
			builder.RegisterType<OnBoardingScreen> ().SingleInstance ();
			builder.RegisterType<SignUpScreen> ().SingleInstance ();
		}

		void LoadViewModels (ContainerBuilder builder)
		{
			builder.RegisterType<HomeScreenViewModel> ().SingleInstance ();
			builder.RegisterType<OnBoardingViewModel> ().SingleInstance ();
			builder.RegisterType<SignUpViewModel> ().SingleInstance ();
		}
	}
}

