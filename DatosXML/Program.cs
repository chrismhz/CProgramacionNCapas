using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatosXML
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Declaracion de una variable para la ruta (Entrada)
            string ruta = @"C:\ejemplo\datos.xml";

            if (File.Exists(ruta)) // Verificar si el archivo datos.xml no existe
            {
                try
                {
                    XDocument docEntrada = XDocument.Load(ruta);  // Cargar el documento XML de entrada

                    XDocument docSalida = new XDocument( // Crear el documento XML de salida con la declaración y el elemento raíz <info>
                        new XDeclaration("1.0", "ISO-8859-1", null),
                        new XElement("info",
                            from noticia in docEntrada.Descendants("noticia")
                            select new XElement("podcast",
                                new XAttribute("tipo", (string)noticia.Attribute("tipo") ?? ""), // Agregar atributos
                                new XAttribute("libre", (string)noticia.Element("libre") ?? ""),
                                new XAttribute("id", (string)noticia.Element("id") ?? ""),
                                new XAttribute("is3didfp", (string)noticia.Element("is3idfp") ?? ""),
                                new XAttribute("idaudio", (string)noticia.Element("idaudio") ?? ""),
                                new XElement("categoria", (string)noticia.Element("categoria") ?? ""),// Agregar elementos hijos
                                new XElement("titulo", (string)noticia.Element("titulo") ?? ""),
                                new XElement("resumen", (string)noticia.Element("resumen") ?? ""),
                                new XElement("prevurl", (string)noticia.Element("prevurl") ?? ""),
                                new XElement("url", (string)noticia.Element("url") ?? "")
                            )
                        )
                    );

                    Console.OutputEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"); // Asegurar la correcta codificación para la consola

                    Console.WriteLine(docSalida.Declaration.ToString()); // Mostrar la declaración XML

                    Console.WriteLine(docSalida.ToString()); // Mostrar el contenido del XML transformado

                    Console.WriteLine("\n*** El XML en Deserealizacion finalizada. ***");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al deserealizar el archivo XML");
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                Console.WriteLine($"El archivo {ruta} no existe.");
                return;
            }

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();

            //-------------------------------------- Para hacerlo guardar el archivo -----------------------------------------------------
            /*// Ruta del archivo XML de entrada
            string rutaEntrada = @"C:\ejemplo\datos.xml";
            // Ruta del archivo XML de salida (puedes cambiarla si deseas)
            string rutaSalida = @"C:\ejemplo\datos_transformados.xml";

            // Verificar si el archivo de entrada existe
            if (!File.Exists(rutaEntrada))
            {
                Console.WriteLine($"El archivo {rutaEntrada} no existe.");
                return;
            }

            try
            {
                // Cargar el documento XML de entrada
                XDocument docEntrada = XDocument.Load(rutaEntrada);

                // Crear el documento XML de salida con la declaracion y el elemento raiz <info>
                XDocument docSalida = new XDocument(
                    new XDeclaration("1.0", "ISO-8859-1", null),
                    new XElement("info",
                        from noticia in docEntrada.Descendants("noticia")
                        select new XElement("podcast",
                            // Agregar atributos
                            new XAttribute("tipo", (string)noticia.Attribute("tipo") ?? ""),
                            new XAttribute("libre", (string)noticia.Element("libre") ?? ""),
                            new XAttribute("id", (string)noticia.Element("id") ?? ""),
                            new XAttribute("is3didfp", (string)noticia.Element("is3idfp") ?? ""),
                            new XAttribute("idaudio", (string)noticia.Element("idaudio") ?? ""),
                            // Agregar elementos hijos
                            new XElement("categoria", (string)noticia.Element("categoria") ?? ""),
                            new XElement("titulo", (string)noticia.Element("titulo") ?? ""),
                            new XElement("resumen", (string)noticia.Element("resumen") ?? ""),
                            new XElement("prevurl", (string)noticia.Element("prevurl") ?? ""),
                            new XElement("url", (string)noticia.Element("url") ?? "")
                        )
                    )
                );
                // Guardar el documento XML de salida
                docSalida.Save(rutaSalida);

                Console.WriteLine($"El archivo ha sido procesado y guardado en: {rutaSalida}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al procesar el archivo XML:");
                Console.WriteLine(ex.Message);
            }

            // Mantener la consola abierta
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();*/
        }
    }
}
