using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DetallePedido
    {
        public int IdDetallePedido { get; set; }
        public ML.Pedido Pedido { get; set; }
        public ML.Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public List<Object> DetallePedidos { get; set; }
    }
}
