using Web_Api_Pedidos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Web_Api_Pedidos.Datos
{
    public class ordersData
    {

        public static List<Order> Lista()
        {
            var oLista = new List<Order>();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listaOrder", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Order()
                        {
                            OrderId = Convert.ToInt16(dr["OrderId"]),
                            CustomerId = dr["CustomerId"].ToString(),
                            EmployeeId = Convert.ToInt16(dr["EmployeeId"]),
                            OrderDate = Convert.ToDateTime( dr["OrderDate"].ToString()),
                            RequiredDate = Convert.ToDateTime(dr["TitleOfCourtesy"].ToString()),
                            ShippedDate = Convert.ToDateTime(dr["TitleOfCourtesy"].ToString()),
                            ShipVia = Convert.ToInt16(dr["TitleOfCourtesy"].ToString()),
                            Freight = Convert.ToDecimal(dr["TitleOfCourtesy"].ToString()),
                            ShipName= dr["ShipName"].ToString(),
                            ShipAddress= dr["ShipAddress"].ToString(),
                            ShipCity= dr["ShipAddress"].ToString(),
                            ShipRegion=dr["ShipRegion"].ToString(),
                            ShipPostalCode=dr["ShipPostalCode"].ToString(),
                            ShipCountry=dr["ShipCountry"].ToString(),


                        });
                        
                    }
                }
            }
            return oLista;
        }

        public static Order Obtener(int id)
        {
            var oCategory = new Order();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BusOrder", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCategory.OrderId = Convert.ToInt16(dr["OrderId"]);
                        oCategory.CustomerId = dr["CustomerId"].ToString();
                        oCategory.EmployeeId = Convert.ToInt16(dr["EmployeeId"]);
                        oCategory.OrderDate = Convert.ToDateTime(dr["OrderDate"].ToString());
                        oCategory.RequiredDate = Convert.ToDateTime(dr["TitleOfCourtesy"].ToString());
                        oCategory.ShippedDate = Convert.ToDateTime(dr["TitleOfCourtesy"].ToString());
                        oCategory.ShipVia = Convert.ToInt16(dr["TitleOfCourtesy"].ToString());
                        oCategory.Freight = Convert.ToDecimal(dr["TitleOfCourtesy"].ToString());
                        oCategory.ShipName = dr["ShipName"].ToString();
                        oCategory.ShipAddress = dr["ShipAddress"].ToString();
                        oCategory.ShipCity = dr["ShipAddress"].ToString();
                        oCategory.ShipRegion = dr["ShipRegion"].ToString();
                        oCategory.ShipPostalCode = dr["ShipPostalCode"].ToString();
                        oCategory.ShipCountry = dr["ShipCountry"].ToString();
                        
                    }
                }
            }
            return oCategory;
        }


        public static bool Ingresar(Order Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Orders", conexion);
                    cmd.Parameters.AddWithValue("CustomerId", Categoria.CustomerId);
                    cmd.Parameters.AddWithValue("EmployeeId", Categoria.EmployeeId);
                    cmd.Parameters.AddWithValue("OrderDate", Categoria.OrderDate);
                    cmd.Parameters.AddWithValue("RequiredDate", Categoria.RequiredDate);
                    cmd.Parameters.AddWithValue("ShippedDate", Categoria.ShippedDate);
                    cmd.Parameters.AddWithValue("ShipVia", Categoria.ShipVia);
                    cmd.Parameters.AddWithValue("Freight", Categoria.Freight);
                    cmd.Parameters.AddWithValue("ShipName", Categoria.ShipName);
                    cmd.Parameters.AddWithValue("ShipAddress", Categoria.ShipAddress);
                    cmd.Parameters.AddWithValue("ShipCity", Categoria.ShipCity);
                    cmd.Parameters.AddWithValue("ShipRegion", Categoria.ShipRegion);
                    cmd.Parameters.AddWithValue("ShipPostalCode", Categoria.ShipPostalCode);
                    cmd.Parameters.AddWithValue("ShipCountry", Categoria.ShipCountry);                   
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

        public static bool Editar(Order Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertOrders", conexion);

                    cmd.Parameters.AddWithValue("OrderId", Categoria.OrderId);
                    cmd.Parameters.AddWithValue("CustomerId", Categoria.CustomerId);
                    cmd.Parameters.AddWithValue("EmployeeId", Categoria.EmployeeId);
                    cmd.Parameters.AddWithValue("OrderDate", Categoria.OrderDate);
                    cmd.Parameters.AddWithValue("RequiredDate", Categoria.RequiredDate);
                    cmd.Parameters.AddWithValue("ShippedDate", Categoria.ShippedDate);
                    cmd.Parameters.AddWithValue("ShipVia", Categoria.ShipVia);
                    cmd.Parameters.AddWithValue("Freight", Categoria.Freight);
                    cmd.Parameters.AddWithValue("ShipName", Categoria.ShipName);
                    cmd.Parameters.AddWithValue("ShipAddress", Categoria.ShipAddress);
                    cmd.Parameters.AddWithValue("ShipCity", Categoria.ShipCity);
                    cmd.Parameters.AddWithValue("ShipRegion", Categoria.ShipRegion);
                    cmd.Parameters.AddWithValue("ShipPostalCode", Categoria.ShipPostalCode);
                    cmd.Parameters.AddWithValue("ShipCountry", Categoria.ShipCountry);

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
                    SqlCommand cmd = new SqlCommand("sp_DelOrders  ", conexion);
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
