// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace StreetFoodTracker.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings {
			get {
				return CrossSettings.Current;
			}
		}

		const string HasSeenOnBoardingKey = "hasSeenOnBoarding_Key";
		public static bool HasSeenOnBoarding {
			get {
				return AppSettings.GetValueOrDefault<bool> (HasSeenOnBoardingKey, false);
			}
			set {
				AppSettings.AddOrUpdateValue<bool> (HasSeenOnBoardingKey, value);
			}
		}


	}
}