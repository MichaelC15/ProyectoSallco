using ClienteWSProyecto.WSProyecto;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWSProyecto
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTablaClientes();
            }
        }
        private void LlenarTablaClientes()
        {
            try
            {
                WebService1SoapClient servicio = new WebService1SoapClient();
                var clientes = servicio.GetCliente();

                foreach (var cliente in clientes)
                {
                    string filaHtml = $"<tr>" +
                                      $"<td>{cliente.id}</td>" +
                                      $"<td>{cliente.nombre}</td>" +
                                      $"<td>{cliente.direccion}</td>" +
                                      $"<td>{cliente.telefono}</td>" +
                                      $"<td>{cliente.email}</td>" +
                                      $"</tr>";
                    phTablaClientes.Controls.Add(new LiteralControl(filaHtml));
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
                var prod = servicio.GetClienteByID(txtidCliente.Text);

                if (prod.Rows.Count == 0)
                {
                    lblMensaje.Text = "Cliente no existe";
                    LimpiarCampos();
                    LlenarTablaClientes();
                    return;
                }

                var miRegistro = prod.Rows[0];
                txtNombre.Text = miRegistro["nombre"].ToString();
                txtDireccion.Text = miRegistro["direccion"].ToString();
                txtTelefono.Text = miRegistro["telefono"].ToString();
                txtEmail.Text = miRegistro["email"].ToString();

                string filaHtml = $"<tr>" +
                                  $"<td>{miRegistro["id"]}</td>" +
                                  $"<td>{miRegistro["nombre"]}</td>" +
                                  $"<td>{miRegistro["direccion"]}</td>" +
                                  $"<td>{miRegistro["telefono"]}</td>" +
                                  $"<td>{miRegistro["email"]}</td>" +
                                  $"</tr>";
                phTablaClientes.Controls.Add(new LiteralControl(filaHtml));

                lblMensaje.Text = "Cliente encontrado";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar cliente: " + ex.Message;
            }
        }
        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            LimpiarCampos();
            LlenarTablaClientes();
        }
        private void LimpiarCampos()
        {
            txtidCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            lblMensaje.Text = "";
        }
    }
}
