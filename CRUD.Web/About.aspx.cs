using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.Dominio;
using CRUD.Dominio.Interface;

namespace CRUD.Web
{
    public partial class About : Page
    {
        IEmployeesService _srv;

        public About(IEmployeesService src)
        {
            _srv = src;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}