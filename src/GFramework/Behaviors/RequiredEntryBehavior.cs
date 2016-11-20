using System;
using Xamarin.Forms;

namespace GFramework.Behaviors
{
	public class RequiredEntryBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo (Entry bindable)
		{
			base.OnAttachedTo (bindable);
			bindable.TextChanged += OnTextChanged;
		}

		protected override void OnDetachingFrom (Entry bindable)
		{
			base.OnDetachingFrom (bindable);
			bindable.TextChanged -= OnTextChanged; 

		}

		void OnTextChanged (object sender, TextChangedEventArgs e)
		{
			var entry = (Entry)sender;

			if (string.IsNullOrEmpty (entry.Text)) {
				entry.BackgroundColor = Color.Red;
			}
		}
	}
}

