using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pedido
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaPedidos = context.PedidosGetAll().ToList();

                    if(listaPedidos.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var pedido in listaPedidos)
                        {
                            ML.Pedido pedidoItem = new ML.Pedido();
                            pedidoItem.IdPedido = pedido.IdPedido;
                            pedidoItem.Usuario = new ML.Usuario();
                            pedidoItem.Usuario.Nombre = pedido.UsuarioNombre;
                            pedidoItem.Sucursal = new ML.Sucursal();
                            pedidoItem.Sucursal.Nombre = pedido.SucursalNombre;
                            pedidoItem.TipoPago = new ML.TipoPago();
                            pedidoItem.TipoPago.Nombre = pedido.TipoPagoNombre;
                            pedidoItem.Direccion = new ML.Direccion();
                            pedidoItem.Direccion.Calle = pedido.Calle;
                            pedidoItem.EstadoPedido = new ML.EstadoPedido();
                            pedidoItem.EstadoPedido.Descripcion = pedido.Descripcion;
                            pedidoItem.FechaCreacion = pedido.FechaCreacion.Value.ToString("yyyy/MM/dd");
                            pedidoItem.Repartidor = new ML.Repartidor();
                            pedidoItem.Repartidor.Nombre = pedido.RepartidorNombre;

                            result.Objects.Add(pedidoItem);
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

        public static ML.Result AddEF(ML.Pedido pedido)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaPedidos = context.PedidosGetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateEF(ML.Pedido pedido)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaPedidos = context.PedidosGetAll().ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
