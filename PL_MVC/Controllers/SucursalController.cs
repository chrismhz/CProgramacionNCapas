using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        [HttpGet]
        public ActionResult GeAllS()
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            ML.Result result = BL.Sucursal.GetAllEF();

            if (result.Correct)
            {
                sucursal.Sucursales = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GeAllS", sucursal);
        }

        [HttpPost]
        public ActionResult GeAllS(ML.Sucursal sucursal)
        {
            
            ML.Result result = BL.Sucursal.GetAllEF();

            if (result.Correct)
            {
                sucursal.Sucursales = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GeAllS", sucursal);
        }

        [HttpGet]
        public ActionResult Form(int? IdSucursal)
        {
            ML.Sucursal sucursal = new ML.Sucursal();

            ML.Result resultSucursal = BL.Sucursal.GetAllEF();
            if (resultSucursal.Correct)
            {
                sucursal.Sucursales = resultSucursal.Objects;
            }
            

            if (IdSucursal != null) //UPDATE con GetById para que muestre los datos del form para actualizar
            {
                ML.Result result = BL.Sucursal.GetByIdEF(IdSucursal.Value);
                if (result.Correct)
                {
                    sucursal = (ML.Sucursal)result.Object;
                    if (resultSucursal.Correct)
                    {
                        sucursal.Sucursales = resultSucursal.Objects;
                    }
                }
                else
                {
                    ViewBag.MensajeError = "Ocurrió un error al obtener la información del producto.";
                }
            }

            return View(sucursal);
        }

        [HttpPost]
        public ActionResult Form(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();

            if(sucursal.IdSucursal == 0)
            {
                result = BL.Sucursal.AddEF(sucursal);

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
                if (sucursal.IdSucursal >= 0)
                {
                    result = BL.Sucursal.UpdateEF(sucursal); //Actualizar

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

            return PartialView("Modal");
        }

        [HttpGet] //Eliminar
        public ActionResult Delete(int IdSucursal)
        {
            if(IdSucursal > 0)
            {
                ML.Result result = BL.Sucursal.DeleteEF(IdSucursal);

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
                ViewBag.Message = "IdProducto no es válido.";
            }

            return PartialView("Modal");
        }
    }
}