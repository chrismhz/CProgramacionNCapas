using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ActualizacionPedido
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaActualizacionPedido = context.ActualizacionPedidosGetAll().ToList();

                    if (listaActualizacionPedido.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var actualizacionPedido in listaActualizacionPedido)
                        {
                            ML.ActualizacionPedido actualizacionPedidoItem = new ML.ActualizacionPedido();
                            actualizacionPedidoItem.IdActualizacionPedido = actualizacionPedido.IdActualizacionPedidos;
                            actualizacionPedidoItem.Pedido = new ML.Pedido();
                            actualizacionPedidoItem.Pedido.IdPedido = actualizacionPedido.IdPedido;
                            actualizacionPedidoItem.EstadoPedido = new ML.EstadoPedido();
                            actualizacionPedidoItem.EstadoPedido.Descripcion = actualizacionPedido.EstadoPedidoDescripcion.ToString();
                            actualizacionPedidoItem.Descripcion = actualizacionPedido.ActualizacionPedidoDescripcion.ToString();
                            actualizacionPedidoItem.FechaActualizacion = actualizacionPedido.FechaActualizacion.Value.ToString("yyyy/MM/dd");

                            result.Objects.Add(actualizacionPedidoItem);
                        }
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el pedido \n\n";
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

        public static ML.Result AddEF(ML.ActualizacionPedido actualizacionPedido)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            
            return result;
        }

        public static ML.Result GetByIdEF()
        {
            ML.Result result = new ML.Result();

            return result;
        }

        public static ML.Result UpdateEF(ML.ActualizacionPedido actualizacionPedido)
        {
            ML.Result result = new ML.Result();

            return result;
        }

        public static ML.Result DeleteEF()
        {
            ML.Result result= new ML.Result();

            return result;
        }
    }
}
