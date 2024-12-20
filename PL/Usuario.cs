using ML;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            /*Console.WriteLine("Ingrese la edad del usuario");
            usuario.Edad = int.Parse(Console.ReadLine());*/

            ML.Result result = BL.Usuario.Add(usuario);

            if(result.Correct) 
            {
                Console.WriteLine("'El usuario fue insertado exitosamente'\n\n");
            }
            else
            {
                Console.WriteLine("'Error al registrar el usuario'\n\n");
            }
        }

        public static void Delete()
        {
            Console.WriteLine("Escriba el ID del registro que quiera eliminar");
            int IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.Delete(IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("'El usuario fue eliminado exitosamente'\n\n");
            }
            else
            {
                Console.WriteLine("'Error al eliminar el usuario'\n\n");
            }
        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el id del usuario a Actualizar");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del usuario a Actualizar");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario a Actualizar");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario a Actualizar");
            usuario.ApellidoMaterno = Console.ReadLine();

            /*Console.WriteLine("Ingrese la edad del usuario a Actualizar");
            usuario.Edad = Convert.ToInt32(Console.ReadLine());*/

            ML.Result result = BL.Usuario.Update(usuario);

            if (result.Correct)
            {
                Console.WriteLine("'El usuario fue actualizado exitosamente'\n\n");
            }
            else
            {
                Console.WriteLine("'Error al actualizar al usuario'\n\n");
            }
        }

        // -------------------------------------------------------------------

        public static void GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdUsuario" + usuario.IdUsuario);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("UserName" + usuario.UserName);
                    Console.WriteLine("Email" + usuario.Email);
                    Console.WriteLine("Password" + usuario.Password);
                    Console.WriteLine("Sexo" + usuario.Sexo);
                    Console.WriteLine("Telefono" + usuario.Telefono);
                    Console.WriteLine("Celular" + usuario.Celular);
                    Console.WriteLine("FechaNacimient" + usuario.FechaNacimiento);
                    Console.WriteLine("CURP" + usuario.CURP);
                   // Console.WriteLine("IdRol" + usuario.IdRol);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron los registros en la tabla de Usuario" + result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            Console.WriteLine("\n Ingresa el ID a mostrar \n");

            int IdUsuario = Convert.ToInt32(Console.ReadLine());
            ML.Result result = BL.Usuario.GetById(IdUsuario);

            if (result.Correct)
            {
                ML.Usuario usuario = ((ML.Usuario)result.Object);

                Console.WriteLine("\nId: " + usuario.IdUsuario);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                //Console.WriteLine("Edad: " + usuario.Edad + "\n");

            }
            else
            {
                Console.WriteLine("No se encontraron los registros en la tabla de Usuario" + result.ErrorMessage);
            }
        }

        public static void GetDelete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("\n Ingresa el ID a eliminar \n");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

            //ML.Result result = BL.Usuario.GetDelete(usuario.IdUsuario);

            /*if (result.Correct)
            {
                Console.WriteLine("'El usuario fue eliminado exitosamente'\n\n");
            }
            else
            {
                Console.WriteLine("\n No se elimino el Id de la tabla de Usuario \n" + result.ErrorMessage);
            }*/
        }

        public static void GetUpdate()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el id del usuario a actualziar");
            usuario.IdUsuario= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del usuario a actualizar");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario a actualizar");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario a actualizar");
            usuario.ApellidoMaterno = Console.ReadLine();

            /*Console.WriteLine("Ingrese la edad del usuario a actualizar");
            usuario.Edad = int.Parse(Console.ReadLine());*/

            ML.Result result = BL.Usuario.GetUpdate(usuario);

            if (result.Correct)
            {
                Console.WriteLine("'El usuario fue actualizado exitosamente'\n\n");
            }
            else
            {
                Console.WriteLine("'Error al actualizar el usuario'\n\n");
            }
        }

        public static void GetInsert()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el nombre del usuario a insertar");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario a insertar");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario a insertar");
            usuario.ApellidoMaterno = Console.ReadLine();

            /*Console.WriteLine("Ingrese la edad del usuario a insertar");
            usuario.Edad = int.Parse(Console.ReadLine());*/

            ML.Result result = BL.Usuario.GetInsert(usuario);

            if (result.Correct)
            {
                Console.WriteLine("'El usuario fue insertado exitosamente'\n\n");
            }
            else
            {
                Console.WriteLine("'Error al insertado el usuario'\n\n");
            }
        }

        // -------------------------------------------------------------------

        public static void GetAllEF()
        {
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("\nIdUsuario: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("UserName: " + usuario.UserName);
                    Console.WriteLine("Email:" + usuario.Email);
                    Console.WriteLine("Password: " + usuario.Password);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("CURP: " + usuario.CURP);
                    Console.WriteLine("IdRol: " + usuario.Rol.IdRol + "\n");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron los registros en la tabla de Usuario" + result.ErrorMessage);
            }
        }

        public static void GetByIdEF()
        {
            Console.WriteLine("\n Ingresa el ID a mostrar \n");

            int IdUsuario = Convert.ToInt32(Console.ReadLine());
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);
            

            if (result.Correct)
            {

                ML.Usuario usuario = ((ML.Usuario)result.Object);

                Console.WriteLine("\nIdUsuario: " + usuario.IdUsuario);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                Console.WriteLine("UserName: " + usuario.UserName);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Password: " + usuario.Password);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("FechaNacimiento:" + usuario.FechaNacimiento);
                Console.WriteLine("CURP:" + usuario.CURP);
                Console.WriteLine("IdRol: " + usuario.Rol.IdRol + "\n");
                
            }
            else
            {
                Console.WriteLine("No se encontraron los registros en la tabla de Usuario" + result.ErrorMessage);
            }
        }

        public static void AddEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el Nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el UserName:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingresa el Email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingresa la Password:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingresa el Sexo:");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa el Telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingresa el Celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa la Fecha de Nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingresa el CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingresa el IdRol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Usuario.AddEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario agregado correctamente" + result.Object);
            }
            else
            {
                Console.WriteLine("Error al agregar el usuario: " + result.ErrorMessage);
            }


        }

        public static void DeleteEF()
        {
            Console.WriteLine("Ingresa el ID del usuario a eliminar:");

            int IdUsuario = Convert.ToInt32(Console.ReadLine());
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Error al eliminar el usuario: " + result.ErrorMessage);
            }
        }

        public static void UpdateEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el ID del usuario a actualizar:");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingresa el Nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el UserName:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingresa el Email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingresa la Password:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingresa el Sexo:");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa el Telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingresa el Celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa la Fecha de Nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingresa el CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingresa el IdRol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Error al actualizar el usuario: " + result.ErrorMessage);
            }
        }

        public static void UsuarioInsert()
        {
            //ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.CargaMasivaTxt3();

            if (result.Correct)
            {
                Console.WriteLine("Usuarios insertados correctamente.");
            }
            else
            {
                Console.WriteLine("Error al insertar los usuarios: " + result.ErrorMessage);
            }
        }



        // -------------------------------------------------------------------

        /*public static void GetAllEFLinq()
         {
            ML.Result result = BL.Usuario.GetAllEFLinq();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("\nIdUsuario: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("UserName: " + usuario.UserName);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Password: " + usuario.Password);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("CURP: " + usuario.CURP);
                    Console.WriteLine("IdRol: " + usuario.Rol.IdRol + "\n");
                   
                }
            }
            else
            {
                Console.WriteLine("No se encontraron los registros en la tabla de Usuario: " + result.ErrorMessage);
            }
        }

        public static void GetByIdEFLinq()
         {
            Console.WriteLine("Ingresa el ID del usuario a mostrar:");

            int IdUsuario = Convert.ToInt32(Console.ReadLine());
            ML.Result result = BL.Usuario.GetByIdEFLinq(IdUsuario);

            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;

                Console.WriteLine("\nIdUsuario: " + usuario.IdUsuario);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                Console.WriteLine("UserName: " + usuario.UserName);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Password: " + usuario.Password);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("CURP: " + usuario.CURP);
                Console.WriteLine("IdRol: " + usuario.Rol.IdRol + "\n");
            }
            else
            {
                Console.WriteLine("No se encontraron los registros en la tabla de Usuario: " + result.ErrorMessage);
            }
        }

        public static void AddEFLinq()
         {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el Nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el UserName:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingresa el Email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingresa la Password:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingresa el Sexo:");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa el Telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingresa el Celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa la Fecha de Nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingresa el CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingresa el IdRol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Usuario.AddEFLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario agregado correctamente.");
            }
            else
            {
                Console.WriteLine("Error al agregar el usuario: " + result.ErrorMessage);
            }
        }

        public static void DeleteEFLinq()
         {
            Console.WriteLine("Ingresa el ID del usuario a eliminar:");

            int IdUsuario = Convert.ToInt32(Console.ReadLine());
            ML.Result result = BL.Usuario.DeleteEFLinq(IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Error al eliminar el usuario: " + result.ErrorMessage);
            }
        }

        public static void UpdateEFLinq()
         {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el ID del usuario a actualizar:");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingresa el Nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el UserName:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingresa el Email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingresa la Password:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingresa el Sexo:");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa el Telefono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingresa el Celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa la Fecha de Nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingresa el CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingresa el IdRol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Usuario.UpdateEFLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Usuario actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Error al actualizar el usuario: " + result.ErrorMessage);
            }
        }*/

    }
}
