﻿using System;
using ReactiveUI;
using Splat;
using Xamarin.Forms;
using ReactiveUI.XamForms;
using XamarinFormsReactiveListView.ViewModels;
using XamarinFormsReactiveListView.Views;

namespace XamarinFormsReactiveListView
{
	public class AppBootstrapper : ReactiveObject, IScreen
	{
		public RoutingState Router { get; protected set; }

		public AppBootstrapper()
		{
			Router = new RoutingState();
			Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

			// TODO: Register new views here, then navigate to the first page
			Locator.CurrentMutable.Register(() => new MonkeyListView(), typeof(IViewFor<MonkeyListViewModel>));
			Locator.CurrentMutable.Register(() => new MonkeyCellView(), typeof(IViewFor<MonkeyCellViewModel>));

			Router.Navigate.Execute(new MonkeyListViewModel(this));
		}

		public Page CreateMainPage()
		{
			return new RoutedViewHost();
		}
	}
}

