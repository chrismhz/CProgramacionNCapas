using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var query = (from municipio in context.Municipio
                                 where municipio.IdEstado == IdEstado

                                 select new
                                 {
                                     municipio.IdMunicipio,
                                     municipio.Nombre,
                                     municipio.IdEstado
                                 }).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var municipio in query)
                        {
                            ML.Municipio municipioItem = new ML.Municipio();
                            municipioItem.IdMunicipio = municipio.IdMunicipio;
                            municipioItem.Nombre = municipio.Nombre;
                            municipioItem.Estado = new ML.Estado();
                            municipioItem.Estado.IdEstado = Convert.ToInt32(municipio.IdEstado);

                            result.Objects.Add(municipioItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay Municipios \n\n";
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
