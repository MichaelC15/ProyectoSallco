using ClienteWSProyecto.WSProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWSProyecto
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEnviar_Click1(object sender, EventArgs e)
        {
            WebService1SoapClient servicio = new WebService1SoapClient();
            if (!servicio.ValidarUsuario(txtUser.Text, txtPass.Text))
            {
                lblMensaje.Text = "Usuario o contraseña no valido";
                txtUser.Text = "";
                txtPass.Text = "";
                txtUser.Focus();
                return;
            }
            Response.Redirect("Menu.aspx");
        }
    }
}