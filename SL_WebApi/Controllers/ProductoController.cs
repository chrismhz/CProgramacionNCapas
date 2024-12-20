using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/Producto
        [HttpGet] //GetAll - GET -- Listo --
        [Route("api/Producto/GetAll")]
        public IHttpActionResult GetAll(int IdSubcategoria)
        {
            var result = BL.Producto.GetAllEF(IdSubcategoria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
        


        [HttpGet] //GetById - GET -- Listo --
        [Route("api/Producto/GetbyId/{IdProducto}")] 
        public IHttpActionResult GetById(int IdProducto)
        {
            var result = BL.Producto.GetByIdEF(IdProducto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost] //ADD - POST -- Listo --
        [Route("api/Producto/Add")] 
        public IHttpActionResult Post([FromBody] ML.Producto producto)
        {
            var result = BL.Producto.AddEF(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost] //UPDATE - POST - PUT -- Listo --
        [Route("api/Producto/Update/{IdProducto}")]
        public IHttpActionResult Put(int IdProducto, [FromBody] ML.Producto producto)
        {
            var result = BL.Producto.UpdateEF(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet] //DELETE - GET -- Listo --
        [Route("api/Producto/Delete/{IdProducto}")]
        public IHttpActionResult Delete(int IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;
            var result = BL.Producto.DeleteEF(IdProducto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
