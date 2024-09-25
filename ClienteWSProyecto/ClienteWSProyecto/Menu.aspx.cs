using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWSProyecto
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario.aspx");
        }

        protected void btnRol_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rol.aspx");
        }

        protected void btnProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
    }
}