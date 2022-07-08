using Web_Api_Pedidos.Models;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Web_Api_Pedidos.Datos
{
    public class EmployeesData
    {
        public static List<Employee> Lista()
        {
            var oLista = new List<Employee>();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_LisEmpl", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Employee()
                        {
                            //EmployeeId = Convert.ToInt16( dr["EmployeeID"]),
                            //LastName=dr["LastName"].ToString(),
                            //FirstName = dr["FirstName"].ToString(),
                            //Title = dr["Title"].ToString(),
                            //TitleOfCourtesy = dr["TitleOfCourtesy"].ToString(),
                            //BirthDate = Convert.ToDateTime( dr["BirthDate"].ToString()),
                            //HireDate = Convert.ToDateTime( dr["HireDate"].ToString()),
                            //Address = dr["Address"].ToString(),
                            //City = dr["City"].ToString(),
                            //Region = dr["Region"].ToString(),
                            //PostalCode = dr["PostalCode"].ToString(),
                            //Country = dr["Country"].ToString(),
                            //HomePhone = dr["HomePhone"].ToString(),
                            //Extension = dr["Extension"].ToString(),                           
                            //Notes = dr["Notes"].ToString(),
                            //ReportsTo= Convert.ToInt16( dr["ReportsTo"]),
                            EmployeeId = Convert.ToInt16(dr["EmployeeID"]),
                        LastName = dr["LastName"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        Title = dr["Title"].ToString(),
                        TitleOfCourtesy = dr["TitleOfCourtesy"].ToString(),
                         BirthDate = Convert.ToDateTime(dr["BirthDate"].ToString()),
                        HireDate = Convert.ToDateTime(dr["HireDate"].ToString()),
                        Address = dr["Address"].ToString(),
                        City = dr["City"].ToString(),
                        Region = dr["Region"].ToString(),
                        PostalCode = dr["PostalCode"].ToString(),
                        Country = dr["Country"].ToString(),
                        HomePhone = dr["HomePhone"].ToString(),
                        Extension = dr["Extension"].ToString(),
                        Notes = dr["Notes"].ToString(),
                        ReportsTo = Convert.ToInt16(dr["ReportsTo"]),


                    });
                    }
                }
            }
            return oLista;
        }

        public static Employee Obtener(int id)
        {
            var oCategory = new Employee();
            var cd = new Conexion11();

            using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BusEmpl", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCategory.EmployeeId = Convert.ToInt16(dr["EmployeeID"]);
                        oCategory.LastName = dr["LastName"].ToString();
                        oCategory.FirstName = dr["FirstName"].ToString();
                        oCategory.Title = dr["Title"].ToString();
                        oCategory.TitleOfCourtesy = dr["TitleOfCourtesy"].ToString();
                        oCategory.BirthDate = Convert.ToDateTime(dr["BirthDate"].ToString());
                        oCategory.HireDate = Convert.ToDateTime(dr["HireDate"].ToString());
                        oCategory.Address = dr["Address"].ToString();
                        oCategory.City = dr["City"].ToString();
                        oCategory.Region = dr["Region"].ToString();
                        oCategory.PostalCode = dr["PostalCode"].ToString();
                        oCategory.Country = dr["Country"].ToString();
                        oCategory.HomePhone = dr["HomePhone"].ToString();
                        oCategory.Extension = dr["Extension"].ToString();
                     
                        oCategory.Notes = dr["Notes"].ToString();
                        oCategory.ReportsTo = Convert.ToInt16(dr["ReportsTo"]);
                        
                 }
                }
            }
            return oCategory;
        }


        public static bool Ingresar(Employee Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsEmployes", conexion);
                    //cmd.Parameters.AddWithValue("EmployeeId", Categoria.EmployeeId);
                    cmd.Parameters.AddWithValue("@LastName", Categoria.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", Categoria.FirstName);
                    cmd.Parameters.AddWithValue("@Title", Categoria.Title);
                    cmd.Parameters.AddWithValue("@TitleOfCourtesy", Categoria.TitleOfCourtesy);
                    cmd.Parameters.AddWithValue("@BirthDate", Categoria.BirthDate);
                    cmd.Parameters.AddWithValue("@HireDate", Categoria.HireDate);
                    cmd.Parameters.AddWithValue("@Address", Categoria.Address);
                    cmd.Parameters.AddWithValue("@City", Categoria.City);
                    cmd.Parameters.AddWithValue("@Region", Categoria.Region);
                    cmd.Parameters.AddWithValue("@PostalCode", Categoria.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", Categoria.Country);                    
                    cmd.Parameters.AddWithValue("@HomePhone", Categoria.HomePhone);
                    cmd.Parameters.AddWithValue("@Extension", Categoria.Extension);                    
                    cmd.Parameters.AddWithValue("@Notes", Categoria.Notes);                   
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

        public static bool Editar(Employee Categoria)
        {
            bool rpta;
            try
            {
                var cd = new Conexion11();
                using (var conexion = new SqlConnection(cd.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActEmployes", conexion);
                    cmd.Parameters.AddWithValue("@id", Categoria.EmployeeId);
                    cmd.Parameters.AddWithValue("@LastName", Categoria.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", Categoria.FirstName);
                    cmd.Parameters.AddWithValue("@Title", Categoria.Title);
                    cmd.Parameters.AddWithValue("@TitleOfCourtesy", Categoria.TitleOfCourtesy);
                    cmd.Parameters.AddWithValue("@BirthDate", Categoria.BirthDate);
                    cmd.Parameters.AddWithValue("@HireDate", Categoria.HireDate);
                    cmd.Parameters.AddWithValue("@Address", Categoria.Address);
                    cmd.Parameters.AddWithValue("@City", Categoria.City);
                    cmd.Parameters.AddWithValue("@Region", Categoria.Region);
                    cmd.Parameters.AddWithValue("@PostalCode", Categoria.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", Categoria.Country);
                    cmd.Parameters.AddWithValue("@HomePhone", Categoria.HomePhone);
                    cmd.Parameters.AddWithValue("@Extension", Categoria.Extension);
                    cmd.Parameters.AddWithValue("@Notes", Categoria.Notes);
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
                    SqlCommand cmd = new SqlCommand("sp_DelEmpl  ", conexion);
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
