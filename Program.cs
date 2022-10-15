using Proyecto_final_intermedio;
using System.Data.SqlClient;
class Usuario
{
    static void Main(string[] args)

    {

        Usuario usuario1 = new Usuario(1, "Carlos", "Aguero", "CarlosG", "As456", "Carlosg@masda");

        Consultor.TraerUsuario(usuario1); 


    }

}
    






