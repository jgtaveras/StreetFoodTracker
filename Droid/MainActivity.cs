using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using FFImageLoading;

namespace StreetFoodTracker.Droid
{
	[Activity (Label = "Street Food Tracker", 
	           Icon = "@drawable/icon", 
	           Theme = "@style/SFTTheme",
	           ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
			FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

			base.OnCreate (bundle);

			FFImageLoading.Forms.Droid.CachedImageRenderer.Init ();

			var config = new FFImageLoading.Config.Configuration () {
				VerboseLogging = false,
				VerbosePerformanceLogging = false,
				VerboseMemoryCacheLogging = false,
				VerboseLoadingCancelledLogging = false,
				Logger = new CustomLogger (),
				FadeAnimationEnabled=true,
				FadeAnimationForCachedImages=true
			};
			ImageService.Instance.Initialize (config);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			Xamarin.FormsMaps.Init (this, bundle);
			LoadApplication (new App ());
		}
	}

	public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
	{
		public void Debug (string message)
		{
			Console.WriteLine (message);
		}

		public void Error (string errorMessage)
		{
			Console.WriteLine (errorMessage);
		}

		public void Error (string errorMessage, Exception ex)
		{
			Error (errorMessage + System.Environment.NewLine + ex.ToString ());
		}
	}
}

