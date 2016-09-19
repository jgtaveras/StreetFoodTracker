using System;
using Autofac;
using GFramework.Factory;
using GFramework.DI;
using Xamarin.Forms;

namespace GFramework.Bootstrapping
{
	public abstract class BootstrapperBase
	{
		public void Run(Application app)
		{
			var builder = new ContainerBuilder();

			ConfigureContainer(builder);
			RegisterPageResolver (builder);


			var container = builder.Build();
			var viewFactory = container.Resolve<IViewFactory>();

			RegisterViews(viewFactory);

			ConfigureApplication(container, app);
		}

		protected virtual void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule<AutofacModule>();
		}

		protected virtual void RegisterPageResolver(ContainerBuilder builder){
			//Page Resolver
			builder.RegisterInstance<Func<Page>>(() => {
				var masterDetailPage = Application.Current.MainPage as MasterDetailPage;

				//If we are using master-detail, messages should be displayed on the detail page
				var page = masterDetailPage != null 
					? masterDetailPage.Detail
					: Application.Current.MainPage;

				//Check if is navigation page
				var navigationPage = page as IPageContainer<Page>;

				return navigationPage != null ? navigationPage.CurrentPage : page;
			});
		}

		protected abstract void RegisterViews(IViewFactory viewFactory);

		protected abstract void ConfigureApplication(IContainer container, Application app);
	}
}

