using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class TipoPago
    {
        public byte[] IdTipoPago { get; set; }
        public string Nombre { get; set; }
        public List<Object> TipoPagos { get; set; }
    }
}
