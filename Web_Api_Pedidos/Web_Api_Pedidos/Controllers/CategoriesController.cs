using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Web_Api_Pedidos.Datos;
using Web_Api_Pedidos.Models;

namespace Web_Api_Pedidos.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// Devuelve la lista completa de los clientes
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("get", Name = "getCategories")]
        [HttpGet]


        public ActionResult<ApiResult> GetResult()
        {
            ApiResult ret = new ApiResult();
            try
            {
                var rs = CategoriesData.Lista();
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Consulta exitosa";

                return Ok(ret);
            }
            catch (Exception ex)
            {
                ret.msg = "Ocurrio un error al realizar la consulta : " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }
        }


        /// <summary>
        ///  Busca un Producto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [Route("get2", Name = "getCategories2")]
        [HttpGet]

        public ActionResult<ApiResult> Product(int id)
        {
            ApiResult ret = new ApiResult();
            try
            {
                var rs = CategoriesData.ObtenerCat(id);
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Consulta exitosa";

                return Ok(ret);
            }
            catch (Exception ex)
            {

                ret.msg = "Ocurrio un error al realizar la consulta : " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oProduc"></param>
        /// <returns></returns>
        /// 

        [Route("post", Name = "postCategories")]
        [HttpPost]

        public ActionResult<ApiResult> GuardProd([FromBody] Category mod)
        {
            ApiResult ret = new ApiResult();

            try
            {
                var rs = CategoriesData.Ingresar(mod);
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Se han guardados los cambios Correctamente";
                return Ok(ret);
            }
            catch (Exception ex)
            {

                ret.msg = "Ocurrio un error al guardar los datos : " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }

        }

        [Route("put", Name = "putCategories")]
        [HttpPut]

        public ActionResult<ApiResult> Actualizar([FromBody] Category mod)
        {
            ApiResult ret = new ApiResult();

            try
            {
                var rs = CategoriesData.Editar(mod);
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Se han actualizado los cambios Correctamente";
                return Ok(ret);
            }
            catch (Exception ex)
            {

                ret.msg = "Ocurrio un error al guardar los datos : " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }

        }

        [Route("del", Name = "delCategories")]
        [HttpDelete]
        /// <summary>
        /// Emilina los prodcutos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public ActionResult<ApiResult> Eliminar(int oProduc)
        {
            ApiResult ret = new ApiResult();
            try
            {
                var rs = CategoriesData.Eliminar(oProduc);
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Se ha borrado correctamente";
                return Ok(ret);
            }
            catch (Exception ex)
            {

                ret.msg = "Ocurrio un error al eliminar el producto : " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }
        }
    }
}
