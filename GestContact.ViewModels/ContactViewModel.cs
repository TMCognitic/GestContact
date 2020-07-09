using GestContact.UI.Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tools.Patterns.Mediator;
using Tools.Patterns.MVVM.Commands;
using Tools.Patterns.MVVM.ViewModels;

namespace GestContact.ViewModels
{
    public class ContactViewModel : EntityViewModelBase<Contact>
    {
        private IDelegateCommand _deleteCommand;
        private IDelegateCommand _updateCommand;

        private string _nom, _prenom, _email, _tel;

        public ContactViewModel(Contact entity) : base(entity)
        {
            Nom = Entity.Nom;
            Prenom = Entity.Prenom;
            Email = Entity.Email;
            Tel = Entity.Tel;
        }

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

        public IDelegateCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new DelegateCommand(Delete));
            }
        }

        private void Delete()
        {
            ServicesLocator.Instance.ContactService.Delete(Entity.Id);
            Messenger<ContactViewModel>.Instance.Send(this);
        }

        public IDelegateCommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new DelegateCommand(Update, CanUpdate));
            }
        }

        private void Update()
        {
            Entity.Nom = Nom;
            Entity.Prenom = Prenom;
            Entity.Email = Email;
            Entity.Tel = Tel;

            ServicesLocator.Instance.ContactService.Update(Entity.Id, Entity);
            UpdateCommand.RaiseCanExecuteChanged();
        }

        private bool CanUpdate()
        {
            return !string.IsNullOrWhiteSpace(Nom) &&
               !string.IsNullOrWhiteSpace(Prenom) &&
               !string.IsNullOrWhiteSpace(Email) &&
               !string.IsNullOrWhiteSpace(Tel) &&
               Regex.IsMatch(Email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) &&
               (Nom != Entity.Nom ||
               Prenom != Entity.Prenom ||
               Email != Entity.Email ||
               Tel != Entity.Tel);
        }
    }
}
