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
    public class ConsultorUsuario
    {
        public static Usuario TraerUsuario(string nombreUsuario )
        {
            string connectionString = "Server=<DESKTOP-N741CHP> ; Database =<SistemaGestion>; Trusted_Connection = True;";
            var usuario = new Usuario(); 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                var comando = new SqlCommand("Select * From Usuario Where NombreUsuario = @idUse", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "idUse";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = nombreUsuario;

                comando.Parameters.Add(parametro);
                connection.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                   
                        

                }


                connection.Close();
                return usuario; 
            }
        }




    }
  
    public class ConsultarProductos
    {
        public static List<Producto> TraerProdcutos(int idPrudocuto)
        {

            string connectionString = "Server=<DESKTOP-N741CHP> ; Database =<SistemaGestion>; Trusted_Connection = True;";
            var listaProducto = new List<Producto>();
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                var comando = new SqlCommand("Select * From Producto Where IdUsuario = @idUse", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "idUse";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idPrudocuto;

                comando.Parameters.Add(parametro);
                connection.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto(); 
                            producto._id = Convert.ToInt32(dr["Id"]);
                            producto._descripcion = dr["Descripciones"].ToString();
                            producto._costo = Convert.ToInt32(dr["Costo"]);
                            producto._precioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                            producto._stocl = Convert.ToInt32(dr["Stock"]);
                            producto._idUsuario = Convert.ToInt32(dr["IdUsuario"]);

                            listaProducto.Add(producto);
                        }


                    }


                }



            }

            return listaProducto; 


        }
        




    }
    
    public class ConsultarProductoVendido
    {
        public static List<Producto> TraerProductosVendidos(int idusuario)
        {
            string connectionString = "Server=<DESKTOP-N741CHP> ; Database =<SistemaGestion>; Trusted_Connection = True;";
            var listaProductos = new List<Producto>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                var comando = new SqlCommand("select P.Descripciones ,P.PrecioVenta , p.Stock from  Usuario as U Inner join  Producto as P on U.Id = P.IdUsuario inner join ProductoVendido as PV on P.Id = PV.IdProducto inner join Venta as V on V.Id  = PV.IdVenta where u.id = 1  ", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "idUse";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idusuario;

                comando.Parameters.Add(parametro);
                connection.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto() ;

                            producto._descripcion = dr["Descripciones"].ToString();
                            producto._precioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                            producto._stocl = Convert.ToInt32(dr["Stock"]);

                            listaProductos.Add(producto);
                        }
            
                    }

                }

            }

            return listaProductos; 

        }



    }

}
