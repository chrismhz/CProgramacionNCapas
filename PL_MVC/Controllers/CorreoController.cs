using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PL_MVC.Controllers
{
    public class CorreoController : Controller
    {
        // GET: Correo
        [HttpGet]
        public ActionResult Correo()
        {
            try
            {
                string Correo = ConfigurationManager.AppSettings["Correo"];
                string Contrasenia = ConfigurationManager.AppSettings["Contraseña"];
                string displayName = ConfigurationManager.AppSettings["displayName"];

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Correo, Contrasenia),
                    EnableSsl = true
                };

                var mensaje = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress(Correo, displayName),
                    Subject = "Pedido de Productos",
                    Body = @"
                       <html>
                            <head>
                                <meta charset=""UTF-8"">
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                <title>Redireccionamiento</title>
                                <style>
                                    .button {
                                        background-color: #42ab49; 
                                        color: white; 
                                        padding: 10px 20px; 
                                        border: none; 
                                        border-radius: 5px; 
                                        cursor: pointer; 
                                        text-decoration: none; 
                                    }

                                    .button:hover {
                                        background-color: #175c25;
                                    }
                                </style>
                            </head>

                            <body> 
                                <p>El pedido esta llegar...</p>
                                <p>¡Por favor!, confirme su pedido.</p>                                    
                                <a href=""https://www.google.com/"" class=""button"">Confirmo de Pedido</a>
                                <p>¡Gracias!</p> 
                                <br>
                                <img src='cid:imagenAdjunta'  width=""250"" height=""150""
                            </body>
                        </html>",
                    IsBodyHtml = true
                };

                // Adjuntar la imagen
                var imagenPath = @"C:\Users\digis\Documents\Christian Martinez Hernandez\CMartinezProgramacionNCapas\PL_MVC\Content\Img\CorreoProducto.jpg";

                var imagenAdjunta = new Attachment(imagenPath);
                imagenAdjunta.ContentId = "imagenAdjunta";
                mensaje.Attachments.Add(imagenAdjunta);

                mensaje.To.Add("chris9605mh@gmail.com");
                mensaje.CC.Add(Correo);
                smtpClient.Send(mensaje);
                ViewBag.Message = "Correo enviado";

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }

            return PartialView("~/Views/Correo/CorreoModal.cshtml");
        }
    }
}