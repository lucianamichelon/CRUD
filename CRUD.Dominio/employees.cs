using CRUD.Dominio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dominio
{
    public class Employees
    {
        public int emp_no { get; set; }
        public DateTime birth_date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Enumeradores.Gender gender { get; set; }
        public DateTime hire_date { get; set; }
    }
}
