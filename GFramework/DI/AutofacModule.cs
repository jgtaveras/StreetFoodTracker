using System;
using Autofac;
using GFramework.Factory;
using GFramework.Services.Navigation.MVFirst;
using GFramework.Services.Dialog;
using Xamarin.Forms;

namespace GFramework.DI
{
	public class AutofacModule : Module
	{
		protected override void Load (ContainerBuilder builder)
		{
			//Services
			builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
			builder.RegisterType<NavigationService> ().As<INavigationService> ().SingleInstance ();
			builder.RegisterType<DialogService> ().As<IDialogService> ().SingleInstance ();

			//Xamarin navigation
			builder.Register<INavigation>(context => Application.Current.MainPage.Navigation).SingleInstance();

			//Page Proxy
			builder.RegisterType<PageProxy>().As<IPage>().SingleInstance();

		}
	}
}

