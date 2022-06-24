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
        [Route("Producto/get", Name = "getProducto")]
        [HttpGet]

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

        [Route("Producto/get", Name = "getProducto")]
        [HttpGet("{id}")]

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

        [Route("Producto/post", Name = "postProducto")]
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
        [Route("Producto/put", Name = "putProducto")]
        [HttpPut("{id}")]

        public bool editar(Product oProduc)
        {
            return ProductsData.editarCli(oProduc);
        }


        [Route("Producto/del", Name = "delProducto")]
        [HttpDelete("{id}")]
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
