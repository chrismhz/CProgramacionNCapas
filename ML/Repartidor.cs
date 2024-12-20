using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Repartidor
    {
        public int IdRepartidor { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre, por favor")]
        [RegularExpression(@"^[A-Za-z\s\.]+$", ErrorMessage = "El Nombre solo acepta texto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el Apellido Paterno, por favor")]
        [Display(Name = "Apellido Paterno")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s\.]+$", ErrorMessage = "El ApellidoPaterno solo acepta texto")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Ingrese el Apellido Materno, por favor")]
        [Display(Name = "Apellido Materno")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s\.]+$", ErrorMessage = "El ApellidoMaterno solo acepta texto")]
        public string ApellidoMaterno { get; set; }
        public List<Object> Repartidores { get; set; }
    }
}
