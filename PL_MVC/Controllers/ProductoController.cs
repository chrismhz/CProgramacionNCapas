using Microsoft.Ajax.Utilities;
using Microsoft.Win32;
using ML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////-- Producto Normal con Tablas --//////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: Producto con Tabla
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.IdSubCategoria = 0;
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.IdCategoria = 0;

            ML.Result result = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();

            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }



            return View(producto);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Producto producto)
        {
            producto.SubCategoria.IdSubCategoria = producto.SubCategoria.IdSubCategoria != 0 ? producto.SubCategoria.IdSubCategoria : 0;
            //producto.SubCategoria.Categoria.IdCategoria = producto.SubCategoria.Categoria.IdCategoria != 0 ? producto.SubCategoria.Categoria.IdCategoria : 0;

            ML.Result result = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }


            return View(producto);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////-- Proyecto Normal con CARDS --////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public ActionResult GetAllC()
        {
            ML.Producto producto = new ML.Producto(); //A partir de aqui
            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.IdSubCategoria = 0;
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.IdCategoria = 0;

            ML.Result result = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();

            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }

            return View("GetAllC", producto);
        }

        [HttpPost]
        public ActionResult GetAllC(ML.Producto producto)
        {
            producto.SubCategoria.IdSubCategoria = producto.SubCategoria.IdSubCategoria != 0 ? producto.SubCategoria.IdSubCategoria : 0;
            //producto.SubCategoria.Categoria.IdCategoria = producto.SubCategoria.Categoria.IdCategoria != 0 ? producto.SubCategoria.Categoria.IdCategoria : 0;

            ML.Result result = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);
            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros: " + result.ErrorMessage;
            }

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();
            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }

            return View("GetAllC", producto);
        }

        [HttpGet] //Mostrar el formulario/View
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();

            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();

            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }

            //ViewBag.Categorias = new SelectList(producto.SubCategoria.Categoria.Categorias, "IdCategoria", "Nombre");

            if (IdProducto != null) // UPDATE
            {
                ML.Result result = BL.Producto.GetByIdEF(IdProducto.Value);

                if (result.Correct)
                {
                    producto = (ML.Producto)result.Object;
                    producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;

                    ML.Result resultSubCategorias = BL.SubCategoria.SubCategoriaGetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);
                    if (resultSubCategorias.Correct)
                    {
                        producto.SubCategoria.SubCategorias = resultSubCategorias.Objects;
                    }

                }
                else
                {
                    ViewBag.MensajeError = "Ocurrió un error al obtener la información del producto.";
                }
            }

            return View(producto);
        }

        [HttpPost] //Guarda o Actualiza
        public ActionResult Form(ML.Producto producto)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImagenProducto"]; //recibir imagen

                if (file != null && file.ContentLength > 0)
                {
                    producto.Imagen = ConvertirAArrayBytes(file); //convertir imagen a byte[]
                }


                ML.Result result = new ML.Result();

                if (producto.IdProducto == null || producto.IdProducto == 0)
                {
                    result = BL.Producto.AddEF(producto); //Agregar

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
                    if (producto.IdProducto >= 0)
                    {
                        result = BL.Producto.UpdateEF(producto); //Actualizar

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
        public ActionResult Delete(int IdProducto)
        {
            if (IdProducto > 0)
            {
                ML.Result result = BL.Producto.DeleteEF(IdProducto);

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

        public JsonResult GetSubCategoriasByIdCategorias(int IdCategoria)
        {
            ML.Result result = new ML.Result();
            result = BL.SubCategoria.SubCategoriaGetByIdCategoria(IdCategoria);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertirAArrayBytes(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            return data;
        }


        ///////////////////////////////////////////////////////////// SOAP ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////--- Producto con Cards Listo ---///////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //--- ------------------------------------------------------GetAll Listo---------------------------------------------------------//

        /* [HttpGet] //GetAll
         public ActionResult GetAllC()
         {
             string action = "http://tempuri.org/IProducto/GetAllEF";
             string url = "http://localhost:3012/Producto.svc"; // Cambia a la URL del servicio
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
             request.Headers.Add("SOAPAction", action);
             request.ContentType = "text/xml;charset=\"utf-8\"";
             request.Accept = "text/xml";
             request.Method = "POST"; // Cambia a POST ya que estás usando un servicio SOAP

             // Crear el sobre SOAP
             string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
             <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
                <soapenv:Header/>
                <soapenv:Body>
                   <tem:GetAllEF>
                      <!--Optional:-->
                      <tem:IdSubcategoria>0</tem:IdSubcategoria>
                   </tem:GetAllEF>
                </soapenv:Body>
             </soapenv:Envelope>";

             // Enviar la solicitud
             using (Stream stream = request.GetRequestStream())
             {
                 byte[] content = Encoding.UTF8.GetBytes(soapEnvelope);
                 stream.Write(content, 0, content.Length);
             }

             // Obtener la respuesta
             try
             {
                 using (WebResponse response = request.GetResponse())
                 {
                     using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                     {
                         string result = reader.ReadToEnd();
                         Console.WriteLine("Respuesta SOAP:");
                         Console.WriteLine(result);

                         // Deserializar el XML
                         ML.Producto producto = new ML.Producto();
                         producto.SubCategoria = new ML.SubCategoria();
                         producto.SubCategoria.IdSubCategoria = 0;
                         producto.SubCategoria.SubCategorias = new List<object>();
                         producto.SubCategoria.Categoria = new ML.Categoria();
                         producto.SubCategoria.Categoria.Categorias = new List<object>();

                         var productos = GetAllEF(result); // Captura el objeto completo
                         if (productos == null || productos.Productos.Count == 0)
                         {
                             ViewBag.Error = "No se encontraron productos.";
                         }
                         else
                         {
                             // Aquí llenas tus listas de Categorías y Subcategorías
                             ML.Result resultCategoria = BL.Categoria.GetAllCategoria();
                             if (resultCategoria.Correct)
                             {
                                 productos.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
                             }
                             else
                             {
                                 productos.SubCategoria.Categoria.Categorias = new List<object>();
                             }

                             return View("GetAllC", productos); // Llamas a la vista con los datos deserializados
                         }
                     }
                 }
             }
             catch (WebException ex)
             {
                 Console.WriteLine($"Error: {ex.Message}");
                 ViewBag.Error = ex.Message; // Para mostrar en la vista si es necesario
             }

             return View(); // Devuelve la vista
         }

             private ML.Producto GetAllEF(string xml)
             {
             var producto1 = new ML.Producto();
             producto1.Productos = new List<object>();
             producto1.SubCategoria = new ML.SubCategoria();
             producto1.SubCategoria.IdSubCategoria = 0;
             producto1.SubCategoria.Categoria = new ML.Categoria();
             producto1.SubCategoria.Categoria.Categorias = new List<object>();


             var xdoc = XDocument.Parse(xml);

             // Acceder a GetAllProductoResult
             //var elementos = xdoc.Descendants("{http://schemas.datacontract.org/2004/07/ML}Producto");
             XNamespace objetcs = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
             var elementos = xdoc.Descendants(objetcs + "anyType");

             foreach (var elem in elementos)
             {
                 var producto = new ML.Producto();
                 producto.SubCategoria = new ML.SubCategoria();
                 producto.SubCategoria.Categoria = new ML.Categoria();

                 // Manejo de IdUsuario
                 int idProducto;
                 int.TryParse(elem.Element("{http://schemas.datacontract.org/2004/07/ML}IdProducto")?.Value, out idProducto);
                 producto.IdProducto = idProducto;

                 producto.Nombre = (string)(elem.Element("{http://schemas.datacontract.org/2004/07/ML}Nombre")?.Value ?? string.Empty);

                 producto.Descripcion = (string)(elem.Element("{http://schemas.datacontract.org/2004/07/ML}Descripcion")?.Value ?? string.Empty);

                 producto.Precio = decimal.TryParse(elem.Element("{http://schemas.datacontract.org/2004/07/ML}Precio")?.Value, out var precio) ? precio : 0;

                 string imagen = (string)(elem.Element("{http://schemas.datacontract.org/2004/07/ML}Imagen")?.Value ?? string.Empty);
                     producto.Imagen = (imagen == "" ? null : Convert.FromBase64String(imagen));

                 XElement SubCategoria = elem.Element("{http://schemas.datacontract.org/2004/07/ML}SubCategoria");
                 producto.SubCategoria.Nombre = SubCategoria.Element("{http://schemas.datacontract.org/2004/07/ML}Nombre").Value;

                 XElement Categoria = SubCategoria.Element("{http://schemas.datacontract.org/2004/07/ML}Categoria");
                 producto.SubCategoria.Categoria.Nombre = Categoria.Element("{http://schemas.datacontract.org/2004/07/ML}Nombre").Value;

                 producto1.Productos.Add(producto);
             }

             return producto1;// Devuelve el objeto completo
         }

         [HttpPost]
         public ActionResult GetAllC(ML.Producto producto)
         {
             producto.SubCategoria.IdSubCategoria = producto.SubCategoria.IdSubCategoria != 0 ? producto.SubCategoria.IdSubCategoria : 0;

             ML.Result result = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);
             if (result.Correct)
             {
                 producto.Productos = result.Objects;
             }
             else
             {
                 ViewBag.MensajeError = "No se encontraron registros: " + result.ErrorMessage;
             }

             ML.Result resultCategoria = BL.Categoria.GetAllCategoria();
             if (resultCategoria.Correct)
             {
                 producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
             }
             else
             {
                 producto.SubCategoria.Categoria.Categorias = new List<object>();
             }

             return View("GetAllC", producto);
         }*/

        // -----------------------------------------------Insertar - Actualizar - GetById Listo------------------------------------------//

        /*[HttpGet] //Insert-Update Este no se descomenta
        public ActionResult Form()
        {
            ML.Producto producto = new ML.Producto();

            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();

            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }

            //ViewBag.Categorias = new SelectList(producto.SubCategoria.Categoria.Categorias, "IdCategoria", "Nombre");

            return View(producto);
        }*/

        /*[HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();

            if (IdProducto.HasValue)
            {
                // Obtener el usuario por ID
                string action = "http://tempuri.org/IProducto/GetByIdEF";
                string url = "http://localhost:3012/Producto.svc";

                // Crear el sobre SOAP para obtener un usuario por su ID
                string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <tem:GetByIdEF>
                         <!--Optional:-->
                         <tem:IdProducto>{IdProducto}</tem:IdProducto>
                      </tem:GetByIdEF>
                   </soapenv:Body>
                </soapenv:Envelope>";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("SOAPAction", action);
                request.ContentType = "text/xml;charset=\"utf-8\"";
                request.Accept = "text/xml";
                request.Method = "POST";

                // Enviar la solicitud
                using (Stream stream = request.GetRequestStream())
                {
                    byte[] content = Encoding.UTF8.GetBytes(soapEnvelope);
                    stream.Write(content, 0, content.Length);
                }

                // Obtener la respuesta
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string result = reader.ReadToEnd();
                            Console.WriteLine("Respuesta SOAP:");
                            Console.WriteLine(result);

                            // Deserializar el usuario
                            producto = GetProductoById(result);
                        }
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    ViewBag.Error = ex.Message; // Para mostrar en la vista si es necesario
                }
            }
            else
            {
                producto.SubCategoria = new ML.SubCategoria();
                producto.SubCategoria.SubCategorias = new List<object>();

                producto.SubCategoria.Categoria = new ML.Categoria();
                producto.SubCategoria.Categoria.Categorias = new List<object>();

                ML.Result resultCategoria = BL.Categoria.GetAllCategoria();
                if (resultCategoria.Correct)
                    producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;

                ML.Result resultSubCategorias = BL.SubCategoria.SubCategoriaGetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);

                if (resultSubCategorias.Correct)
                    producto.SubCategoria.SubCategorias = resultSubCategorias.Objects;

            }

            return View(producto); // Devuelve la vista con el usuario si existe
        }

        private ML.Producto GetProductoById(string xml)
        {
            var xdoc = XDocument.Parse(xml);
            // Acceder a GetUsuarioByIdResult usando el namespace correcto
            var productoElement = xdoc.Descendants().FirstOrDefault(e =>
                e.Name.LocalName == "Object" &&
                e.GetDefaultNamespace().NamespaceName == "http://tempuri.org/");

            if (productoElement != null)
            {
                ML.Producto producto = new ML.Producto();
                producto.SubCategoria = new ML.SubCategoria();
                producto.SubCategoria.Categoria = new ML.Categoria();

                int idProducto;
                int.TryParse(productoElement.Element("{http://schemas.datacontract.org/2004/07/ML}IdProducto")?.Value, out idProducto);
                producto.IdProducto = idProducto;

                producto.Nombre = (string)(productoElement.Element("{http://schemas.datacontract.org/2004/07/ML}Nombre")?.Value ?? string.Empty);

                producto.Descripcion = (string)(productoElement.Element("{http://schemas.datacontract.org/2004/07/ML}Descripcion")?.Value ?? string.Empty);

                decimal precio;
                decimal.TryParse(productoElement.Element("{http://schemas.datacontract.org/2004/07/ML}Precio")?.Value, out precio);
                producto.Precio = precio;

                string ImagenString = (string)(productoElement.Element("{http://schemas.datacontract.org/2004/07/ML}Imagen")?.Value ?? string.Empty);
                producto.Imagen = (ImagenString == "" ? null : Convert.FromBase64String(ImagenString));

                XElement subcategoria = productoElement.Element("{http://schemas.datacontract.org/2004/07/ML}SubCategoria");
                producto.SubCategoria.IdSubCategoria = Convert.ToInt32(subcategoria.Element("{http://schemas.datacontract.org/2004/07/ML}IdSubCategoria").Value);
                producto.SubCategoria.Nombre = subcategoria.Element("{http://schemas.datacontract.org/2004/07/ML}Nombre").Value;

                XElement categoria = subcategoria.Element("{http://schemas.datacontract.org/2004/07/ML}Categoria");
                producto.SubCategoria.Categoria.IdCategoria = Convert.ToInt32(categoria.Element("{http://schemas.datacontract.org/2004/07/ML}IdCategoria").Value);
                producto.SubCategoria.Categoria.Nombre = categoria.Element("{http://schemas.datacontract.org/2004/07/ML}Nombre").Value;

                ML.Result resultCategoria = BL.Categoria.GetAllCategoria();
                if (resultCategoria.Correct)
                    producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;

                ML.Result resultSubCategorias = BL.SubCategoria.SubCategoriaGetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);

                if (resultSubCategorias.Correct)
                    producto.SubCategoria.SubCategorias = resultSubCategorias.Objects;

                return producto;
            }

            return null; // O lanzar una excepción si no se encontró el usuario
        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            string url = "http://localhost:3012/Producto.svc"; // URL del servicio
            string soapEnvelope;
            string action; // Declarar la variable action aquí

            HttpPostedFileBase file = Request.Files["ImagenProducto"]; //recibir imagen

            if (file != null && file.ContentLength > 0)
            {
                producto.Imagen = ConvertirAArrayBytes(file); //convertir imagen a byte[]
            }

            // Verificar si IdUsuario es null o 0 (o algún valor que determines como "nuevo")
            if (producto.IdProducto == null || producto.IdProducto == 0)
            {
                // Crear el sobre SOAP para agregar un nuevo usuario
                action = "http://tempuri.org/IProducto/AddEF";
                soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ml=""http://schemas.datacontract.org/2004/07/ML"" xmlns:arr=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <tem:AddEF>
                         <!--Optional:-->
                         <tem:producto>
                            <!--Optional:-->
                            <ml:Descripcion>{producto.Descripcion}</ml:Descripcion>
                            <!--Optional:-->
                            <ml:Imagen>{Convert.ToBase64String(producto.Imagen)}</ml:Imagen>
                            <!--Optional:-->
                            <ml:Nombre>{producto.Nombre}</ml:Nombre>
                            <!--Optional:-->
                            <ml:Precio>{producto.Precio}</ml:Precio>
                            <!--Optional:-->
                            <ml:SubCategoria>
                               <!--Optional:-->
                               <ml:Categoria>
                                  <!--Optional:-->
                                  <ml:IdCategoria>{producto.SubCategoria.Categoria.IdCategoria}</ml:IdCategoria>
                               </ml:Categoria>
                               <!--Optional:-->
                               <ml:IdSubCategoria>{producto.SubCategoria.IdSubCategoria}</ml:IdSubCategoria>
                               <!--Optional:-->
                            </ml:SubCategoria>
                         </tem:producto>
                      </tem:AddEF>
                   </soapenv:Body>
                </soapenv:Envelope>";
            }
            else
            {
                // Crear el sobre SOAP para actualizar un usuario existente
                action = "http://tempuri.org/IProducto/UpdateEF";
                soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ml=""http://schemas.datacontract.org/2004/07/ML"" xmlns:arr=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <tem:UpdateEF>
                         <!--Optional:-->
                         <tem:producto>
                            <!--Optional:-->
                            <ml:Descripcion>{producto.Descripcion}</ml:Descripcion>
                            <!--Optional:-->
                            <ml:IdProducto>{producto.IdProducto}</ml:IdProducto>
                            <!--Optional:-->
                           <ml:Imagen>{Convert.ToBase64String(producto.Imagen)}</ml:Imagen>
                            <!--Optional:-->
                             <ml:Nombre>{producto.Nombre}</ml:Nombre>
                            <!--Optional:-->
                             <ml:Precio>{producto.Precio}</ml:Precio>
                            <!--Optional:-->
                            <ml:SubCategoria>
                               <!--Optional:-->
                               <ml:Categoria>
                                  <!--Optional:-->
                                  <ml:IdCategoria>{producto.SubCategoria.Categoria.IdCategoria}</ml:IdCategoria>
                               </ml:Categoria>
                               <!--Optional:-->
                               <ml:IdSubCategoria>{producto.SubCategoria.IdSubCategoria}</ml:IdSubCategoria>
                            </ml:SubCategoria>
                         </tem:producto>
                      </tem:UpdateEF>
                   </soapenv:Body>
                </soapenv:Envelope>";
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("SOAPAction", action); // Aquí ya existe la variable action
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            // Enviar la solicitud
            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = Encoding.UTF8.GetBytes(soapEnvelope);
                stream.Write(content, 0, content.Length);
            }

            // Obtener la respuesta
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd();
                        Console.WriteLine("Respuesta SOAP:");
                        Console.WriteLine(result);
                        // Aquí puedes manejar la respuesta según sea necesario
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ViewBag.Error = ex.Message; // Para mostrar en la vista si es necesario
            }

            return RedirectToAction("GetAllC"); // Redirigir a la lista de usuarios después de agregar o actualizar
        }*/

        //---------------------------------------------------------Delete----------------------------------------------------------------//

        /*[HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            string url = "http://localhost:3012/Producto.svc"; // URL del servicio
            string action = "http://tempuri.org/IProducto/DeleteEF"; // Declarar la variable action aquí

            // Crear el sobre SOAP para actualizar un usuario existente
            string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
               <soapenv:Header/>
               <soapenv:Body>
                  <tem:DeleteEF>
                     <!--Optional:-->
                     <tem:IdProducto>{IdProducto}</tem:IdProducto>
                  </tem:DeleteEF>
               </soapenv:Body>
            </soapenv:Envelope>";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("SOAPAction", action); // Aquí ya existe la variable action
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            // Enviar la solicitud
            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = Encoding.UTF8.GetBytes(soapEnvelope);
                stream.Write(content, 0, content.Length);
            }

            // Obtener la respuesta
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd();
                        Console.WriteLine("Respuesta SOAP:");
                        Console.WriteLine(result);

                        XElement envelope = XElement.Parse(result);

                        bool correctDelete = envelope.Elements("{http://schemas.xmlsoap.org/soap/envelope/}Body")
                                          .Elements("{http://tempuri.org/}DeleteResponse")
                                          .Elements("{http://tempuri.org/}DeleteResult")
                                          .Elements("{http://schemas.datacontract.org/2004/07/SL_WCF}Correct")
                                          .Where(x => x.Value == "true")
                                          .Any();

                        // Aquí puedes manejar la respuesta según sea necesario
                        if (correctDelete)
                        {
                            ViewBag.Message = "Error al eliminar el producto";
                        }
                        else
                        {
                            ViewBag.Message = "El producto fue eliminado correctamente";
                            
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ViewBag.Error = ex.Message; // Para mostrar en la vista si es necesario
            }

            return PartialView("Modal");
        }*/


        ////////////////////////////////////////////////////////// REST ///////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////WebApi con Productos Cards ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //--- ------------------------------------------------------GetAll Listo---------------------------------------------------------//
        /*[HttpGet] //GetAll
        public ActionResult GetAllC() //GetAll
        {
            ML.Producto producto = new ML.Producto(); //A partir de aqui
            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.IdSubCategoria = 0;
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.IdCategoria = 0;

            ML.Result result = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();

            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }

            ML.Producto productoVista = new ML.Producto();
            productoVista.Productos = new List<object>();

            using (var client = new HttpClient())
            {
                string endPoint = ConfigurationManager.AppSettings["ProductoEndPoint"];
                client.BaseAddress = new Uri(endPoint);

                int idSubcategoria = producto.SubCategoria.IdSubCategoria != 0 ? producto.SubCategoria.IdSubCategoria : 0;

                var responseTask = client.GetAsync($"GetAll?IdSubcategoria={idSubcategoria}");
                responseTask.Wait();

                var resultt = responseTask.Result;

                if (resultt.IsSuccessStatusCode)
                {
                    var readTask = resultt.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        productoVista.Productos.Add(resultItemList);
                    }
                }

            }

            return View("GetAllC", producto);
        }

        [HttpPost]
        public ActionResult GetAllC(ML.Producto producto)
        {
            producto.SubCategoria.IdSubCategoria = producto.SubCategoria.IdSubCategoria != 0 ? producto.SubCategoria.IdSubCategoria : 0;

            ML.Result result = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);
            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros: " + result.ErrorMessage;
            }

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();
            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }

            return View("GetAllC", producto);
        }*/

        //--- -----------------------------------------------------GetById Listo---------------------------------------------------------//
        /*[HttpGet] //Mostrar el formulario/View
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();

            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();

            ML.Result resultCategoria = BL.Categoria.GetAllCategoria();

            if (resultCategoria.Correct)
            {
                producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;
            }
            else
            {
                producto.SubCategoria.Categoria.Categorias = new List<object>();
            }

            //ViewBag.Categorias = new SelectList(producto.SubCategoria.Categoria.Categorias, "IdCategoria", "Nombre");

            if (IdProducto != null) // UPDATE
            {
                //ML.Result result = BL.Producto.GetByIdEF(IdProducto.Value);
                ML.Result result = new ML.Result();
                try
                {
                    string endPoint = ConfigurationManager.AppSettings["ProductoEndPoint"];
                    //client.BaseAddress = new Uri(endPoint);
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(endPoint);
                        var responseTask = client.GetAsync($"GetById/{IdProducto.Value}");
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            ML.Producto resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                            result.Object = resultItem;

                            producto = (ML.Producto)result.Object;
                            producto.SubCategoria.Categoria.Categorias = resultCategoria.Objects;

                            ML.Result resultSubCategorias = BL.SubCategoria.SubCategoriaGetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);

                            if (resultSubCategorias.Correct)
                            {
                                producto.SubCategoria.SubCategorias = resultSubCategorias.Objects;
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            // Si no se pudo obtener el producto desde la API
                            result.Correct = false;
                            ViewBag.MensajeError = "No se pudo obtener la información del producto desde la API.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }

                if (!result.Correct)
                {
                    ViewBag.MensajeError = "Ocurrió un error al obtener la información del producto.";
                }
            }

            return View(producto);
        }*/

        // -----------------------------------------------Insertar - Actualizar - Listo--------------------------------------------------//
        /*[HttpPost] //Guarda o Actualiza
        public ActionResult Form(ML.Producto producto)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImagenProducto"]; //recibir imagen

                if (file != null && file.ContentLength > 0)
                {
                    producto.Imagen = ConvertirAArrayBytes(file); //convertir imagen a byte[]
                }

                ML.Result result = new ML.Result();

                if (producto.IdProducto == null || producto.IdProducto == 0)
                {
                    using (var client = new HttpClient())
                    {
                        string endPoint = ConfigurationManager.AppSettings["ProductoEndPoint"];
                        client.BaseAddress = new Uri(endPoint);

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Producto>("Add", producto);
                        postTask.Wait();

                        var resultA = postTask.Result;
                        if (resultA.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GetAllC");
                        }

                    }
                    //result = BL.Producto.AddEF(producto); //Agregar

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
                    if (producto.IdProducto >= 0)
                    {
                        using (var client = new HttpClient())
                        {
                            string endPoint = ConfigurationManager.AppSettings["ProductoEndPoint"];
                            client.BaseAddress = new Uri(endPoint);
                            //HTTP POST
                            var postTask = client.PostAsJsonAsync<ML.Producto>($"Update/{producto.IdProducto}", producto);
                            postTask.Wait();

                            var resultA = postTask.Result;
                            if (resultA.IsSuccessStatusCode)
                            {
                                return RedirectToAction("GetAllC");
                            }
                        }

                        //result = BL.Producto.UpdateEF(producto); //Actualizar

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
        }*/

        //---------------------------------------------------------Delete----------------------------------------------------------------//
        /*[HttpGet] //Eliminar
        public ActionResult Delete(ML.Producto producto)
        {
            int IdProducto = producto.IdProducto ?? 0;

            if (IdProducto > 0)
            {
                ML.Result resultListProduct = new ML.Result();

                using (var client = new HttpClient())
                {
                    string endPoint = ConfigurationManager.AppSettings["ProductoEndPoint"];
                    client.BaseAddress = new Uri(endPoint);
                    var postTask = client.GetAsync($"Delete/{IdProducto}");
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        //resultListProduct = BL.Producto.GetAllEF(producto.SubCategoria.IdSubCategoria);
                        return RedirectToAction("GetAllC", resultListProduct);
                    }

                }
            }

            else
            {
                ViewBag.Message = "IdProducto no es válido.";
            }


            return PartialView("Modal");
        }*/

        /*public JsonResult GetSubCategoriasByIdCategorias(int IdCategoria)
        {
            ML.Result result = new ML.Result();
            result = BL.SubCategoria.SubCategoriaGetByIdCategoria(IdCategoria);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertirAArrayBytes(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            return data;
        }*/
    
    }
}