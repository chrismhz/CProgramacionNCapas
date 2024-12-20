using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class OperacionesController : ApiController
    {
        // -------------------------------------------------- Con Params ------------------------------------------------

        /*[System.Web.Http.Route("api/Suma")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Suma(int numero1, int numero2)
        {
            int resultado = numero1 + numero2;
            return Content(HttpStatusCode.OK, resultado);
        }


        [System.Web.Http.Route("api/Resta")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Resta(int numero1, int numero2)
        {
            int resultado = numero1 - numero2;
            return Content(HttpStatusCode.OK, resultado);
        }

        [System.Web.Http.Route("api/Multiplicacion")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Multiplicacion(int numero1, int numero2, int numero3)
        {
            int resultado = numero1 * numero2 * numero3;
            return Content(HttpStatusCode.OK, resultado);
        }

        [System.Web.Http.Route("api/Division")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Division(int numero1, int numero2)
        {
            int resultado = numero1 / numero2;
            return Content(HttpStatusCode.OK, resultado);
        }*/


        // -------------------------------------------------- Con Body --------------------------------------------------

        /*[System.Web.Http.Route("api/Suma")] 
        [System.Web.Http.HttpPost]
        public IHttpActionResult Suma([FromBody] Operaciones operaciones)
        {
            int resultado = operaciones.numero1 + operaciones.numero2 + operaciones.numero3;
            return Content(HttpStatusCode.OK, resultado);
        }

        [System.Web.Http.Route("api/Resta")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Resta([FromBody] Operaciones operaciones)
        {
            int resultado = operaciones.numero1 - operaciones.numero2;
            return Content(HttpStatusCode.OK, resultado);
        }

        [System.Web.Http.Route("api/Multiplicacion")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Multiplicacion([FromBody] Operaciones operaciones)
        {
            int resultado = operaciones.numero1 * operaciones.numero2 * operaciones.numero3;
            return Content(HttpStatusCode.OK, resultado);
        }

        [System.Web.Http.Route("api/Division")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Division([FromBody] Operaciones operaciones)
        {
            int resultado = operaciones.numero1 / operaciones.numero2;
            return Content(HttpStatusCode.OK, resultado);
        }*/
    }
}
