using System;
using System.Globalization;
using Xamarin.Forms;

namespace GFramework.Converters
{
	public class SelectedItemListViewCommandArgsConverter : IValueConverter
	{
		public SelectedItemListViewCommandArgsConverter ()
		{
		}

		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			var eventArgs = value as SelectedItemChangedEventArgs;

			if (eventArgs ==null) {
				return null;
			}

			return eventArgs.SelectedItem;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}
