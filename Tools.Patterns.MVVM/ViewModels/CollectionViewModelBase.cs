using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tools.Patterns.MVVM.ViewModels
{
    public abstract class CollectionViewModelBase<TViewModel> : ViewModelBase
        where TViewModel : ViewModelBase
    {
        private ObservableCollection<TViewModel> _items;

        public ObservableCollection<TViewModel> Items
        {
            get
            {
                return _items ?? (_items = LoadItems());
            }
        }

        public TViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private TViewModel _selectedItem;

        protected abstract ObservableCollection<TViewModel> LoadItems();
    }
}
