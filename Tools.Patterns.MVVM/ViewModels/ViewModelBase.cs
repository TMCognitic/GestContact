using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Tools.Patterns.MVVM.Commands;

namespace Tools.Patterns.MVVM.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ViewModelBase()
        {
            Type viewModelType = GetType();

            IEnumerable<PropertyInfo> properties = viewModelType.GetProperties().Where(pi => pi.PropertyType == typeof(IDelegateCommand) || pi.PropertyType.GetInterfaces().Contains(typeof(IDelegateCommand)));

            foreach (PropertyInfo property in properties)
            {
                IDelegateCommand command = (IDelegateCommand)property.GetMethod.Invoke(this, null);
                PropertyChanged += (sender, e) => command.RaiseCanExecuteChanged();
            }
        }

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if(!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
