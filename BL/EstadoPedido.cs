using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstadoPedido
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaEstadoPedido = context.EstadoPedidoGetAll().ToList();

                    if (listaEstadoPedido.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var estadoPedido in listaEstadoPedido)
                        {
                            ML.EstadoPedido estadoPedidoItem = new ML.EstadoPedido();
                            estadoPedidoItem.IdEstadoPedido = estadoPedido.IdEstadoPedido;
                            estadoPedidoItem.Descripcion = estadoPedido.Descripcion;

                            result.Objects.Add(estadoPedidoItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Materia \n\n";
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
