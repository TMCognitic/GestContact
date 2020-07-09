using GestContact.UI.Models.Client.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Tools.Patterns.Mediator;
using Tools.Patterns.MVVM.Commands;
using Tools.Patterns.MVVM.ViewModels;

namespace GestContact.ViewModels
{
    public class MainViewModel : CollectionViewModelBase<ContactViewModel>
    {
        private string _nom, _prenom, _email, _tel;
        private IDelegateCommand _addCommand;

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                SetProperty(ref _nom, value);
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                SetProperty(ref _prenom, value);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                SetProperty(ref _email, value);
            }
        }

        public string Tel
        {
            get
            {
                return _tel;
            }

            set
            {
                SetProperty(ref _tel, value);
            }
        }

        public IDelegateCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand(Add, CanAdd));
            }
        }

        public MainViewModel()
        {
            Messenger<ContactViewModel>.Instance.Register(OnDeleteContact);
        }

        private void Add()
        {
            Contact c = new Contact(Nom, Prenom, Email, Tel);
            Items.Add(new ContactViewModel(c));
            
            //vide le formulaire
            Nom = Prenom = Email = Tel = null;
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Nom) &&
                !string.IsNullOrWhiteSpace(Prenom) &&
                !string.IsNullOrWhiteSpace(Email) &&
                !string.IsNullOrWhiteSpace(Tel) &&
                Regex.IsMatch(Email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        protected override ObservableCollection<ContactViewModel> LoadItems()
        {
            //Get from DB
            return new ObservableCollection<ContactViewModel>(ServicesLocator.Instance.ContactService.Get().Select(c => new ContactViewModel(c)));
        }

        private void OnDeleteContact(ContactViewModel viewModel)
        {
            Items.Remove(viewModel);
        }
    }
}
