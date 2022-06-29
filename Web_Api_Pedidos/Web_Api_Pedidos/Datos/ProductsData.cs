using Web_Api_Pedidos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Web_Api_Pedidos.Datos
{
    public class ProductsData
    {
        public static List<Product> ListaProd()
        {
            var oLista = new List<Product>();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();               
                SqlCommand cmd = new SqlCommand("sp_ListProd", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Product()
                        {
                            ProductId = Convert.ToInt32( dr["ProductId"]),
                            ProductName = dr["ProductName"].ToString(),
                            //CompanyName = dr["CompanyName"].ToString(),
                          //  CategoryName = dr["CategoryName"].ToString(),
                            QuantityPerUnit = dr["QuantityPerUnit"].ToString(),
                            UnitPrice = Convert.ToInt16(dr["UnitPrice"]),
                            UnitsInStock = Convert.ToInt16(dr["UnitsInStock"]),
                            UnitsOnOrder = Convert.ToInt16(dr["UnitsOnOrder"]),
                            ReorderLevel = Convert.ToInt16( dr["ReorderLevel"]),
                            Discontinued = Convert.ToBoolean( dr["Discontinued"].ToString()),
                            CategoryId= Convert.ToInt32( dr["CategoryId"]),
                           SupplierId= Convert.ToInt32( dr["SupplierID"])
                        });
                    }
                }
            }
            return oLista;
        }

        public static Product GetProd(int id)
        {
            var oLista = new Product();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();               
                SqlCommand cmd = new SqlCommand("sp_BuscProd", conexion);             
                cmd.Parameters.AddWithValue("name", id);
                cmd.CommandType = CommandType.StoredProcedure;
               
                
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.ProductId = Convert.ToInt32(dr["ProductId"]);
                        oLista.ProductName = dr["ProductName"].ToString();
                      //  oLista.CompanyName = dr["CompanyName"].ToString();
                        //oLista.CategoryName = dr["CategoryName"].ToString();
                        oLista.QuantityPerUnit = dr["QuantityPerUnit"].ToString();
                        oLista.UnitPrice = Convert.ToInt16(dr["UnitPrice"]);
                        oLista.UnitsInStock = Convert.ToInt16(dr["UnitsInStock"]);
                        oLista.UnitsOnOrder = Convert.ToInt16(dr["UnitsOnOrder"]);
                        oLista.ReorderLevel = Convert.ToInt16(dr["ReorderLevel"]);
                        oLista.Discontinued = Convert.ToBoolean(dr["Discontinued"].ToString());
                        oLista.CategoryId = Convert.ToInt32(dr["CategoryID"]);
                        oLista.SupplierId = Convert.ToInt32(dr["SupplierID"]);
                    }
                }
            }
            return oLista;
        }


        public static bool GuardaProducto(Product oProduct)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Products", conexion);
                    //cmd.Parameters.AddWithValue("ProductId", oProduct.ProductId);
                    cmd.Parameters.AddWithValue("ProductName", oProduct.ProductName);
                    cmd.Parameters.AddWithValue("SupplierID", oProduct.SupplierId);
                    cmd.Parameters.AddWithValue("CategoryId", oProduct.CategoryId);
                    cmd.Parameters.AddWithValue("QuantityPerUnit", oProduct.QuantityPerUnit);
                    cmd.Parameters.AddWithValue("UnitPrice", oProduct.UnitPrice);
                    cmd.Parameters.AddWithValue("UnitsInStock", oProduct.UnitsInStock);
                    cmd.Parameters.AddWithValue("UnitsOnOrder", oProduct.UnitsOnOrder);
                    cmd.Parameters.AddWithValue("ReorderLevel", oProduct.ReorderLevel);
                    cmd.Parameters.AddWithValue("Discontinued", oProduct.Discontinued);
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


        public static bool editarProd(Product oProducto)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProdUpDate", conexion);
                    cmd.Parameters.AddWithValue("ProductID", oProducto.ProductId);
                    cmd.Parameters.AddWithValue("ProductName", oProducto.ProductName);
                    cmd.Parameters.AddWithValue("SupplierID", oProducto.SupplierId);
                    cmd.Parameters.AddWithValue("CategoryId", oProducto.CategoryId);
                    cmd.Parameters.AddWithValue("QuantityPerUnit", oProducto.QuantityPerUnit);
                    cmd.Parameters.AddWithValue("UnitPrice", oProducto.UnitPrice);
                    cmd.Parameters.AddWithValue("UnitsInStock", oProducto.UnitsInStock);
                    cmd.Parameters.AddWithValue("UnitsOnOrder", oProducto.UnitsOnOrder);
                    cmd.Parameters.AddWithValue("ReorderLevel", oProducto.ReorderLevel);
                    cmd.Parameters.AddWithValue("Discontinued", oProducto.Discontinued);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                throw;
            }

            return rpta;
        }


        public static bool EliminarProd(int idCli)
        {
            bool rpta;


            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    // SqlCommand cmd = new SqlCommand("sp_BusCus '"+name+"' ", conexion);
                    SqlCommand cmd = new SqlCommand("sp_ProdDelet  ", conexion);
                    cmd.Parameters.AddWithValue("id", idCli);
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
