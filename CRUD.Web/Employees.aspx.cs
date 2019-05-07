using CRUD.Dominio;
using CRUD.Dominio.Interface;
using CRUD.Dominio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Web
{
    public partial class Employees : System.Web.UI.Page
    {
        IEmployeesService _srv;

        public Employees(IEmployeesService src)
        {
            _srv = src;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindEmployees();
            }
        }

        protected void DataBindEmployees()
        {
            IEnumerable<Dominio.Employees> lstEmp = _srv.ReadAll();
            gdvEmployees.DataSource = lstEmp;
            gdvEmployees.DataBind();
        }

        protected void gdvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvEmployees.EditIndex = e.NewEditIndex;
            DataBindEmployees();
        }

        protected void gdvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gdvEmployees.DataKeys[e.RowIndex].Values);
            _srv.Delete(id);
            DataBindEmployees();
        }

        protected void gdvEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvEmployees.EditIndex = -1;
            DataBindEmployees();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Inserir();
        }

        protected void gdvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvEmployees.PageIndex = e.NewPageIndex;
            DataBindEmployees();
        }

        protected void Inserir()
        {
            if (Page.IsValid)
            {
                try
                {
                    Dominio.Employees emp = new Dominio.Employees()
                    {
                        first_name = txtFirstName.Text.Trim(),
                        last_name = txtLastName.Text.Trim(),
                        birth_date = Convert.ToDateTime(txtBirthDate.Text.Trim()),
                        gender = (Enumeradores.Gender)Enum.Parse(typeof(Enumeradores.Gender), rdbGender.SelectedItem.Value)
                    };

                    _srv.Add(emp);
                    DataBindEmployees();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void gdvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(gdvEmployees.DataKeys[e.RowIndex].Values);
                Dominio.Employees emp = new Dominio.Employees();
                emp = _srv.ReadById(id);

                emp.first_name = txtFirstName.Text.Trim();
                emp.last_name = txtLastName.Text.Trim();
                emp.birth_date = Convert.ToDateTime(txtBirthDate.Text.Trim());
                emp.gender = (Enumeradores.Gender)Enum.Parse(typeof(Enumeradores.Gender), rdbGender.SelectedItem.Value);

                _srv.Add(emp);
                DataBindEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}