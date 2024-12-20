using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {

        public static ML.Result GetAllDireccion()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var query = (from direccion in context.Direccion
                                 select new
                                 {
                                     direccion.IdDireccion,
                                     direccion.Calle,
                                     direccion.NumeroInterior,
                                     direccion.NumeroExterior,
                                     direccion.IdColonia,
                                     direccion.IdUsuario
                                 }).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var direccion in query)
                        {
                            ML.Direccion direccionItem = new ML.Direccion();
                            direccionItem.IdDireccion = direccion.IdDireccion;
                            direccionItem.Calle = direccion.Calle;
                            direccionItem.NumeroInterior = direccion.NumeroInterior;
                            direccionItem.NumeroExterior = direccion.NumeroExterior;
                            direccionItem.Colonia = new ML.Colonia();
                            direccionItem.Colonia.IdColonia = Convert.ToInt32(direccion.IdColonia);
                            /*direccionItem.Usuario = new ML.Usuario();
                            direccionItem.Usuario.IdUsuario = Convert.ToInt32(direccion.IdUsuario);*/

                            result.Objects.Add(direccionItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay direcciones \n\n";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
