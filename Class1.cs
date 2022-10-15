using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Data;
using Azure.Core;

namespace Proyecto_final_intermedio
{
    public class Usuario 
    { 
        public int _id { get; set; }
        public string _nombre { get; set; }
        public string _apellido { get; set; }
        public string _nombreDeUsuario { get; set; }
        public string _contraseña { get; set; }
        public string _mail { get; set; }

        public Usuario()
        {
            _id = 0;
            _nombre = "";
            _apellido = "";
            _nombreDeUsuario = "";
            _contraseña = "";
            _mail = "";
        }

        public Usuario(int id, string nombre, string apellido, string nombreDeUsuario, string contraseña, string mail)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _nombreDeUsuario = nombreDeUsuario;
            _contraseña = contraseña;
            _mail = mail;
        }

     
            

        }
    public class Producto
    {
        public int  _id { get; set; }
        public string _descripcion { get; set; }
        public int _costo { get; set; }
        public int _precioVenta { get; set; }
        public  int _stocl { get; set; }
        public int _idUsuario { get; set; }

        public Producto ()
        {

            _id = 0;
            _descripcion = "";
            _costo = 0;
            _precioVenta = 0;
            _stocl = 0;
            _idUsuario = 0;

        }

        public Producto(int id, string descripcion, int costo, int precioVenta, int stocl, int idUsuario)
        {
            _id = id;
            _descripcion = descripcion;
            _costo = costo;
            _precioVenta = precioVenta;
            _stocl = stocl;
            _idUsuario = idUsuario;
        }
    }
    public class ProductoVendido
    {
        public int _id { get; set; }
        public int _IdProductoVenta { get; set; }
        public int _stock { get; set; }
        public int _idVenta { get; set; }

        public ProductoVendido(int id, int idProductoVenta, int stock, int idVenta)
        {
            _id = id;
            _IdProductoVenta = idProductoVenta;
            _stock = stock;
            _idVenta = idVenta;
        }
    }
    public class Venta
    {
        public int _id { get; set; }
        public string _comentaros { get; set; }
        public int _idUsuario { get; set; }

        public Venta(int id, string comentaros, int idUsuario)
        {
            _id = id;
            _comentaros = comentaros;
            _idUsuario = idUsuario;
        }
    }
    public class Consultor
    {
        public static List<Usuario> TraerUsuario(int idusuario)
        {
            string connectionString = "Server=<DESKTOP-N741CHP> ; Database =<SistemaGestion>; Trusted_Connection = True;";
            var usuario = new List<Usuario>(); 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                var comando = new SqlCommand("Select Nombre ,Apellido,NombreUsuario, Mail From Usuario Where Id = @idUse", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "idUse";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idusuario;

                comando.Parameters.Add(parametro);
                connection.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                        while (dr.Read())
                        {

                            var user = new Usuario();
                            user._nombre = dr["Nombre"].ToString();
                            user._apellido = dr["Apellido"].ToString();
                            user._nombreDeUsuario = dr["NombreUsuario"].ToString();
                            user._mail = dr["Mail"].ToString();

                            usuario.Add(user); 
                        }

                }


                connection.Close();
                return usuario; 
            }
        }




    }
  
}
