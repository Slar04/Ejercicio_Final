//using Web_Api_Pedidos.Datos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Web_Api_Pedidos.Controllers
{
    public class Conexion
    {
        public static string ConnectBD = "Server=SISTEMASPC\\DANIELSQL; DataBase= master; Integrated Security=True";
    }




    public static class ConexionBD
    {
        public static int conf;
        public static DataSet ds = new DataSet();
        public static string s = "Server=SISTEMASPC\\DANIELSQL; DataBase= master; Integrated Security=True";
        public static SqlConnection conexion = new SqlConnection(s);
        public static SqlCommand comando = new SqlCommand();
        public static SqlDataAdapter sqlDA = new SqlDataAdapter();


        static ConexionBD()
        {
            //CÓDIGO DEL CONSTRUCTOR
            comando.Connection = conexion;
        }

        public static Tuple<int, DataSet> transacBD(string query, Boolean select)
        {
            DataSet dss = new DataSet();

            if (select == true)
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = query;
                sqlDA.SelectCommand = comando;
                conf = sqlDA.Fill(dss);
                return Tuple.Create(conf, dss);
            }
            else
            {
                conexion.Open();
                comando.CommandText = query;
                conf = comando.ExecuteNonQuery();
                conexion.Close();
                return Tuple.Create(conf, dss);
            }
        }

    }

}
