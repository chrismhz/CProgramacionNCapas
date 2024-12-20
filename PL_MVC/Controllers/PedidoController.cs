using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        [HttpGet]
        public ActionResult GetAllPe()
        {
            ML.Pedido pedido = new ML.Pedido();
            ML.Result result = BL.Pedido.GetAllEF();

            if (result.Correct)
            {
                pedido.Pedidos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GetAllPe", pedido);
        }

        [HttpPost]
        public ActionResult GetAllPe(ML.Pedido pedido)
        {

            ML.Result result = BL.Pedido.GetAllEF();

            if (result.Correct)
            {
                pedido.Pedidos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GeAllPe", pedido);
        }

        [HttpGet]
        public ActionResult Form(int? IdPedido)
        {
            ML.Pedido pedido = new ML.Pedido();

            pedido.Usuario = new ML.Usuario();
            pedido.Usuario.Rol = new ML.Rol();
            pedido.Usuario.Nombre = "";
            pedido.Usuario.ApellidoPaterno = "";
            pedido.Usuario.ApellidoMaterno = "";
            pedido.Usuario.Rol.IdRol = 0;

            ML.Result resultUsuario = BL.Usuario.GetAllEF(pedido.Usuario.Nombre, pedido.Usuario.ApellidoPaterno, pedido.Usuario.ApellidoMaterno, pedido.Usuario.Rol.IdRol);

            if (resultUsuario.Correct)
            {
                //usuario.Usuarios = result.Objects;
                pedido.Usuario.Usuarios = resultUsuario.Objects;

            }
            else
            {
                //pedido.Sucursal.Sucursales = new List<object>();
                pedido.Usuario.Usuarios = new List<object>();
            }

            ViewBag.Usuarios = new SelectList(pedido.Usuario.Usuarios, "IdUsuario", "Nombre", pedido.Usuario.IdUsuario);

            pedido.Usuario.Rol = new ML.Rol();//instanciar la propiedad de navegacion
            ML.Result resultRol = BL.Rol.GetAllRol();

            if (resultRol.Correct)
            {

                pedido.Usuario.Rol.Roles = resultRol.Objects;

            }
            else
            {
                pedido.Usuario.Rol.Roles = new List<object>();
            }

            ViewBag.Roles = new SelectList(pedido.Usuario.Rol.Roles, "IdRol", "Nombre", pedido.Usuario.Rol.IdRol);



            pedido.Sucursal = new ML.Sucursal();
            ML.Result resultSucursal = BL.Sucursal.GetAllEF();

            if (resultSucursal.Correct)
            {
                pedido.Sucursal.Sucursales = resultSucursal.Objects;
            }
            else
            {
                pedido.Sucursal.Sucursales = new List<object>();
            }

            ViewBag.Sucursales = new SelectList(pedido.Sucursal.Sucursales, "IdSucursal", "Nombre", pedido.Sucursal.IdSucursal);



            pedido.Direccion = new ML.Direccion();
            pedido.Direccion.Colonia = new ML.Colonia();
            pedido.Direccion.Colonia.Municipio = new ML.Municipio();
            pedido.Direccion.Colonia.Municipio.Estado = new ML.Estado();

            ML.Result resultEstado = BL.Estado.GetAllEstado(); //Consulta de Estados

            if (resultEstado.Correct)
            {
                pedido.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
            }



            pedido.TipoPago = new ML.TipoPago();
            ML.Result resultTipoPago = BL.TipoPago.GetAllEF();

            if (resultTipoPago.Correct)
            {
                pedido.TipoPago.TipoPagos = resultTipoPago.Objects;

            }
            else
            {
                pedido.TipoPago.TipoPagos = new List<object>();
            }

            ViewBag.TipoPagos = new SelectList(pedido.TipoPago.TipoPagos, "IdTipoPago", "Nombre", pedido.TipoPago.IdTipoPago);





            pedido.EstadoPedido = new ML.EstadoPedido();
            ML.Result resultEstadoPedido = BL.EstadoPedido.GetAllEF();

            if (resultEstadoPedido.Correct)
            {
                pedido.EstadoPedido.EstadosPedidos = resultEstadoPedido.Objects;
            }
            else
            {
                pedido.EstadoPedido.EstadosPedidos = new List<object>();
            }

            ViewBag.EstadoPedido = new SelectList(pedido.EstadoPedido.EstadosPedidos, "IdEstadoPedido", "Descripcion", pedido.EstadoPedido.IdEstadoPedido);





            pedido.Repartidor = new ML.Repartidor();
            ML.Result resultRepartidor = BL.Repartidor.GetAllEF();

            if (resultRepartidor.Correct)
            {
                pedido.Repartidor.Repartidores = resultRepartidor.Objects;

            }
            else
            {
                pedido.Repartidor.Repartidores = new List<object>();
            }

            ViewBag.Repartidor = new SelectList(pedido.Repartidor.Repartidores, "IdRepartidor", "Nombre", pedido.Repartidor.IdRepartidor);


            return View(pedido);
        }

        [HttpPost]
        public ActionResult Form(ML.Pedido pedido)
        {
            HttpPostedFileBase file = Request.Files["ImagenUsuario"]; //recibir imagen

            if (file != null && file.ContentLength > 0)
            {
                pedido.Usuario.Imagen = ConvertirAArrayBytes(file); //convertir imagen a byte[]
            }

            ML.Result result = new ML.Result();

            if (pedido.IdPedido == 0)
            {
                result = BL.Pedido.AddEF(pedido);

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
                if(pedido.IdPedido >= 0)
                {
                    result = BL.Pedido.UpdateEF(pedido);

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


            return View(pedido);
        }

        [HttpGet]
        public JsonResult GetMunicipiosGetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetColoniasGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertirAArrayBytes(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            return data;
        }
    }
}