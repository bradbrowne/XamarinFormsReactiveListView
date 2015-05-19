﻿using System;
using ReactiveUI;
using XamarinFormsReactiveListView.Models;
using System.Reactive;
using Splat;

namespace XamarinFormsReactiveListView.ViewModels
{
	public class MonkeyCellViewModel : ReactiveObject
	{
		IMonkeyService _monkeyService;

		public MonkeyCellViewModel (IMonkeyService monkeyService)
		{
			this._monkeyService = monkeyService;
			DeleteCommand = ReactiveCommand.CreateAsyncTask(async (model, e) =>
				{
					System.Diagnostics.Debug.WriteLine("DeleteCommand");
					var monkey = model as MonkeyCellViewModel;
					this._monkeyService.Remove(monkey);
				});
		}

		public Monkey Monkey { get; set; }
		public string Name 
		{ 
			get 
			{ 
				return Monkey.Name;
			}
		}

		public ReactiveCommand<Unit> DeleteCommand { get; set; }
	}
}

