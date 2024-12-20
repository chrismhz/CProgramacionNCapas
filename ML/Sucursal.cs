using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Sucursal
    {
       public int IdSucursal { get; set; }

       [Required(ErrorMessage = "Ingrese el Nombre del producto, por favor")] 
       [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóú\s\.]+$", ErrorMessage = "El Nombre solo acepta texto")] 
       public string Nombre { get; set; }
       public string Latitud { get; set; }
       public string Longitud { get; set; }
       public List<Object> Sucursales { get; set; }
    }
}
