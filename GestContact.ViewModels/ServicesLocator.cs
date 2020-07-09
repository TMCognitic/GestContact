using GestContact.Interfaces;
using GestContact.UI.Models.Client.Entities;
using GestContact.UI.Models.Client.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Api;

namespace GestContact.ViewModels
{
    public sealed class ServicesLocator
    {
        private static ServicesLocator _instance;

        public static ServicesLocator Instance
        {
            get
            {
                return _instance ?? (_instance = new ServicesLocator());
            }
        }

        private ServicesLocator()
        {
        }

        private IContactServices<Contact> _contactService;

        public IContactServices<Contact> ContactService
        {
            get
            {
                return _contactService ?? (_contactService = new ContactService(new ApiInfo(new Uri("https://localhost:5001/api/"))));
            }
        }

        
    }
}
