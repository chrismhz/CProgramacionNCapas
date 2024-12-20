using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class EstadoPedido
    {
        public int IdEstadoPedido { get; set; }
        public string Descripcion { get; set; }
        public List<Object> EstadosPedidos { get; set; }
    }
}
