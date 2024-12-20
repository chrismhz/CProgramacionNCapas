using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int? IdDireccion { get; set; }

        [Required(ErrorMessage = "Ingrese la Calle, por favor")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "La Calle solo acepta texto")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Ingrese el Numero Interior, por favor")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "El Numero Interior solo acepta texto")]
        public string NumeroInterior { get; set; }

        [Required(ErrorMessage = "Ingrese el Numero Exterior, por favor")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "El Numero Exterior solo acepta texto")]
        public string NumeroExterior { get; set; }
        public ML.Colonia Colonia { get; set; }

        public Estado Estado { get; set; }
    }
}
