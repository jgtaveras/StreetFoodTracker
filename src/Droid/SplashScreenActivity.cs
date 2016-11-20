
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace StreetFoodTracker.Droid
{
	[Activity (Theme="@style/SFTTheme.Splash", MainLauncher=true, NoHistory=true)]
	public class SplashScreenActivity : Activity
	{
		static readonly string TAG = "X:" + typeof(SplashScreenActivity).Name;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			Log.Debug (TAG, "SplashScreenActivity.OnCreate");
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			Task bootstrappingWork = new Task (() => {
				Log.Debug (TAG, "Starting bootstraping work!!");
				Task.Delay (5000);
				Log.Debug (TAG, "Working in the background");
			});

			bootstrappingWork.ContinueWith ((t) => {
				Log.Debug (TAG, "WorkFinish go to mainactivity");
				StartActivity (new Intent (Application.Context, typeof (MainActivity)));
				
			}, TaskScheduler.FromCurrentSynchronizationContext());

			bootstrappingWork.Start ();
		}
	}
}

