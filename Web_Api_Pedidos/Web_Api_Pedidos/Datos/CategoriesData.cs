using Web_Api_Pedidos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Web_Api_Pedidos.Datos
{
    public class CategoriesData
    {
        //Lista para visualizar las categorias
        public static List<Category> Lista()
        {
            var oLista = new List<Category>();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_lisCat", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Category()
                        {
                            CategoryName = dr["CategoryName"].ToString(),
                            Description = dr["Description"].ToString(),
                            Picture = Convert.ToByte( dr["Picture"].ToString()),
                      
                        });
                    }
                }
            }
            return oLista;
        }
        //Busca la categoria por ID
        public static Category ObtenerCat(int id)
        {
            var oCategory = new Category();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();               
                SqlCommand cmd = new SqlCommand("sp_BusCat", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCategory.CategoryName = dr["CategoryName"].ToString();
                        oCategory.Description = dr["Description"].ToString();
                        oCategory.Picture = Convert.ToByte(dr["Picture"].ToString());
                       
                    }
                }
            }
            return oCategory;
        }


        public static bool Ingresar(Category Categoria)
        {
            bool rpta;            
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_cATEGORIES  ", conexion);
                    cmd.Parameters.AddWithValue("CategoryName", Categoria.CategoryName);
                    cmd.Parameters.AddWithValue("Description", Categoria.Description);
                    cmd.Parameters.AddWithValue("Picture", Categoria.Picture);
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

        public static bool Editar(Category Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActCAt  ", conexion);
                    cmd.Parameters.AddWithValue("CategoryName", Categoria.CategoryName);
                    cmd.Parameters.AddWithValue("Description", Categoria.Description);
                    cmd.Parameters.AddWithValue("Picture", Categoria.Picture);
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
                    // SqlCommand cmd = new SqlCommand("sp_BusCus '"+name+"' ", conexion);
                    SqlCommand cmd = new SqlCommand("sp_DelCat  ", conexion);
                    cmd.Parameters.AddWithValue("CustomerID", idCli);
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
