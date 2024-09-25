using ClienteWSProyecto.WSProyecto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWSProyecto
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTablaProducto();
            }
        }
        private void LlenarTablaProducto()
        {
            try
            {
                WebService1SoapClient servicio = new WebService1SoapClient();
                var productos = servicio.GetProducto();

                foreach (var producto in productos)
                {
                    string filaHtml = $"<tr>" +
                                      $"<td>{producto.id}</td>" +
                                      $"<td>{producto.nombre}</td>" +
                                      $"<td>{producto.descripcion}</td>" +
                                      $"<td>{producto.precio}</td>" +
                                      $"<td>{producto.stock}</td>" +
                                      $"<td>{producto.ubicacion_id}</td>" +
                                      $"</tr>";
                    phTablaProductos.Controls.Add(new LiteralControl(filaHtml));
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
                var prod = servicio.GetProductoByID(txtidProducto.Text);

                if (prod.Rows.Count == 0)
                {
                    lblMensaje.Text = "Producto no existe";
                    LimpiarCampos();
                    LlenarTablaProducto();
                    return;
                }
                var miRegistro = prod.Rows[0];
                txtNombre.Text = miRegistro["nombre"].ToString();
                txtDescripcion.Text = miRegistro["descripcion"].ToString();
                txtPrecio.Text = miRegistro["precio"].ToString();
                txtStock.Text = miRegistro["stock"].ToString();
                txtUbicacionID.Text = miRegistro["ubicacion_id"].ToString();

                string filaHtml = $"<tr>" +
                                  $"<td>{miRegistro["id"]}</td>" +
                                  $"<td>{miRegistro["nombre"]}</td>" +
                                  $"<td>{miRegistro["descripcion"]}</td>" +
                                  $"<td>{miRegistro["precio"]}</td>" +
                                  $"<td>{miRegistro["stock"]}</td>" +
                                  $"<td>{miRegistro["ubicacion_id"]}</td>" +
                                  $"</tr>";
                phTablaProductos.Controls.Add(new LiteralControl(filaHtml));

                lblMensaje.Text = "Producto encontrado";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar Producto: " + ex.Message;
            }
        }
        protected void btnNuevo_Click1(object sender, EventArgs e)
        {
            LimpiarCampos();
            LlenarTablaProducto();
        }
        private void LimpiarCampos()
        {
            txtidProducto.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtUbicacionID.Text = string.Empty;
            lblMensaje.Text = "";

        }
    }
}