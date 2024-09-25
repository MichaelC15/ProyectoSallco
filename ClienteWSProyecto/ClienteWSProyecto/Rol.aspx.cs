using ClienteWSProyecto.WSProyecto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWSProyecto
{
    public partial class Rol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTablaRol();
            }
        }
        private void LlenarTablaRol()
        {
            try
            {
                WebService1SoapClient servicio = new WebService1SoapClient();
                var roles = servicio.GetRol();

                foreach (var rol in roles)
                {
                    string filaHtml = $"<tr>" +
                                      $"<td>{rol.id}</td>" +
                                      $"<td>{rol.nombre}</td>" +
                                      $"<td>{rol.descripcion}</td>" +
                                      $"</tr>";
                    phTablaRoles.Controls.Add(new LiteralControl(filaHtml));
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar datos: " + ex.Message;
            }
        }
        protected void btnEnviar_Click1(object sender, EventArgs e)
        {
            try
            {
                WebService1SoapClient servicio = new WebService1SoapClient();
                var prod = servicio.GetRolByID(txtidRol.Text);

                if (prod.Rows.Count == 0)
                {
                    lblMensaje.Text = "Rol no existe";
                    LimpiarCampos();
                    LlenarTablaRol();
                    return;
                }
                var miRegistro = prod.Rows[0];
                txtNombre.Text = miRegistro["nombre"].ToString();
                txtDescripcion.Text = miRegistro["descripcion"].ToString();

                string filaHtml = $"<tr>" +
                                  $"<td>{miRegistro["id"]}</td>" +
                                  $"<td>{miRegistro["nombre"]}</td>" +
                                  $"<td>{miRegistro["descripcion"]}</td>" +
                                  $"</tr>";
                phTablaRoles.Controls.Add(new LiteralControl(filaHtml));

                lblMensaje.Text = "Rol encontrado";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar Rol: " + ex.Message;
            }
        }
        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            LimpiarCampos();
            LlenarTablaRol();
        }
        private void LimpiarCampos()
        {
            txtidRol.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            lblMensaje.Text = "";

        }
    }
}