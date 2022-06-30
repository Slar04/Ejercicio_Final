using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Web_Api_Pedidos.Datos;
using Web_Api_Pedidos.Models;

namespace Web_Api_Pedidos.Controllers
{
    
    [Route("api/Clientes")]
    [ApiController]
    public class CustomController : ControllerBase
    {

        /// <summary>
        /// Devuelve la lista completa de los clientes
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("get", Name = "getClientes")]
        [HttpGet]

        public ActionResult<ApiResult> Lista()
        {
            ApiResult ret = new ApiResult();
            
            try
            {

                var rs = CustomerData.ListaCli();
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
        /// Busca el cliente por medio de su nombre, no por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [Route("get2", Name = "getClientes2")]
        [HttpGet]
        public ActionResult<ApiResult> GetResult(string id)
        {
            ApiResult ret = new ApiResult();

            try
            {

                var rs = CustomerData.ObtenerCli(id);
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
        /// Agrega un nuevo cliente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// 
        [Route("post", Name = "postClientes")]
        [HttpPost]
        public ActionResult<ApiResult> GuarProduct([FromBody] Customer mod)
        {
            ApiResult ret = new ApiResult();

            try
            {

                var rs = CustomerData.GuardarCli(mod);
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Se han guardado los datos correctamente";

                return Ok(ret);
            }
            catch (Exception ex)
            {

                ret.msg = "Ocurrio un error al Guardar los Datos: " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }
        }

        /// <summary>
        /// elimina a un cliente por medio de un id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [Route("del", Name = "delClientes")]
        [HttpDelete]
        public bool eliminar(string id)
        {
            return CustomerData.EliminarCli(id);
        }
        /// <summary>
        /// Modifica a un cliente por medio de un id
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// 


        [Route("put", Name = "putClientes")]
        [HttpPut]
        public ActionResult<ApiResult> Actualizar([FromBody]Customer oProduc)
        {
            ApiResult ret = new ApiResult();

            try
            {
                var rs = CustomerData.EditarCli(oProduc);
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Se han actualizados los datos correctamente";

                return Ok(ret);
            }
            catch (Exception ex)
            {

                ret.msg = "Ocurrio un error al actualizar los Datos: " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }
        }


    }
}
