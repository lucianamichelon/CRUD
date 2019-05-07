using CRUD.Dominio.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Dominio.Interface;

namespace CRUD.Dominio.Service
{
    public class EmployeesService : IEmployeesService
    {
        IEmployeesRepository _repo;
        public EmployeesService(IEmployeesRepository repo)
        {
            _repo = repo;
        }

        public void Add(Employees obj)
        {
            _repo.Add(obj);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employees> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Employees ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employees obj)
        {
            throw new NotImplementedException();
        }
    }

}
