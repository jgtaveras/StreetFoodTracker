using System;
using Xamarin.Forms;

namespace GFramework.Controls
{
	public class GButton : Button
	{
		public GButton ()
		{

		}
/*
		public static BindableProperty PaddingProperty = 
			BindableProperty.Create (
				nameof (Padding), 
				typeof (Thickness), 
				typeof (GButton), 
				defaultValue: null,
				defaultBindingMode: BindingMode.OneWay);
*/
		public static readonly BindableProperty PaddingProperty =
			BindableProperty.Create<GButton, Thickness> (
				p => p.Padding, new Thickness(0));

		public Thickness Padding 
		{ 
			get { return (Thickness)GetValue (PaddingProperty); } 
			set { SetValue (PaddingProperty, value); }
		}


	}
}
