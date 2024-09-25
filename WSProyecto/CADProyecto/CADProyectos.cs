using CADProyecto.DSProyectoTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADProyecto
{
    public class CADProyectos
    {
        private static usuarioTableAdapter adaptador_usuario = new usuarioTableAdapter();

        public static DSProyecto.usuarioDataTable GetUsuarioByID(string id)
        {
            return adaptador_usuario.GetUsuarioByID(id);
        }
        public static DSProyecto.usuarioDataTable GetUsuarios()
        {
            return adaptador_usuario.GetData();
        }

        private static rolTableAdapter adaptador_rol = new rolTableAdapter();

        public static DSProyecto.rolDataTable GetRolByID(string id)
        {
            return adaptador_rol.GetRolByID(id);
        }
        public static DSProyecto.rolDataTable GetRol()
        {
            return adaptador_rol.GetData();
        }

        private static ubicacionTableAdapter adaptador_ubicacion = new ubicacionTableAdapter();

        public static DSProyecto.ubicacionDataTable GetUbicacionByID(string id)
        {
            return adaptador_ubicacion.GetUbicacionByID(id);
        }
        public static DSProyecto.ubicacionDataTable GetUbicacion()
        {
            return adaptador_ubicacion.GetData();
        }

        private static productoTableAdapter adaptador_producto = new productoTableAdapter();

        public static DSProyecto.productoDataTable GetProductoByID(string id)
        {
            return adaptador_producto.GetProductoByID(id);
        }
        public static DSProyecto.productoDataTable GetProducto()
        {
            return adaptador_producto.GetData();
        }

        private static pedidoTableAdapter adaptador_pedido = new pedidoTableAdapter();

        public static DSProyecto.pedidoDataTable GetPedidoByID(string id)
        {
            int idPedidoInt = int.Parse(id);
            return adaptador_pedido.GetPedidoByID(idPedidoInt);
        }
        public static DSProyecto.pedidoDataTable GetPedido()
        {
            return adaptador_pedido.GetData();
        }

        private static kardexTableAdapter adaptador_kardex = new kardexTableAdapter();

        public static DSProyecto.kardexDataTable GetKardexByID(string id)
        {
            int idKardexInt = int.Parse(id);
            return adaptador_kardex.GetKardexByID(idKardexInt);
        }
        public static DSProyecto.kardexDataTable GetKardex()
        {
            return adaptador_kardex.GetData();
        }

        private static detalle_pedidoTableAdapter adaptador_detalle = new detalle_pedidoTableAdapter();

        public static DSProyecto.detalle_pedidoDataTable GetDetalleByID(string id)
        {
            int idDetalleInt = int.Parse(id);
            return adaptador_detalle.GetDetalleByID(idDetalleInt);
        }
        public static DSProyecto.detalle_pedidoDataTable GetDetalle()
        {
            return adaptador_detalle.GetData();
        }

        private static clienteTableAdapter adaptador_cliente = new clienteTableAdapter();

        public static DSProyecto.clienteDataTable GetClienteByID(string id)
        {
            return adaptador_cliente.GetClienteByID(id);
        }
        public static DSProyecto.clienteDataTable GetCliente()
        {
            return adaptador_cliente.GetData();
        }

        private static almacenTableAdapter adaptador_almacen = new almacenTableAdapter();

        public static DSProyecto.almacenDataTable GetAlmacenByID(string id)
        {
            return adaptador_almacen.GetAlmacenByID(id);
        }
        public static DSProyecto.almacenDataTable GetAlmacen()
        {
            return adaptador_almacen.GetData();
        }

        public static bool ValidarUsuario(string user, string pass)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-9LG7FIK;" +
                "Initial Catalog=proyecto;" +
                "Integrated Security=True"))
            {
                bool res;
                connection.Open();

                string query = "SELECT nombre, usuario FROM usuario WHERE usuario = '" + user + "' or contraseña = '" + pass + "'";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
                reader.Close();
                return res;
            }
        }
    }
}