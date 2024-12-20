using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubCategoria
    {
       public static ML.Result SubCategoriaGetByIdCategoria(int IdCategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var query = (from subcategoria in context.SubCategoria
                                 where subcategoria.IdCategoria == IdCategoria
                                 select new
                                 {
                                     subcategoria.IdSubCategoria,
                                     subcategoria.Nombre,
                                     subcategoria.IdCategoria

                                 }).ToList();

                    if (query != null && query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var subcategoria in query)
                        {
                            ML.SubCategoria subcategoriaItem = new ML.SubCategoria();
                            subcategoriaItem.IdSubCategoria = subcategoria.IdSubCategoria;
                            subcategoriaItem.Nombre = subcategoria.Nombre;
                            subcategoriaItem.Categoria = new ML.Categoria();
                            subcategoriaItem.Categoria.IdCategoria = Convert.ToInt32(subcategoria.IdCategoria);

                            result.Objects.Add(subcategoriaItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay Subcategorias \n\n";
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
