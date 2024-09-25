using CADProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSProyecto
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://localhost/WebService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DSProyecto.usuarioDataTable GetUsuarioByID(string codigo)
        {
            return CADProyectos.GetUsuarioByID(codigo);
        }
        [WebMethod]
        public DSProyecto.usuarioDataTable GetUsuarios()
        {
            return CADProyectos.GetUsuarios();
        }

        [WebMethod]
        public DSProyecto.rolDataTable GetRolByID(string codigo)
        {
            return CADProyectos.GetRolByID(codigo);
        }
        [WebMethod]
        public DSProyecto.rolDataTable GetRol()
        {
            return CADProyectos.GetRol();
        }

        [WebMethod]
        public DSProyecto.ubicacionDataTable GetUbicacionByID(string codigo)
        {
            return CADProyectos.GetUbicacionByID(codigo);
        }
        [WebMethod]
        public DSProyecto.ubicacionDataTable GetUbicacion()
        {
            return CADProyectos.GetUbicacion();
        }

        [WebMethod]
        public DSProyecto.productoDataTable GetProductoByID(string codigo)
        {
            return CADProyectos.GetProductoByID(codigo);
        }
        [WebMethod]
        public DSProyecto.productoDataTable GetProducto()
        {
            return CADProyectos.GetProducto();
        }

        [WebMethod]
        public DSProyecto.pedidoDataTable GetPedidoByID(string codigo)
        {
            return CADProyectos.GetPedidoByID(codigo);
        }
        [WebMethod]
        public DSProyecto.pedidoDataTable GetPedido()
        {
            return CADProyectos.GetPedido();
        }

        [WebMethod]
        public DSProyecto.kardexDataTable GetKardexByID(string codigo)
        {
            return CADProyectos.GetKardexByID(codigo);
        }
        [WebMethod]
        public DSProyecto.kardexDataTable GetKardex()
        {
            return CADProyectos.GetKardex();
        }

        [WebMethod]
        public DSProyecto.detalle_pedidoDataTable GetDetalleByID(string codigo)
        {
            return CADProyectos.GetDetalleByID(codigo);
        }
        [WebMethod]
        public DSProyecto.detalle_pedidoDataTable GetDetalle()
        {
            return CADProyectos.GetDetalle();
        }

        [WebMethod]
        public DSProyecto.clienteDataTable GetClienteByID(string codigo)
        {
            return CADProyectos.GetClienteByID(codigo);
        }
        [WebMethod]
        public DSProyecto.clienteDataTable GetCliente()
        {
            return CADProyectos.GetCliente();
        }

        [WebMethod]
        public DSProyecto.almacenDataTable GetAlmacenByID(string codigo)
        {
            return CADProyectos.GetAlmacenByID(codigo);
        }
        [WebMethod]
        public DSProyecto.almacenDataTable GetAlmacen()
        {
            return CADProyectos.GetAlmacen();
        }

        [WebMethod]
        public bool ValidarUsuario(string user, string pass)
        {
            return CADProyecto.CADProyectos.ValidarUsuario(user, pass);
        }
    }
}
