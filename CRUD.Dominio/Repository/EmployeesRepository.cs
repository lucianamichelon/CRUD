using CRUD.Dominio.Interface.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Dominio.Connections;
using System.Data.SqlClient;
using System.Data;
using CRUD.Dominio.Util;

namespace CRUD.Dominio.Repository
{
    public class EmployeesRepository : IRepositoryBase<Employees>
    {
        Connection conn;

        public EmployeesRepository(Connection _conn)
        {
            conn = _conn;
        }

        public void Add(Employees obj)
        {
            conn.Conectar();
            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO employees VALUES ( @birth_date, @first_name, @last_name, @gender, @hire_date)";
            command.Parameters.AddWithValue("birth_date", obj.birth_date);
            command.Parameters.AddWithValue("first_name", obj.first_name);
            command.Parameters.AddWithValue("last_name", obj.last_name);
            command.Parameters.AddWithValue("gender", obj.gender);
            command.Parameters.AddWithValue("hire_date", obj.hire_date);

            conn.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            conn.Conectar();
            var command = new SqlCommand();
            command.CommandText = "DELETE FROM Employees where emp_no = @id";
            command.Parameters.AddWithValue("id", id);
            command.CommandType = System.Data.CommandType.Text;
            conn.ExecuteNonQuery(command);
        }

        public IEnumerable<Employees> ReadAll()
        {
            conn.Conectar();

            string query = "SELECT emp_no, bith_date, first_name, last_name, gender, hire_date FROM employees";

            DataTable dt = conn.ExecutarDataTable(query);
            List<Employees> lst = new List<Employees>();
            foreach (DataRow item in dt.Rows)
            {
                Employees emp = new Employees();

                emp.emp_no = Convert.ToInt32(item["emp_no"].ToString());
                emp.first_name = item["first_name"].ToString();
                emp.last_name = item["last_name"].ToString();
                emp.gender = (Enumeradores.Gender)Enum.Parse(typeof(Enumeradores.Gender), item["gender"].ToString());
                if(!string.IsNullOrEmpty(item["hire_date"].ToString()))
                    emp.hire_date = Convert.ToDateTime(item["hire_date"].ToString());
                emp.birth_date = Convert.ToDateTime(item["birth_date"].ToString());
                lst.Add(emp);
            }

            return lst;


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
