using Web_Api_Pedidos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Web_Api_Pedidos.Datos
{
    public class SuppliersData
    {

        public static List<Supplier> Lista()
        {
            var oLista = new List<Supplier>();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListSpp", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Supplier()
                        {
                            SupplierId =Convert.ToInt16( dr["SupplierID"]),
                            CompanyName = dr["CompanyName"].ToString(),
                            ContactName = (dr["ContactName"].ToString()),
                            ContactTitle = (dr["ContactTitle"].ToString()),
                            Address = (dr["Address"].ToString()),
                            City = (dr["Region"].ToString()),
                            Region = (dr["region"].ToString()),
                            PostalCode = (dr["PostalCode"].ToString()),
                            Country = (dr["Country"].ToString()),
                            Phone = (dr["Phone"].ToString()),
                            Fax = (dr["Fax"].ToString()),
                            HomePage = (dr["HomePage"].ToString()),
                           
                        });
                    }
                }
            }
            return oLista;
        }

        public static Supplier Obtener(int id)
        {
            var oCategory = new Supplier();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscaSpp", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCategory.SupplierId = Convert.ToInt16(dr["SupplierID"]);
                        oCategory.CompanyName = dr["CompanyName"].ToString();
                        oCategory.ContactName = (dr["ContactName"].ToString());
                        oCategory.ContactTitle = (dr["ContactTitle"].ToString());
                        oCategory.Address = (dr["Address"].ToString());
                        oCategory.City = (dr["City"].ToString());
                        oCategory.Region = (dr["region"].ToString());
                        oCategory.PostalCode = (dr["PostalCode"].ToString());
                        oCategory.Country = (dr["Country"].ToString());
                        oCategory.Phone = (dr["Phone"].ToString());
                        oCategory.Fax = (dr["Fax"].ToString());
                        oCategory.HomePage = (dr["HomePage"].ToString());
                    }
                }
            }
            return oCategory;
        }


        public static bool Ingresar(Supplier Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Supplier", conexion);
                    cmd.Parameters.AddWithValue("@CompanyName", Categoria.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", Categoria.ContactName);
                    cmd.Parameters.AddWithValue("@ContactTitle", Categoria.ContactTitle);
                    cmd.Parameters.AddWithValue("@Address", Categoria.Address);
                    cmd.Parameters.AddWithValue("@City", Categoria.City);
                    cmd.Parameters.AddWithValue("@region", Categoria.Region);
                    cmd.Parameters.AddWithValue("@PostalCode", Categoria.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", Categoria.Country);
                    cmd.Parameters.AddWithValue("@Phone", Categoria.Phone);
                    cmd.Parameters.AddWithValue("@Fax", Categoria.Fax);
                    
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

        public static bool Editar(Supplier Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizaSpp", conexion);
                    cmd.Parameters.AddWithValue("@id", Categoria.SupplierId);
                    cmd.Parameters.AddWithValue("@CompanyName", Categoria.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", Categoria.ContactName);
                    cmd.Parameters.AddWithValue("@ContactTitle", Categoria.ContactTitle);
                    cmd.Parameters.AddWithValue("@Address", Categoria.Address);
                    cmd.Parameters.AddWithValue("@City", Categoria.City);
                    cmd.Parameters.AddWithValue("@region", Categoria.Region);
                    cmd.Parameters.AddWithValue("@PostalCode", Categoria.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", Categoria.Country);
                    cmd.Parameters.AddWithValue("@Phone", Categoria.Phone);
                    cmd.Parameters.AddWithValue("@Fax", Categoria.Fax);
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
                    SqlCommand cmd = new SqlCommand("sp_DelSpp  ", conexion);
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
