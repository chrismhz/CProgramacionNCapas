using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static ML.Result GetAllCategoria()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var query = (from categoria in context.Categoria
                                 select new
                                 {
                                     categoria.IdCategoria,
                                     categoria.Nombre
                                 }).ToList();

                    if(query != null ) 
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Categoria categoria = new ML.Categoria();
                            categoria.IdCategoria = item.IdCategoria;
                            categoria.Nombre = item.Nombre;

                            result.Objects.Add(categoria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay Categorias \n\n";
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
