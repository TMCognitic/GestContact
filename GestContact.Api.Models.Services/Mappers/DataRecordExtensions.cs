using GestContact.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GestContact.Api.Models.Services.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Contact ToContact(this IDataRecord dataRecord)
        {
            return new Contact() { Id = (int)dataRecord["Id"], Nom = (string)dataRecord["LastName"], Prenom = (string)dataRecord["FirstName"], Email = (string)dataRecord["Email"], Tel = (string)dataRecord["Phone"] };
        }
    }
}
