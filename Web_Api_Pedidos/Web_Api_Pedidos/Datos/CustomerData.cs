 using Web_Api_Pedidos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Web_Api_Pedidos.Datos
{
    public class CustomerData
    {
        /// <summary>
        /// Lista entera de los Clientes
        /// </summary>
        /// <returns></returns>
        public static List<Customer> ListaCli()
        {
            var oCliente = new List<Customer>();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();               
                SqlCommand cmd = new SqlCommand("sp_BusCus", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCliente.Add(new Customer()
                        {
                         CustomerId = dr["ID"].ToString(),
                        CompanyName = dr["Nombre Compañia"].ToString(),
                        ContactName = dr["Nombre de Contacto"].ToString(),
                        ContactTitle = dr["Titulo de Contacto"].ToString(),
                        Address = dr["Direccion"].ToString(),
                        City = dr["Ciudad"].ToString(),
                        Region = dr["Region"].ToString(),
                        PostalCode = dr["Codigo Post."].ToString(),
                        Country = dr["Pais"].ToString(),
                        Phone = dr["Teléfono"].ToString(),
                        Fax = dr["Fax"].ToString()
                    });
                           
                       
                    }
                }
            }

            return oCliente;
        }
          
        

      
        public static Customer ObtenerCli(string name)
        {
            var oCliente = new Customer  ();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                // SqlCommand cmd = new SqlCommand("sp_BusCus '"+name+"' ", conexion);
                SqlCommand cmd = new SqlCommand("sp_BusCustomer", conexion);
                cmd.Parameters.AddWithValue("CustomerID", name);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCliente.CustomerId = dr["ID"].ToString();
                        oCliente.CompanyName = dr["Nombre Compañia"].ToString();
                        oCliente.ContactName = dr["Nombre de Contacto"].ToString();
                        oCliente.ContactTitle = dr["Titulo de Contacto"].ToString();
                        oCliente.Address = dr["Direccion"].ToString();
                        oCliente.City = dr["Ciudad"].ToString();
                        oCliente.Region = dr["Region"].ToString();
                        oCliente.PostalCode = dr["Codigo Post."].ToString();
                        oCliente.Country = dr["Pais"].ToString();
                        oCliente.Phone = dr["Teléfono"].ToString();
                        oCliente.Fax = dr["Fax"].ToString();
                    }
                }
            }
            return oCliente;
        }

        public static bool GuardarCli(Customer oCliente)
        {
            bool rpta;


            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    // SqlCommand cmd = new SqlCommand("sp_BusCus '"+name+"' ", conexion);
                    SqlCommand cmd = new SqlCommand("sp_custoners  ", conexion);
                    cmd.Parameters.AddWithValue("@CustomerID", oCliente.CustomerId);
                    cmd.Parameters.AddWithValue("@CompanyName", oCliente.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", oCliente.ContactName);
                    cmd.Parameters.AddWithValue("@ContactTitle", oCliente.ContactTitle);
                    cmd.Parameters.AddWithValue("@Address", oCliente.Address);
                    cmd.Parameters.AddWithValue("@City", oCliente.City);
                    cmd.Parameters.AddWithValue("@Region", oCliente.Region);
                    cmd.Parameters.AddWithValue("@PostalCode", oCliente.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", oCliente.Country);
                    cmd.Parameters.AddWithValue("@phone", oCliente.Phone);
                    cmd.Parameters.AddWithValue("@Fax", oCliente.Fax);
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


        public static bool EditarCli(Customer oCliente)
        {
            bool rpta;


            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    // SqlCommand cmd = new SqlCommand("sp_BusCus '"+name+"' ", conexion);
                    SqlCommand cmd = new SqlCommand("sp_ActualizaCusto  ", conexion);
                    cmd.Parameters.AddWithValue("@CustomerID", oCliente.CustomerId);
                    cmd.Parameters.AddWithValue("@CompanyName", oCliente.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", oCliente.ContactName);
                    cmd.Parameters.AddWithValue("@ContactTitle", oCliente.ContactTitle);
                    cmd.Parameters.AddWithValue("@City", oCliente.City);
                    cmd.Parameters.AddWithValue("@Region", oCliente.Region);
                    cmd.Parameters.AddWithValue("@PostalCode", oCliente.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", oCliente.Country);
                    cmd.Parameters.AddWithValue("@phone", oCliente.Phone);
                    cmd.Parameters.AddWithValue("@Fax", oCliente.Fax);
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



        public static bool EliminarCli(string idCli)
        {
            bool rpta;


            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    // SqlCommand cmd = new SqlCommand("sp_BusCus '"+name+"' ", conexion);
                    SqlCommand cmd = new SqlCommand("sp_EliminarCust  ", conexion);
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
