using BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Excel()
        {
            //GetAll
            HttpPostedFileBase excel = Request.Files["excel"]; //cachando el archivo
            string extension = Path.GetExtension(excel.FileName); //obteniendo la extencion del archivo

            string extensionWebConfig = ConfigurationManager.AppSettings["ExtensionExcel"]; //obteniendo la extension desde el WebConfig

            if (Session["RutaExcel"] == null)
            {
                if (extensionWebConfig == extension)
                {
                    //El archivo es un excel
                    string pathExcel = Server.MapPath("~/CargaMasiva/") + Path.GetFileNameWithoutExtension(excel.FileName) + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx";

                    if (!System.IO.File.Exists(pathExcel))
                    {
                        excel.SaveAs(pathExcel);//guardando el archivo

                        string cadenaConexion = ConfigurationManager.ConnectionStrings["OleDbConnection"].ToString() + pathExcel; //haciendo cadena de conexion

                        ML.Result resultLeerExcel = BL.Usuario.LeerExcel(cadenaConexion);
                        if (resultLeerExcel.Correct)
                        {
                            //INSERT EXCEL
                            ML.Result resultValidar = BL.Usuario.ValidarExcel(resultLeerExcel.Objects);
                            if (resultValidar.Objects.Count != 0)
                            {
                                //Todo esta bien
                                Session["RutaExcel"] = pathExcel;
                            }
                            else
                            {
                                //hubo un error
                                //imprimir errores en la vista
                                foreach (ML.ResultExcel item in resultValidar.Objects)
                                {
                                    //Imprimir el mensaje de error
                                    ViewBag.Error += $"Registro {item.NumeroRegistro}: {item.MensajeError}";
                                }
                                return PartialView("~/Views/Usuario/Modal.cshtml");
                            }
                        }
                        else
                        {
                            //Vista Modal
                            //Error al leer el archivo Excel
                            ViewBag.Error = "Error al leer el Excel";
                            return PartialView("~/Views/Usuario/Modal.cshtml");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Ya existe ese archivo";
                        return PartialView("~/Views/Usuario/Modal.cshtml");
                    }
                }
                else
                {
                    ViewBag.Error = "No se ingreso un archivo .xlsx";
                    return PartialView("~/Views/Usuario/Modal.cshtml");
                }
                ViewBag.Message = "Registros leidos correctamente";
            }
            else
            {
                //leer el excel para insertar
                string cadenaConexion = ConfigurationManager.ConnectionStrings["OleDbConnection"].ToString() + Session["RutaExcel"];//haciendo cadena de conexion

                ML.Result resultLeerExcel = BL.Usuario.LeerExcel(cadenaConexion);

                if (resultLeerExcel.Correct)
                {
                    //insertar
                    foreach (ML.Usuario usuario in resultLeerExcel.Objects)
                    {
                        ML.Result result = BL.Usuario.AddEF(usuario);

                        if (!result.Correct)
                        {
                            //Mostrar mensajes de error al cliente

                        }
                    }
                    ViewBag.Message = "Registros insertados exitosamente";
                }
                Session["pathExcel"] = null;
            }
            //return RedirectToAction("GetAll", "Usuario");
            return PartialView("~/Views/Usuario/Modal.cshtml");
        }
    }
}   
