using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllRol()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var query = (from rol in context.Rol
                                 select new
                                 {
                                     IdRol = rol.IdRol,
                                     Nombre = rol.Nombre
                                 }).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = item.IdRol;
                            rol.Nombre = item.Nombre;

                            result.Objects.Add(rol);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay roles \n\n";
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
