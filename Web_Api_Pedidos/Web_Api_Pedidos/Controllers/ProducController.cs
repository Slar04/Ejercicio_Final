using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Web_Api_Pedidos.Datos;
using Web_Api_Pedidos.Models;

namespace Web_Api_Pedidos.Controllers
{
    
    [Route("api/Producto")]
    [ApiController]
    public class ProducController : ControllerBase
    {
        /// <summary>
        /// Devuelve la lista completa de los clientes
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("get", Name = "getProducto")]
        [HttpGet]


public ActionResult<List<Product>> GetResult()
        {
            ApiResult ret = new ApiResult();
            var rs = ProductsData.ListaProd();
            ret = rs;

            return (bool)ret.data ? ret.ok ? Ok(ret);
            
        }




        public List<Product> GetResult()
        {
            return ProductsData.ListaProd();
        }

        
        /// <summary>
        ///  Busca un Producto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [Route("get2", Name = "getProducto2")]
        [HttpGet]

        public Product Get(int id)
        {
            return ProductsData.GetProd(id);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oProduc"></param>
        /// <returns></returns>
        /// 

        [Route("post", Name = "postProducto")]
        [HttpPost]

        public bool agregar(Product oProduc)
        {
            return ProductsData.GuardaProducto(oProduc);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oProduc"></param>
        /// <returns></returns>
        /// 
        [Route("put", Name = "putProducto")]
        [HttpPut]

        public bool editar(Product oProduc)
        {
            return ProductsData.editarCli(oProduc);
        }


        [Route("del", Name = "delProducto")]
        [HttpDelete]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public bool eliminar(int id)
        {
            return ProductsData.EliminarProd(id);
        }

    }
}
