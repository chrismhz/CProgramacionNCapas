using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        //Atributos
        public int? IdProducto { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre del producto, por favor")] //Decorador que afectan al codigo hacia abajo
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóú\s\.]+$", ErrorMessage = "El Nombre solo acepta texto")] //  ^[A-Za-z\s\.]+$
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la Descripcion del producto, por favor")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóú\s\.]+$", ErrorMessage = "La Descripcion solo acepta texto y numero")] //^[A-Za-z0-9\s]+$
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el Precio del producto, por favor")]
        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "El precio debe de tener el formato correcto, por ejemplo: 20.00")]
        //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "El precio debe de tener el formato correcto, por ejemplo: 20.00")]
        public decimal Precio { get; set; }

        public byte[] Imagen { get; set; }
        public ML.SubCategoria SubCategoria { get; set; }

        public List<Object> Productos { get; set; }
    }
}
