using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var query = (from colonia in context.Colonia
                                 where colonia.IdMunicipio == IdMunicipio
                                 select new 
                                 {
                                     colonia.IdColonia,
                                     colonia.Nombre,
                                     colonia.CodigoPostal,
                                     colonia.IdMunicipio
                                 }).ToList();

                    if (query != null && query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var coloniaItem in query)
                        {
                            ML.Colonia coloniaObj = new ML.Colonia();
                            coloniaObj.IdColonia = coloniaItem.IdColonia;
                            coloniaObj.Nombre = coloniaItem.Nombre;
                            coloniaObj.CodigoPostal = coloniaItem.CodigoPostal;
                            coloniaObj.Municipio = new ML.Municipio();
                            

                            result.Objects.Add(coloniaObj);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron colonias para el municipio seleccionado.";
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
