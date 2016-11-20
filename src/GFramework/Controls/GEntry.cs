using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GFramework.Controls
{
    public class GEntry : Entry
    {
        public enum BorderStyles
        {
            Default,
            None,
            Line
        }

        public static readonly BindableProperty BorderStyleProperty =
            BindableProperty.Create<GEntry, BorderStyles>(
                p => p.BorderStyle, BorderStyles.Default);

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create<GEntry, float>(
                p => p.CornerRadius, 1f);

        public static readonly BindableProperty HasAutoCorrectProperty =
            BindableProperty.Create<GEntry, bool>(
                p => p.HasAutoCorrect, true);

        public BorderStyles BorderStyle
        {
            get { return (BorderStyles)GetValue(BorderStyleProperty); }
            set { SetValue(BorderStyleProperty, value); }
        }

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public bool HasAutoCorrect
        {
            get { return (bool)GetValue(HasAutoCorrectProperty); }
            set { SetValue(HasAutoCorrectProperty, value); }
        }

	
    }
}
