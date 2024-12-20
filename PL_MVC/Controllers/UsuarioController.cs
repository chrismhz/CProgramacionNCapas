using Microsoft.AspNet.Identity;
using ML;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        // GET: Usuario
        [HttpGet] //Mostrar todos los registros de la tabla Usuarios
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Nombre = "";
            usuario.ApellidoPaterno =  "";
            usuario.ApellidoMaterno = "";
            usuario.Rol.IdRol =  0;

            ML.Result result = BL.Usuario.GetAllEF(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Rol.IdRol);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            usuario.Rol = new ML.Rol();//instanciar la propiedad de navegacion
            ML.Result resultRol = BL.Rol.GetAllRol();

            if (resultRol.Correct)
            {
                usuario.Rol.Roles = resultRol.Objects;

            }
            else
            {
                usuario.Rol.Roles = new List<object>();
            }

            ViewBag.Roles = new SelectList(usuario.Rol.Roles, "IdRol", "Nombre", usuario.Rol.Roles);

            return View(usuario);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            usuario.Nombre = usuario.Nombre ?? "";
            usuario.ApellidoPaterno = usuario.ApellidoPaterno ?? "";
            usuario.ApellidoMaterno = usuario.ApellidoMaterno ?? "";
            usuario.Rol.IdRol = usuario.Rol.IdRol != 0 ? usuario.Rol.IdRol : 0;

            ML.Result result = BL.Usuario.GetAllEF(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Rol.IdRol);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            usuario.Rol = new ML.Rol();//instanciar la propiedad de navegacion
            ML.Result resultRol = BL.Rol.GetAllRol();

            if (resultRol.Correct)
            {
                usuario.Rol.Roles = resultRol.Objects;

            }
            else
            {
                usuario.Rol.Roles = new List<object>();
            }

            ViewBag.Roles = new SelectList(usuario.Rol.Roles, "IdRol", "Nombre", usuario.Rol.Roles);

            return View(usuario);
        }

        [HttpGet] //Mostrar el formulario/View
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

            ML.Result resultEstado = BL.Estado.GetAllEstado(); //Consulta de Estados

            if (resultEstado.Correct)
            {
                usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
            }

            usuario.Rol = new ML.Rol();//instanciar la propiedad de navegacion
            ML.Result resultRol = BL.Rol.GetAllRol();

            if (resultRol.Correct)
            {
                usuario.Rol.Roles = resultRol.Objects;
                
            }
            else
            {
                usuario.Rol.Roles = new List<object>();
            }

            ViewBag.Roles = new SelectList(usuario.Rol.Roles, "IdRol", "Nombre", usuario.Rol.Roles);


            if (IdUsuario != null) //UPDATE
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object; //Unboxing
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    usuario.Rol.Roles = resultRol.Objects;

                    ML.Result resultMunicipios = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);

                    if (resultMunicipios.Correct)
                    {
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                    }

                    ML.Result resultColonias = BL.Colonia.ColoniaGetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                    if (resultColonias.Correct)
                    {
                        usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                    }
                }
                else
                {
                    ViewBag.MensajeError = "Ocurrio un error al traer la informacion de la materia";
                }
            }

            return View(usuario);
        }

        [HttpPost] //Guarda o Actualiza
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid) //Co
            {
                HttpPostedFileBase file = Request.Files["ImagenUsuario"]; //recibir imagen

                if (file != null && file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirAArrayBytes(file); //convertir imagen a byte[]
                }

                ML.Result result = new ML.Result();

                DateTime auxiliar = DateTime.ParseExact(usuario.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                usuario.FechaNacimiento = auxiliar.ToString("yyyy/MM/dd");

                if (usuario.IdUsuario == null || usuario.IdUsuario == 0)
                {
                    result = BL.Usuario.AddEF(usuario); //Agregar

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
                    if (usuario.IdUsuario >= 0)
                    {
                        result = BL.Usuario.UpdateEF(usuario); //Actualizar

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
            }
            
            return PartialView("Modal");
        }

        [HttpGet] //Eliminar
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            if (usuario.IdUsuario == 0)
            {
                ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se ha eliminado correctamente";
                }
                else
                {
                    ViewBag.Message = "Hubo un error a la hora de hacer la eliminacion";
                }
            }
            return PartialView("Modal");
        }

        public byte[] ConvertirAArrayBytes(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            return data;
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

        [HttpPost]
        public JsonResult ChangeStatus(int IdUsuario, bool Status)
        {
            ML.Result result = BL.Usuario.CambiarStatus(IdUsuario, Status);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

    