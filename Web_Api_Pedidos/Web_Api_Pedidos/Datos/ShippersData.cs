using Web_Api_Pedidos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Web_Api_Pedidos.Datos
{
    public class ShippersData
    {

        public static List<Shipper> Lista()
        {
            var oLista = new List<Shipper>();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listShip", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Shipper()
                        {
                            ShipperId = Convert.ToInt16(dr["ShipperID"]),
                            CompanyName = dr["CompanyName"].ToString(),
                            Phone = (dr["Phone"].ToString()),                           
                        });
                    }
                }
            }
            return oLista;
        }

        public static Shipper Obtener(int id)
        {
            var oCategory = new Shipper();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BusShip", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCategory.ShipperId = Convert.ToInt16(dr["ShipperID"]);
                        oCategory.CompanyName = dr["CompanyName"].ToString();
                        oCategory.Phone = (dr["Phone"].ToString());          
                       
                    }
                }
            }
            return oCategory;
        }


        public static bool Ingresar(Shipper Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Shipper", conexion);
                    cmd.Parameters.AddWithValue("@CompanyName", Categoria.CompanyName);
                    cmd.Parameters.AddWithValue("@phone", Categoria.Phone);                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public static bool Editar(Shipper Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActShip", conexion);
                    cmd.Parameters.AddWithValue("@id", Categoria.ShipperId);
                    cmd.Parameters.AddWithValue("@CompanyName", Categoria.CompanyName);
                    cmd.Parameters.AddWithValue("@phone", Categoria.Phone);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


        public static bool Eliminar(int idCli)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_DelShip  ", conexion);
                    cmd.Parameters.AddWithValue("@id", idCli);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false; ;
            }
            return rpta;
        }

    }
}
