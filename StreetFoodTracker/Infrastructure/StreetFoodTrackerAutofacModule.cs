﻿using System;
using Autofac;
using StreetFoodTracker.Data.Repositories;
using StreetFoodTracker.Features.AppInfo;
using StreetFoodTracker.Features.FavoriteLocations;
using StreetFoodTracker.Features.MainPage;
using StreetFoodTracker.Features.OnBoarding;
using StreetFoodTracker.Features.SignUp;
using StreetFoodTracker.Features.StreetFoodLocationDetail;
using StreetFoodTracker.Features.StreetFoodLocations;

namespace StreetFoodTracker.Infrastructure
{
	public class StreetFoodTrackerAutofacModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			LoadViews (builder);
			LoadViewModels (builder);
			LoadRepositories (builder);
		}

		void LoadViews (ContainerBuilder builder)
		{
			builder.RegisterType<OnBoardingScreen> ().SingleInstance ();
			builder.RegisterType<SignUpScreen> ().SingleInstance ();
			builder.RegisterType<StreetFoodLocationsListScreen> ().SingleInstance ();
			builder.RegisterType<FavoriteLocationsScreen> ().SingleInstance ();
			builder.RegisterType<AboutScreen> ().SingleInstance ();
			builder.RegisterType<StreetFoodLocationDetailScreen> ().SingleInstance ();
		}

		void LoadViewModels (ContainerBuilder builder)
		{
			builder.RegisterType<MainPageViewModel> ().SingleInstance ();
			builder.RegisterType<OnBoardingViewModel> ().SingleInstance ();
			builder.RegisterType<SignUpViewModel> ().SingleInstance ();
			builder.RegisterType<StreetFoodLocationsViewModel> ().SingleInstance ();
			builder.RegisterType<FavoriteLocationsViewModel> ().SingleInstance ();
			builder.RegisterType<StreetFoodLocationItemViewModel> ();
			builder.RegisterType<AboutViewModel> ().SingleInstance ();
			builder.RegisterType<StreetFoodLocationDetailViewModel> ();
		}

		void LoadRepositories (ContainerBuilder builder) 
		{
			builder.RegisterType<FakePlaceRepository> ().As<IPlaceRepository> ().SingleInstance ();
		}
	}
}

