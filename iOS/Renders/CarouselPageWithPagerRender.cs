using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using StreetFoodTracker.CustomElements;
using StreetFoodTracker.iOS.Renders;


[assembly:ExportRenderer(typeof(CarouselPageWithPager),typeof(CarouselPageWithPagerRender))]
namespace StreetFoodTracker.iOS.Renders
{
	public class CarouselPageWithPagerRender : CarouselPageRenderer
	{
		private bool _currentPageSetByUser = false;
		private CarouselPageWithPager _carouselPageWithPager;
		private UIPageControl _uiPageControl;
		private UIView _view;

		private void OnPagedCarouselPagePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "IsPagerVisible":
				_uiPageControl.Hidden = !_carouselPageWithPager.IsPagerVisible;
				break;
			case "PagerItemColor":
				SetPageIndicatorTintColor();
				break;
			case "SelectedPagerItemColor":
				SetCurrentPageIndicatorTintColor();
				break;
			case "PagerPadding":
			case "PagerXAlign":
			case "PagerYAlign":
				LayoutPageControl();
				break;
			case "CurrentPage":
				if (!_currentPageSetByUser)
					_uiPageControl.CurrentPage = SelectedIndex;
				break;
			}
		}

		private void OnUIPageControlValueChanged(object sender, EventArgs eventArgs)
		{
			_currentPageSetByUser = true;
			_carouselPageWithPager.CurrentPage = _carouselPageWithPager.Children[(int)_uiPageControl.CurrentPage];
			_currentPageSetByUser = false;
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			_uiPageControl.Pages = _carouselPageWithPager.Children.Count;
			_carouselPageWithPager.PagerMinimumWidth = _uiPageControl.SizeForNumberOfPages((int)_uiPageControl.Pages).Width;
			LayoutPageControl();
		}

		private void LayoutPageControl()
		{
			nfloat width = _view.Frame.Width - (nfloat)_carouselPageWithPager.PagerPadding.Left - (nfloat)_carouselPageWithPager.PagerPadding.Right;

			const float HEIGHT = 36f; // default height of the UIPageControl

			nfloat x = 0;
			switch (_carouselPageWithPager.PagerXAlign)
			{
			case TextAlignment.Center:
				if (_view.Frame.Width != width)
					x = (nfloat)_carouselPageWithPager.PagerPadding.Left + (width / 2);

				break;
			case TextAlignment.End:
				x = _view.Frame.Width - width - (float)_carouselPageWithPager.PagerPadding.Right;
				break;
			case TextAlignment.Start:
				x = (float)_carouselPageWithPager.PagerPadding.Left;
				break;
			}

			nfloat y = 0;
			switch (_carouselPageWithPager.PagerYAlign)
			{
			case TextAlignment.Center:
				// ignore top and bottom padding
				y = (_view.Frame.Height - HEIGHT) / 2;
				_uiPageControl.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				break;
			case TextAlignment.End:
				y = _view.Frame.Height - (nfloat)_carouselPageWithPager.PagerPadding.Bottom - HEIGHT;
				_uiPageControl.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
				break;
			case TextAlignment.Start:
				y = (float)_carouselPageWithPager.PagerPadding.Top;
				_uiPageControl.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
				break;
			}

			_uiPageControl.Frame = new CGRect(x, y, width, HEIGHT);
		}

		private void SetCurrentPageIndicatorTintColor()
		{
			_uiPageControl.CurrentPageIndicatorTintColor = _carouselPageWithPager.SelectedPagerItemColor != Color.Default ? _carouselPageWithPager.SelectedPagerItemColor.ToUIColor() : UIColor.White;
		}

		private void SetPageIndicatorTintColor()
		{
			_uiPageControl.PageIndicatorTintColor = _carouselPageWithPager.PagerItemColor != Color.Default ? _carouselPageWithPager.PagerItemColor.ToUIColor() : UIColor.Gray;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				_carouselPageWithPager.PropertyChanged -= OnPagedCarouselPagePropertyChanged;
				_uiPageControl.ValueChanged -= OnUIPageControlValueChanged;
			}
		}

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			_carouselPageWithPager = (CarouselPageWithPager)e.NewElement;
			_view = NativeView;

			_uiPageControl = new UIPageControl ();
			SetPageIndicatorTintColor ();
			SetCurrentPageIndicatorTintColor ();

			_view.Add (_uiPageControl);

			_carouselPageWithPager.PropertyChanged += OnPagedCarouselPagePropertyChanged;
			_uiPageControl.ValueChanged += OnUIPageControlValueChanged;
		}

	}
}

