using GestContact.Interfaces;
using G = GestContact.Models;
using GS = GestContact.UI.Models.Services;
using GestContact.UI.Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Tools.Api;
using System.Linq;
using GestContact.UI.Models.Client.Mappers;

namespace GestContact.UI.Models.Client.Services
{
    public class ContactService : IContactServices<Contact>
    {
        IContactServices<G.Contact> _globalService;

        public ContactService(IApiInfo apiInfo)
        {
            _globalService = new GS.ContactService(apiInfo);
        }

        public IEnumerable<Contact> Get()
        {
            return _globalService.Get().Select(c => c.ToClient());
        }

        public Contact Get(int id)
        {
            return _globalService.Get(id)?.ToClient();
        }

        public Contact Insert(Contact entity)
        {
            return _globalService.Insert(entity.ToGlobal()).ToClient();
        }

        public bool Update(int id, Contact entity)
        {
            _globalService.Update(id, entity.ToGlobal());
            return true;
        }

        public bool Delete(int id)
        {
            _globalService.Delete(id);
            return true;
        }
    }
}
