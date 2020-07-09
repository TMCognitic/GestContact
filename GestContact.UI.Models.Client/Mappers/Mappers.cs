using GestContact.UI.Models.Client.Entities;
using G = GestContact.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestContact.UI.Models.Client.Mappers
{
    internal static class Mappers
    {
        internal static Contact ToClient(this G.Contact entity)
        {
            return new Contact(entity.Id, entity.Nom, entity.Prenom, entity.Email, entity.Tel);
        }

        internal static G.Contact ToGlobal(this Contact entity)
        {
            return new G.Contact() { Id = entity.Id, Nom = entity.Nom, Prenom = entity.Prenom, Email = entity.Email, Tel = entity.Tel };
        }
    }
}
