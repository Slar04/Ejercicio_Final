﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Web_Api_Pedidos.Datos;
using Web_Api_Pedidos.Models;

namespace Web_Api_Pedidos.Controllers
{
    //[Route("api/v1/[controller]")]


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


        public ActionResult<ApiResult> GetResult()
        {
            ApiResult ret = new ApiResult();
            try
            {
                var rs = ProductsData.ListaProd();
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

        [Route("get2", Name = "getProducto2")]
        [HttpGet]

        public ActionResult<ApiResult> Product(int id)
        {
            ApiResult ret = new ApiResult();
            try
            {
               
                var rs = ProductsData.GetProd(id);
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

        [Route("post", Name = "postProducto")]
        [HttpPost]

        public  ActionResult<ApiResult> GuarProduct([FromBody]Product mod)
        {
            ApiResult ret = new ApiResult();

            try
            {
                var rs = ProductsData.GuardaProducto(mod);
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


        /// <summary>
        /// Actualiza los productos
        /// </summary>
        /// <param name="oProduc"></param>
        /// <returns></returns>
        /// 
        [Route("put", Name = "putProducto")]
        [HttpPut]

        public ActionResult<ApiResult> editar([FromBody]Product oProduc)
        {
            ApiResult ret = new ApiResult();
            try
            {
                var rs = ProductsData.editarProd(oProduc);
                ret.data = rs;
                ret.ok = true;
                ret.msg = "Se han actualizado los cambios Correctamente";
                return Ok(ret);
            }
            catch (Exception ex)
            {

                ret.msg = "Ocurrio un error al actualizar la consulta : " + ex.Message;
                ret.ok = false;
                ret.data = null;
                return StatusCode(500, ret);
            }
        }


        [Route("del", Name = "delProducto")]
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
                var rs = ProductsData.EliminarProd(oProduc);
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
