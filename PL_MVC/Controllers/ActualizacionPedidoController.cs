using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ActualizacionPedidoController : Controller
    {
        // GET: c
        [HttpGet]
        public ActionResult GetAllAcPe()
        {
            ML.ActualizacionPedido acpe = new ML.ActualizacionPedido();
            ML.Result result = BL.ActualizacionPedido.GetAllEF();

            if (result.Correct)
            {
                acpe.ActualizacionPedidoss = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GetAllAcPe", acpe);
        }

        [HttpPost]
        public ActionResult GetAllAcPe(ML.ActualizacionPedido acpe)
        {
            ML.Result result = BL.ActualizacionPedido.GetAllEF();

            if (result.Correct)
            {
                acpe.ActualizacionPedidoss = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GetAllAcPe", acpe);
        }

        [HttpPost]
        public ActionResult Form(ML.ActualizacionPedido actualizacionPedido)
        {
            ML.Result result = new ML.Result();

            if (actualizacionPedido.IdActualizacionPedido == 0)
            {
                result = BL.ActualizacionPedido.AddEF(actualizacionPedido);

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se ha agregado correctamente";
                }
                else
                {
                    ViewBag.Message = "Hubo un error a la hora de hacer el registro";
                }
            }
            else
            {
                if(actualizacionPedido.IdActualizacionPedido > 0)
                {
                    result = BL.ActualizacionPedido.UpdateEF(actualizacionPedido);
                }

            }
            

            return PartialView("Modal");
        }


    }
}