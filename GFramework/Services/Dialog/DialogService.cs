using System;
using System.Threading.Tasks;

namespace GFramework.Services.Dialog
{
	public class DialogService : IDialogService
	{
		private IPage _page;
		public DialogService (IPage page)
		{
			_page = page;
		}


		#region IDialogService implementation

		public Task DisplayAlert( string title, string message, string cancel)
		{
			return _page.DisplayAlert(title, message, cancel);
		}

		public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
		{
			return await _page.DisplayAlert(title, message, accept, cancel);
		}

		public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
		{
			return await _page.DisplayActionSheet(title, cancel, destruction, buttons);
		}

		#endregion
	}
}

