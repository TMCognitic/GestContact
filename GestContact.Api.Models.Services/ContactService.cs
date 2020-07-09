using GestContact.Api.Models.Services.Mappers;
using GestContact.Interfaces;
using GestContact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Database;

namespace GestContact.Api.Models.Services
{
    public class ContactService : IContactServices<Contact>
    {
        private IConnection _connection;

        public ContactService(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, Phone From AppUser.V_Contact;");
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int id)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, Phone From AppUser.V_Contact Where Id = @Id;");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

        public Contact Insert(Contact entity)
        {
            Command command = new Command("AppUser.CSP_AddContact", true);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("Prenom", entity.Prenom);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Tel", entity.Tel);

            entity.Id = (int)_connection.ExecuteScalar(command);
            return entity;
        }

        public bool Update(int id, Contact entity)
        {
            Command command = new Command("AppUser.CSP_UpdateContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("Prenom", entity.Prenom);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Tel", entity.Tel);

            _connection.ExecuteNonQuery(command);
            return true;
        }

        public bool Delete(int id)
        {
            Command command = new Command("AppUser.CSP_DeleteContact", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
            return true;
        }
    }
}
