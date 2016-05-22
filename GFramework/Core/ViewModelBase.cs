﻿using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq.Expressions;


namespace GFramework.Core
{
	public class ViewModelBase : IViewModel
	{


		public string Title { get; set; }

		private bool _isBusy;
		public bool IsBusy{
			get{
				return _isBusy;
			}
			set{
				SetProperty (ref _isBusy, value);
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

	
		public void SetState<T> (Action<T> action) where T : class, IViewModel
		{
			action (this as T);
		}

		protected virtual bool SetProperty<T> (ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (object.Equals (storage, value))
				return false;

			storage = value;
			OnPropertyChanged (propertyName);

			return true;
		}

		protected void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			var eventHandler = PropertyChanged;
			if (eventHandler != null) {
				eventHandler (this, new PropertyChangedEventArgs (propertyName));
			}
		}

		protected void OnPropertyChanged<T> (Expression<Func<T>> propertyExpression)
		{
			var propertyName = PropertySupport.ExtractPropertyName (propertyExpression);
			OnPropertyChanged (propertyName);
		}
	}
}

