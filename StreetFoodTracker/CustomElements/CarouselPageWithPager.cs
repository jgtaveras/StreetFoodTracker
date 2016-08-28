using System;
using Xamarin.Forms;

namespace StreetFoodTracker.CustomElements
{
	public class CarouselPageWithPager : CarouselPage
	{
		public static readonly BindableProperty IsPagerVisibleProperty =
			BindableProperty.Create<CarouselPageWithPager, bool>(
				p => p.IsPagerVisible, true);

		public static readonly BindableProperty PagerItemColorProperty =
			BindableProperty.Create<CarouselPageWithPager, Color>(
				p => p.PagerItemColor, Color.Default);

		public static readonly BindableProperty SelectedPagerItemColorProperty =
			BindableProperty.Create<CarouselPageWithPager, Color>(
				p => p.SelectedPagerItemColor, Color.Default);

		public static readonly BindableProperty PagerMinimumWidthProperty =
			BindableProperty.Create<CarouselPageWithPager, double>(
				p => p.PagerMinimumWidth, 0);

		public static readonly BindableProperty PagerPaddingProperty =
			BindableProperty.Create<CarouselPageWithPager, Thickness>(
				p => p.PagerPadding, new Thickness(0, 0, 0, 30));

		public static readonly BindableProperty PagerXAlignProperty =
			BindableProperty.Create<CarouselPageWithPager, TextAlignment>(
				p => p.PagerXAlign, TextAlignment.Center);

		public static readonly BindableProperty PagerYAlignProperty =
			BindableProperty.Create<CarouselPageWithPager, TextAlignment>(
				p => p.PagerYAlign, TextAlignment.End);

		public bool IsPagerVisible
		{
			get { return (bool)GetValue(IsPagerVisibleProperty); }
			set { SetValue(IsPagerVisibleProperty, value); }
		}

		public Color PagerItemColor
		{
			get { return (Color)GetValue(PagerItemColorProperty); }
			set { SetValue(PagerItemColorProperty, value); }
		}

		public Color SelectedPagerItemColor
		{
			get { return (Color)GetValue(SelectedPagerItemColorProperty); }
			set { SetValue(SelectedPagerItemColorProperty, value); }
		}

		public double PagerMinimumWidth
		{
			get { return (double)GetValue(PagerMinimumWidthProperty); }
			set { SetValue(PagerMinimumWidthProperty, value); }
		}

		public Thickness PagerPadding
		{
			get { return (Thickness)base.GetValue(PagerPaddingProperty); }
			set { base.SetValue(PagerPaddingProperty, value); }
		}

		public TextAlignment PagerXAlign
		{
			get { return (TextAlignment)base.GetValue(PagerXAlignProperty); }
			set { base.SetValue(PagerXAlignProperty, value); }
		}

		public TextAlignment PagerYAlign
		{
			get { return (TextAlignment)base.GetValue(PagerYAlignProperty); }
			set { base.SetValue(PagerYAlignProperty, value); }
		}
	}
}

