using System;
using System.Text.RegularExpressions;
using GFramework.Core.Enums;
using Xamarin.Forms;

namespace GFramework.Behaviors
{

	//Implementation taken from: https://blog.xamarin.com/behaviors-in-xamarin-forms/
	public class EmailValidatorBehavior : Behavior<Entry>
	{
		const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
	  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

		static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly ("IsValid", typeof (ValidationStatus), typeof (EmailValidatorBehavior), ValidationStatus.NonEvaluated);

		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

		public ValidationStatus IsValid {
			get { return (ValidationStatus)GetValue (IsValidProperty); }
			private set { SetValue (IsValidPropertyKey, value); }
		}

		public Color ValidTextColor { get; set; }

		protected override void OnAttachedTo (Entry bindable)
		{
			base.OnAttachedTo (bindable);
			bindable.TextChanged += HandleTextChanged;
		}

		protected override void OnDetachingFrom (Entry bindable)
		{
			base.OnDetachingFrom (bindable);
			bindable.TextChanged -= HandleTextChanged;

		}


		void HandleTextChanged (object sender, TextChangedEventArgs e)
		{
			var isValid = (Regex.IsMatch (e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds (250)));

			if (isValid) {
				IsValid = ValidationStatus.Pass;
			} else {
				IsValid = ValidationStatus.Fail;
			}

			((Entry)sender).TextColor = isValid ? ValidTextColor : Color.Red;
		}

	}
}

