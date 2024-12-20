using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class RepartidorController : Controller
    {
        // GET: Repartidor
        [HttpGet]
        public ActionResult GetAllRep()
        {
            ML.Repartidor repartidor = new ML.Repartidor();

            ML.Result result = BL.Repartidor.GetAllEF();

            if (result.Correct)
            {
                repartidor.Repartidores = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GetAllRep", repartidor);
        }

        [HttpPost]
        public ActionResult GetAllRep(ML.Repartidor repartidor)
        {
            ML.Result result = BL.Repartidor.GetAllEF();

            if (result.Correct)
            {
                repartidor.Repartidores = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GetAllRep", repartidor);
        }

        [HttpGet]
        public ActionResult Form(int? IdRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();

            ML.Result resultRepartidor = BL.Repartidor.GetAllEF();
            if (resultRepartidor.Correct)
            {
                repartidor.Repartidores = resultRepartidor.Objects;
            }

            if(IdRepartidor != null)
            {
                ML.Result result = BL.Repartidor.GetByIdEF(IdRepartidor.Value);
                if (result.Correct)
                {
                    repartidor = (ML.Repartidor)result.Object;
                    if (resultRepartidor.Correct)
                    {
                        repartidor.Repartidores = resultRepartidor.Objects;
                    }
                }
                else
                {
                    ViewBag.MensajeError = "Ocurrió un error al obtener la información del producto.";
                }
            }

            return View(repartidor);
        }

        [HttpPost]
        public ActionResult Form(ML.Repartidor repartidor)
        {
            ML.Result result = new ML.Result();

            if (repartidor.IdRepartidor == 0)
            {
                result = BL.Repartidor.AddEF(repartidor);

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
                if(repartidor.IdRepartidor >= 0)
                {
                    result = BL.Repartidor.UpdateEF(repartidor);
                    if (result.Correct)
                    {
                        ViewBag.Message = "El registro se ha actualizo correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Hubo un error a la hora de hacer la actualizacion";
                    }
                }
            }

            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdRepartidor)
        {
            if(IdRepartidor > 0)
            {
                ML.Result result = BL.Repartidor.DeleteEF(IdRepartidor);

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se ha eliminado correctamente";
                }
                else
                {
                    ViewBag.Message = "Hubo un error a la hora de hacer la eliminación";
                }
            }
            else
            {
                ViewBag.Message = "IdRepartidor no es válido.";
            }

            return View("Modal");
        }
    }
}