using System;
using System.ComponentModel;
using GFramework.Controls;
using StreetFoodTracker.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(GButton),typeof(GButtonRender))]
namespace StreetFoodTracker.iOS.Renders
{
	//http://stackoverflow.com/questions/30270979/xamarin-forms-how-can-i-add-padding-to-a-button
	public class GButtonRender : ButtonRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);
			UpdatePadding ();
		}

		private void UpdatePadding ()
		{
			var element = this.Element as GButton;
			if (element != null) {
				this.Control.ContentEdgeInsets = new UIEdgeInsets (

					(int)element.Padding.Top,
					(int)element.Padding.Left,
					(int)element.Padding.Bottom,
					(int)element.Padding.Right
				);
			}
		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == nameof (GButton.Padding)) {
				UpdatePadding ();
			}
		}
	}
}
