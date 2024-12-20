using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        //Atributos
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre, por favor")] //Decorador que afectan al codigo hacia abajo
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

        [Required(ErrorMessage = "Ingrese el User Name, por favor")]
        [Display(Name = "User Name")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+$", ErrorMessage = "El User Name solo acepta letras, numeros, _, ., y -")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese el Email, por favor")]
        //[RegularExpression(@"^[a-zA-Z0-9_.-]+@@[a-zA-Z0-9]+[a-zA-Z0-9.-]+[a-zA-Z0-9]+.[a-z]{0,4}$", ErrorMessage = "Ingrese un correo Valido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese el Password, por favor")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "El password debe tener al menos 8 caracteres")]
        public string Password { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage = "Ingrese el Telefono, por favor")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El numero de telefono no es valido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese el Celular, por favor")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El numero de telefono no es valido.")]
        public string Celular {  get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Ingrese la CURP, por favor")]
        [RegularExpression(@"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z\d]{2}$", ErrorMessage = "El formato de CURP que ingreso no es valido.")]
        public string CURP { get; set; }
        
        public ML.Rol Rol { get; set; } //rol
        public bool Status {  get; set; } //Status
        public List<Object> Usuarios { get; set; }
        public byte[] Imagen { get; set; }
        public ML.Direccion Direccion { get; set; }
       
    }
}
