using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dominio.Interface.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        IEnumerable<TEntity> ReadAll();
        TEntity ReadById(int id);
    }
}
