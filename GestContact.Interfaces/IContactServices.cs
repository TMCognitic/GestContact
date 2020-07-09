using System;
using System.Collections.Generic;

namespace GestContact.Interfaces
{
    public interface IContactServices<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        TEntity Insert(TEntity entity);
        bool Update(int id, TEntity entity);
        bool Delete(int id);
    }
}
