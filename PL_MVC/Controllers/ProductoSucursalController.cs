using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PL_MVC.Controllers
{
    public class ProductoSucursalController : Controller
    {
        // GET: ProductoSucursal

        [HttpGet]
        public ActionResult GetAllPS()
        {
            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
            productoSucursal.Sucursal = new ML.Sucursal();
            productoSucursal.Sucursal.IdSucursal = 0;

            ML.Result result = BL.ProductoSucursal.GetAllEF(productoSucursal.Sucursal.IdSucursal);

            if (result.Correct)
            {
                productoSucursal.ProductosSucursales = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros" + result.ErrorMessage;
            }

            
            productoSucursal.Sucursal = new ML.Sucursal();
            ML.Result resultSucursal = BL.Sucursal.GetAllEF();

            if (resultSucursal.Correct)
            {
                productoSucursal.Sucursal.Sucursales = resultSucursal.Objects;

            }
            else
            {
                productoSucursal.Sucursal.Sucursales = new List<object>();
            }

            ViewBag.Sucursales = new SelectList(productoSucursal.Sucursal.Sucursales, "IdSucursal", "Nombre", productoSucursal.Sucursal.IdSucursal);

            return View(productoSucursal);
        }

        [HttpPost]
        public ActionResult GetAllPS(ML.ProductoSucursal productoSucursal)
        {
            productoSucursal.Sucursal.IdSucursal = productoSucursal.Sucursal.IdSucursal !=0 ? productoSucursal.Sucursal.IdSucursal : 0;

            ML.Result result = BL.ProductoSucursal.GetAllEF(productoSucursal.Sucursal.IdSucursal);

            if (result.Correct)
            {
                productoSucursal.ProductosSucursales = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros" + result.ErrorMessage;
            }

            productoSucursal.Sucursal = new ML.Sucursal();
            ML.Result resultSucursal = BL.Sucursal.GetAllEF();

            if (resultSucursal.Correct)
            {
                productoSucursal.Sucursal.Sucursales = resultSucursal.Objects;
            }
            else
            {
                productoSucursal.Sucursal.Sucursales = new List<object>();
            }

            ViewBag.Sucursales = new SelectList(productoSucursal.Sucursal.Sucursales, "IdSucursal", "Nombre", productoSucursal.Sucursal.IdSucursal);

            return View(productoSucursal);
        }

        [HttpPost]
        public ActionResult UpdatePS(int IdProductoSucursal, int Stock)
        {
            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
            productoSucursal.IdProductoSucursal = IdProductoSucursal;
            productoSucursal.Stock = Stock;

            ML.Result result = BL.ProductoSucursal.UpdateEF(productoSucursal);

            if (result.Correct)
            {
                ViewBag.Message = "El Stock se actualizó correctamente";
            }
            else
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View("Error");
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult DeletePS(int IdProductoSucursal)
        {
            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal { IdProductoSucursal = IdProductoSucursal };

            ML.Result result = BL.ProductoSucursal.DeleteEF(IdProductoSucursal);

            if (result.Correct)
            {
                ViewBag.Message = "El registro se eliminó correctamente.";
            }
            else
            {
                ViewBag.MensajeError = "No se pudo eliminar: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        /*[HttpPost]
        public ActionResult UpdatePS(int IdProductoSucursal, int Stock)
        {
            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
            productoSucursal.IdProductoSucursal = IdProductoSucursal;
            productoSucursal.Stock = Stock;

            ML.Result result = BL.ProductoSucursal.UpdateEF(productoSucursal);

            if (result.Correct)
            {
                ViewBag.Message = "El Stock se actualizo correctamente";
            }
            else
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View("Error");
            }
            return PartialView("Modal");
        }*/

        /* [HttpGet]
         public ActionResult GetAllPS()
         {
             ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
             ML.Result resultSucursal = BL.Sucursal.GetAllEF();

             if (resultSucursal.Correct)
             {
                 productoSucursal.Sucursal = new ML.Sucursal();
                 productoSucursal.Sucursal.Sucursales = resultSucursal.Objects;
                 productoSucursal.Sucursal.IdSucursal = -1;
             }
             else
             {
                 ViewBag.MensajeError = "No se encontraron registros " + resultSucursal.ErrorMessage;
             }

             ML.Result resultProductos = BL.ProductoSucursal.GetAllEF();

             if (resultProductos.Correct)
             {
                 productoSucursal.ProductosSucursales = resultProductos.Objects;
             }
             else
             {
                 ViewBag.MensajeError = "No se encontraron registros " + resultProductos.ErrorMessage;
             }

             return View(productoSucursal);
         }

         [HttpPost]
         public ActionResult GetAllPS(ML.ProductoSucursal productosucursal)
         {
             if (productosucursal.Sucursal != null && productosucursal.Sucursal.IdSucursal > 0)
             {
                 ML.Result resultSucursal = BL.ProductoSucursal.GetByIdSucursalEF(productosucursal.Sucursal.IdSucursal);

                 if (resultSucursal.Correct)
                 {
                     productosucursal.ProductosSucursales = resultSucursal.Objects;
                 }
             }
             else
             {
                 ML.Result resultAllSucursales = BL.ProductoSucursal.GetAllEF();

                 if (resultAllSucursales.Correct)
                 {
                     productosucursal.ProductosSucursales = resultAllSucursales.Objects;
                 }
                 else
                 {
                     ViewBag.MensajeError = "No se encontraron registros " + resultAllSucursales.ErrorMessage;
                 }
             }

             ML.Result resultSucursales = BL.Sucursal.GetAllEF();

             if (resultSucursales.Correct)
             {
                 productosucursal.Sucursal.Sucursales = resultSucursales.Objects;
             }

             return View(productosucursal);

         }*/

        /*[HttpPost]
        public ActionResult UpdatePS(int IdProductoSucursal, int Stock)
        {
            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
            productoSucursal.IdProductoSucursal = IdProductoSucursal;
            productoSucursal.Stock = Stock;

            ML.Result resultUpdate = BL.ProductoSucursal.UpdateEF(productoSucursal);

            if (resultUpdate.Correct)
            {
                ViewBag.Message = "El Stock se actualizo correctamente";
            }
            else
            {
                ViewBag.ErrorMessage = resultUpdate.ErrorMessage;
                return View("Error");
            }
            return PartialView("Modal");
        }*/

        /*[HttpPost]
        public ActionResult UpdatePS(int IdProductoSucursal, int Stock)
        {
            // Obtener el objeto ProductoSucursal por su Id
            ML.Result result = BL.ProductoSucursal.GetByIdEF(IdProductoSucursal);

            if (result.Correct)
            {
                ML.ProductoSucursal productoSucursal = (ML.ProductoSucursal)result.Object;  // Obtén el objeto ProductoSucursal

                // Actualiza el stock
                //productoSucursal.Stock = Stock;

                // Llama al método de actualización en la capa de negocio
                ML.Result resultUpdate = BL.ProductoSucursal.UpdateEF(productoSucursal);

                if (resultUpdate.Correct)
                {
                    ViewBag.Message = "El Stock se actualizó correctamente";
                    return PartialView("Modal"); // Modal con mensaje de éxito
                }
                else
                {
                    ViewBag.ErrorMessage = resultUpdate.ErrorMessage;
                    return View("Error"); // Vista de error en caso de fallo en la actualización
                }
            }
            else
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View("Error"); // Vista de error si no se encuentra el ProductoSucursal
            }
            return PartialView("Modal");
        }*/



    }
}