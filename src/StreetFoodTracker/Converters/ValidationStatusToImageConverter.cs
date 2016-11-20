using System;
using System.Globalization;
using GFramework.Core.Enums;
using Xamarin.Forms;

namespace StreetFoodTracker.Converters
{
	public class ValidationStatusToImageConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			var validationStatus = (ValidationStatus)value;

			switch (validationStatus) {
			case ValidationStatus.Pass:
				return "passValidation";
			case ValidationStatus.Fail:
				return "failValidation";
			default:
				return "";
			}
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}

