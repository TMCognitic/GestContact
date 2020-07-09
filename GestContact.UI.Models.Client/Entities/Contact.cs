using System;
using System.Collections.Generic;
using System.Text;

namespace GestContact.UI.Models.Client.Entities
{
    public class Contact
    {
        private int _id;
        private string _nom, _prenom, _email, _tel;

        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
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
                _prenom = value;
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
                _email = value;
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
                _tel = value;
            }
        }

        public Contact(string nom, string prenom, string email, string tel)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
        }

        internal Contact(int id, string nom, string prenom, string email, string tel)
            : this(nom, prenom, email, tel)
        {
            Id = id;
        }

    }
}
