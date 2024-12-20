using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ActualizacionPedido
    {
        public int IdActualizacionPedido { get; set; }
        public ML.Pedido Pedido { get; set; }
        public ML.EstadoPedido EstadoPedido { get; set; }
        public string Descripcion { get; set; }
        public string FechaActualizacion { get; set; }

        public List<Object> ActualizacionPedidoss { get; set; }
    }
}
