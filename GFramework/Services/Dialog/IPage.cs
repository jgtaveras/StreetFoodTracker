using System;
using Xamarin.Forms;

namespace GFramework.Services.Dialog
{
	public interface IPage : IDialogService
	{
		INavigation Navigation{ get; }
	}
}

