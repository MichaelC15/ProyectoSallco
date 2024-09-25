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
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTablaUsuario();
            }
        }
        private void LlenarTablaUsuario()
        {
            try
            {
                WebService1SoapClient servicio = new WebService1SoapClient();
                var usua = servicio.GetUsuarios();

                foreach (var usuario in usua)
                {
                    string filaHtml = $"<tr>" +
                                      $"<td>{usuario.id}</td>" +
                                      $"<td>{usuario.rol_id}</td>" +
                                      $"<td>{usuario.usuario}</td>" +
                                      $"<td>{usuario.contraseña}</td>" +
                                      $"<td>{usuario.nombre}</td>" +
                                      $"<td>{usuario.apellido}</td>" +
                                      $"<td>{usuario.email}</td>" +
                                      $"</tr>";
                    phTablaUsuarios.Controls.Add(new LiteralControl(filaHtml));
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
                var usua = servicio.GetUsuarioByID(txtidUsuario.Text);

                if (usua.Rows.Count == 0)
                {
                    lblMensaje.Text = "Usuario no existe";
                    LimpiarCampos();
                    LlenarTablaUsuario();
                    return;
                }
                var miRegistro = usua.Rows[0];
                txtRol_id.Text = miRegistro["rol_id"].ToString();
                txtUsuario.Text = miRegistro["usuario"].ToString();
                txtContraseña.Text = miRegistro["contraseña"].ToString();
                txtNombre.Text = miRegistro["nombre"].ToString();
                txtApellido.Text = miRegistro["apellido"].ToString();
                txtEmail.Text = miRegistro["email"].ToString();

                string filaHtml = $"<tr>" +
                                  $"<td>{miRegistro["id"]}</td>" +
                                  $"<td>{miRegistro["rol_id"]}</td>" +
                                  $"<td>{miRegistro["usuario"]}</td>" +
                                  $"<td>{miRegistro["contraseña"]}</td>" +
                                  $"<td>{miRegistro["nombre"]}</td>" +
                                  $"<td>{miRegistro["apellido"]}</td>" +
                                  $"<td>{miRegistro["email"]}</td>" +
                                  $"</tr>";
                phTablaUsuarios.Controls.Add(new LiteralControl(filaHtml));

                lblMensaje.Text = "Usuario encontrado";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar usuario: " + ex.Message;
            }
        }
        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            LimpiarCampos();
            LlenarTablaUsuario();
        }
        private void LimpiarCampos()
        {
            txtidUsuario.Text = string.Empty;
            txtRol_id.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            lblMensaje.Text = "";
        }
    }
}