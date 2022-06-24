//using Web_Api_Pedidos.Datos;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Web_Api_Pedidos.Datos
{
    public class Conexion11
    {
        private string Cadena_SQL = string.Empty;

        
        public Conexion11()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            Cadena_SQL = builder.GetSection("ConnectionStrings:cadenaSQL").Value;
        }
        
       public string GetCadenaSQL()
        {
            return Cadena_SQL;
        }
    }
}
