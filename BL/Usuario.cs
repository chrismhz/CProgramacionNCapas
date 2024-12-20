using DL_EF;
using ML;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Data.OleDb;
using System.Data.Entity.Infrastructure;

namespace BL
{
    public class Usuario
    {
        //Primitivos - int bool string, decimal
        //Complejos - Se componenn de varios primitivos

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO[dbo].[Usuario] ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Edad]) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Edad)";
                        cmd.Connection = context;

                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        //cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        //cmd.Parameters.AddWithValue("@Edad", usuario.Edad);

                        context.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DELETE FROM[dbo].[Usuario] WHERE [IdUsuario] = (@IdUsuario)";
                        cmd.Connection = context;

                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        context.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE Usuario SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno, Edad = @Edad WHERE IdUsuario = @IdUsuario";
                        cmd.Connection = context;

                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        //cmd.Parameters.AddWithValue("@Edad", usuario.Edad);

                        context.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        // ---------------- SqlClient con Stored Procedures ----------------------------------------------------------

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetAll";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tableUsuario = new DataTable();
                    adapter.Fill(tableUsuario);

                    if (tableUsuario.Rows.Count > 0)
                    {
                        //Si hay registros que tengo que mostrar al usuario
                        result.Objects = new List<object>();

                        foreach (DataRow row in tableUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = Convert.ToInt32(row[0]);
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.UserName = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.Sexo = row[7].ToString();
                            usuario.Telefono = row[8].ToString();
                            usuario.Celular = row[9].ToString();
                            usuario.FechaNacimiento = (row[10].ToString());
                            usuario.CURP = row[11].ToString();
                            //usuario.IdRol = Convert.ToInt32(row[12].ToString());

                            result.Objects.Add(usuario);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros en la tabla";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetById";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                        usuario.Nombre = row["Nombre"].ToString();
                        usuario.ApellidoPaterno = row["ApellidoPaterno"].ToString();
                        usuario.ApellidoMaterno = row["ApellidoMaterno"].ToString();
                        //usuario.Edad = Convert.ToInt32(row["Edad"]);

                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se muestran los ID de la tabla";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetDelete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetDelete";

                    SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;

                    //*** SqlAdapter solo srive para hacer Querys de consultas SELECT ***

                    context.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetUpdate(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetUpdate";

                    SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    //cmd.Parameters.AddWithValue("@Edad", usuario.Edad);

                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;

                    //*** SqlAdapter solo srive para hacer Querys de consultas SELECT ***

                    context.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetInsert(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioGetInsert";

                    SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    //cmd.Parameters.AddWithValue("@Edad", usuario.Edad);

                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;

                    //*** SqlAdapter solo srive para hacer Querys de consultas SELECT ***

                    context.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        // ------------------ Entity Framework con Stored Procedures -------------------------------------------------

        
        public static ML.Result GetAllEF(string Nombre, string ApellidoPaterno, string ApellidoMaterno, int IdRol)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaUsuarios = context.UsuarioGetAll(Nombre, ApellidoPaterno, ApellidoMaterno, IdRol).ToList(); //Apartir de aqui.

                    if (listaUsuarios.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var usuario in listaUsuarios)
                        {
                            ML.Usuario usuarioItem = new ML.Usuario();
                            usuarioItem.IdUsuario = usuario.IdUsuario;
                            usuarioItem.Nombre = usuario.Nombre + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno;
                            usuarioItem.ApellidoPaterno = usuario.ApellidoPaterno;
                            usuarioItem.ApellidoMaterno = usuario.ApellidoMaterno;
                            usuarioItem.UserName = usuario.UserName;
                            usuarioItem.Email = usuario.Email;
                            usuarioItem.Password = usuario.Password;
                            usuarioItem.Sexo = usuario.Sexo;
                            usuarioItem.Telefono = usuario.Telefono;
                            usuarioItem.Celular = usuario.Celular;
                            usuarioItem.FechaNacimiento = usuario.FechaNacimiento.Value.ToString("MM/dd/yyyy");
                            usuarioItem.CURP = usuario.CURP;

                            usuarioItem.Rol = new ML.Rol();
                            usuarioItem.Rol.IdRol = Convert.ToInt32(usuario.IdRol);
                            usuarioItem.Rol.Nombre = usuario.RolNombre;

                            usuarioItem.Imagen = usuario.Imagen;
                            usuarioItem.Status = usuario.Status ?? false; //Sirve para convertir bool? a bool sin efectos adversos

                            usuarioItem.Direccion = new ML.Direccion();
                            usuarioItem.Direccion.Calle = usuario.Calle;
                            usuarioItem.Direccion.NumeroInterior = usuario.NumeroInterior;
                            usuarioItem.Direccion.NumeroExterior = usuario.NumeroExterior;

                            usuarioItem.Direccion.Colonia = new ML.Colonia();
                            usuarioItem.Direccion.Colonia.IdColonia = Convert.ToInt32(usuario.IdColonia);
                            usuarioItem.Direccion.Colonia.CodigoPostal = usuario.CodigoPostal;

                            usuarioItem.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioItem.Direccion.Colonia.Municipio.IdMunicipio = Convert.ToInt32(usuario.IdMunicipio);
                            usuarioItem.Direccion.Colonia.Municipio.Nombre = usuario.MunicipioNombre;

                            usuarioItem.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioItem.Direccion.Colonia.Municipio.Estado.IdEstado = Convert.ToInt32(usuario.IdEstado);
                            usuarioItem.Direccion.Colonia.Municipio.Estado.Nombre = usuario.EstadoNombre;


                            //CultureInfo.InvariantCulture
                            /*if (usuario.FechaNacimiento != null)
                            {
                                DateTime auxiliar = DateTime.ParseExact(usuario.FechaNacimiento.ToString(), "dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);

                                usuarioItem.FechaNacimiento = auxiliar.ToString("dd/MM/yyyy");

                            }
                            else
                            {
                                usuarioItem.FechaNacimiento = "";
                            }*/

                            /*DateTime auxiliar = DateTime.ParseExact(usuario.FechaNacimiento.ToString(), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                            usuarioItem.FechaNacimiento = auxiliar.ToString("dd/MM/yyyy");*/

                            result.Objects.Add(usuarioItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Materia \n\n";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var usuario = context.UsuarioGetById(IdUsuario).SingleOrDefault();

                    if (usuario != null)
                    {
                        ML.Usuario usuarioItem = new ML.Usuario();

                        usuarioItem.IdUsuario = usuario.IdUsuario;
                        usuarioItem.Nombre = usuario.Nombre;
                        usuarioItem.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioItem.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioItem.UserName = usuario.UserName;
                        usuarioItem.Email = usuario.Email;
                        usuarioItem.Password = usuario.Password;
                        usuarioItem.Sexo = usuario.Sexo;
                        usuarioItem.Telefono = usuario.Telefono;
                        usuarioItem.Celular = usuario.Celular;
                        usuarioItem.FechaNacimiento = usuario.FechaNacimiento.Value.ToString("yyyy-MM-dd");
                        usuarioItem.CURP = usuario.CURP;
                        //usuarioItem.Estatus = usuario.Estatus;


                        usuarioItem.Rol = new ML.Rol();
                        usuarioItem.Rol.IdRol = Convert.ToInt32(usuario.IdRol);
                        usuarioItem.Imagen = usuario.Imagen;


                        usuarioItem.Direccion = new ML.Direccion();
                        usuarioItem.Direccion.IdDireccion = usuario.IdDireccion.Value;
                        usuarioItem.Direccion.Calle = usuario.Calle;
                        usuarioItem.Direccion.NumeroInterior = usuario.NumeroInterior;
                        usuarioItem.Direccion.NumeroExterior = usuario.NumeroExterior;

                        usuarioItem.Direccion.Colonia = new ML.Colonia();
                        usuarioItem.Direccion.Colonia.IdColonia = usuario.IdColonia.Value;
                        usuarioItem.Direccion.Colonia.CodigoPostal = usuario.CodigoPostal;

                        usuarioItem.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuarioItem.Direccion.Colonia.Municipio.IdMunicipio = usuario.IdMunicipio.Value;

                        usuarioItem.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuarioItem.Direccion.Colonia.Municipio.Estado.IdEstado = usuario.IdEstado.Value;

                       

                        result.Object = usuarioItem;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DateTime auxiliar = DateTime.ParseExact(usuario.FechaNacimiento, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    //DateTime auxiliar = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    usuario.FechaNacimiento = auxiliar.ToString("MM/dd/yyyy");

                    DL_EF.Usuario usuarioItem = new DL_EF.Usuario();

                    context.UsuarioInsert(usuario.Nombre,
                                            usuario.ApellidoPaterno,
                                            usuario.ApellidoMaterno,
                                            usuario.UserName,
                                            usuario.Email,
                                            usuario.Password,
                                            usuario.Sexo,
                                            usuario.Telefono,
                                            usuario.Celular,
                                            usuario.FechaNacimiento,
                                            usuario.CURP,
                                            usuario.Rol.IdRol,
                                            usuario.Imagen,
                                            usuario.Direccion.Calle,
                                            usuario.Direccion.NumeroInterior,
                                            usuario.Direccion.NumeroExterior,
                                            usuario.Direccion.Colonia.IdColonia);
                    context.SaveChanges();

                    result.Object = usuarioItem.IdUsuario;
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {   
                    context.UsuarioGetDelete(IdUsuario);
                    context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }


            return result;
        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {

                    DateTime auxiliar = DateTime.ParseExact(usuario.FechaNacimiento, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    usuario.FechaNacimiento = auxiliar.ToString("MM/dd/yyyy");

                    DL_EF.Usuario usuarioItem = new DL_EF.Usuario();

                    context.UsuarioGetUpdate(usuario.IdUsuario,
                                            usuario.Nombre,
                                            usuario.ApellidoPaterno,
                                            usuario.ApellidoMaterno,
                                            usuario.UserName,
                                            usuario.Email,
                                            usuario.Password,
                                            usuario.Sexo,
                                            usuario.Telefono,
                                            usuario.Celular,
                                            usuario.FechaNacimiento,
                                            usuario.CURP,
                                            usuario.Rol.IdRol,
                                            usuario.Imagen,
                                            usuario.Direccion.Calle,
                                            usuario.Direccion.NumeroInterior,
                                            usuario.Direccion.NumeroExterior,
                                            usuario.Direccion.Colonia.IdColonia);
                    context.SaveChanges();

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }


            return result;
        }
        public static ML.Result CambiarStatus(int idUsuario, bool status)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var rowsAffected = context.CambiarStatus(idUsuario, status);

                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }


            return result;
        }
        public static ML.Result CargaMasivaTxt3()
        {
            ML.Result result = new ML.Result();
            string path = @"C:\Users\digis\Documents\Christian Martinez Hernandez\CMartinezProgramacionNCapas\PL\Files\Insert Usuario.txt";

            StreamReader streamReader = new StreamReader(path);

            string linea = "";
            bool cabezal = true;
            while((linea = streamReader.ReadLine()) != null) //trae datos, que pudo leer una linea
            {
                if (cabezal)
                {
                    cabezal = false;
                    continue;
                }
                string[] valores = linea.Split('|'); //retornar un arreglo de string

                ML.Usuario usuario = new ML.Usuario();
                usuario.Nombre = valores[0];
                usuario.ApellidoPaterno = valores[1];
                usuario.ApellidoMaterno = valores[2];
                usuario.UserName = valores[3];
                usuario.Email = valores[4];
                usuario.Password = valores[5];
                usuario.Sexo = valores[6];
                usuario.Telefono = valores[7];
                usuario.Celular = valores[8];
                usuario.FechaNacimiento = valores[9];
                usuario.CURP = valores[10];
                usuario.Rol = new ML.Rol();
                usuario.Rol.IdRol = Convert.ToInt32(valores[11]);
                if (!string.IsNullOrEmpty(valores[12]) && valores[12] != "null")
                {
                    usuario.Imagen = Convert.FromBase64String(valores[12]);
                }
                else
                {
                    usuario.Imagen = null;
                }
                //usuario.Status = valores[13] == "1";
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Calle = valores[14];
                usuario.Direccion.NumeroInterior = valores[15];
                usuario.Direccion.NumeroExterior = valores[16];
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.IdColonia = Convert.ToInt32(valores[17]);

                BL.Usuario.AddEF(usuario);
            }

            return result;
        }
        public static ML.Result LeerExcel(string cadenaConnection)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(OleDbConnection conn = new OleDbConnection(cadenaConnection))
                {
                    //string query = "SELECT * FROM [Sheet1$]"
                    string query = "SELECT * FROM [Hoja1$]";

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = conn;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableUsuario = new DataTable();

                        da.Fill(tableUsuario);// llenamos nuestra tabla con el DataReader

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach(DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.Nombre = row[0].ToString();
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.UserName = row[3].ToString();
                                usuario.Email = row[4].ToString();
                                usuario.Password = row[5].ToString();
                                usuario.Sexo = row[6].ToString();
                                usuario.Telefono = row[7].ToString();
                                usuario.Celular = row[8].ToString();
                                usuario.FechaNacimiento = row[9].ToString();
                                usuario.CURP = row[10].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[11].ToString());
                                usuario.Imagen = Convert.FromBase64String(row[12].ToString());
                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = row[13].ToString();
                                usuario.Direccion.NumeroInterior = row[14].ToString();
                                usuario.Direccion.NumeroExterior = row[15].ToString();
                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia = Convert.ToInt32(row[16]);
                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result ValidarExcel(List<object> usuarios)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>(); //Guardar lo que esta mal
            int numeroRegistro = 1;

            foreach (ML.Usuario item in usuarios)
            {
                ML.ResultExcel resultExcel = new ML.ResultExcel();
                resultExcel.NumeroRegistro = numeroRegistro;

                if(item.Nombre == "")
                {
                    resultExcel.MensajeError += "El Nombre no puede ir vacio -"; 
                }
                if (item.ApellidoPaterno == "")
                {
                    resultExcel.MensajeError += "El Apellido Paterno no puede ir vacio -";
                }
                if(item.ApellidoMaterno == "")
                {
                    resultExcel.MensajeError += "El Apellido Materno no puede ir vacio -";
                }
                if(item.UserName == "")
                {
                    resultExcel.MensajeError += "El UserName no puede ir vacio -";
                }
                if(item.Email == "")
                {
                    resultExcel.MensajeError += "El Email no puede ir vacio -";
                }
                if(item.Password == "")
                {
                    resultExcel.MensajeError += "El Password no puede ir vacio -";
                }
                if (item.Sexo.Length > 1 )
                {
                    resultExcel.MensajeError += "El Sexo no puede tener mas de 1 caracter -";
                }
                if (item.Telefono.Length > 10)
                {
                    resultExcel.MensajeError += "El Telefono no puede tener mas de 10 digitos -";
                }
                if (item.Celular.Length > 10)
                {
                    resultExcel.MensajeError += "El Celular no puede tener mas de 10 digitos -";
                }
                if (item.FechaNacimiento == "")
                {
                    resultExcel.MensajeError += "La FechaNacimiento no puede estar vacia -";
                }
                if (item.CURP == "" || item.CURP.Length > 18)
                {
                    resultExcel.MensajeError += "La CURP no puede estar vacia o No debe de pasar de los 18 caracteres -";
                }
                if (item.Rol.IdRol == 0)
                {
                    resultExcel.MensajeError += "El IdRol no puede estar en 0 -";
                }
                if (item.Imagen.Length == 0)
                {
                    resultExcel.MensajeError += "La Imagen no puede estar en 0 -";
                }
                if (item.Direccion.Calle == "")
                {
                    resultExcel.MensajeError += "La calle no puede ir vacia -";
                }
                if (item.Direccion.NumeroInterior == "")
                {
                    resultExcel.MensajeError += "El numero Interior no puede ir vacio -";
                }
                if (item.Direccion.NumeroExterior == "")
                {
                    resultExcel.MensajeError += "El numero Exterior no puede ir vacio -";
                }
                if(item.Direccion.Colonia.IdColonia == 0)
                {
                    resultExcel.MensajeError += "El IdColonia no puede estar en 0 -";
                }


                if (resultExcel.MensajeError != null || resultExcel.MensajeError != "")
                {
                    result.Objects.Add(resultExcel);
                }

                numeroRegistro++;
            }

            return result;
        }


        // ------------------- LinQ -------------------------------------------------------------


        /*public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaUsuarios = (from usuario in context.Usuario
                                         select new
                                         {
                                             usuario.IdUsuario,
                                             usuario.Nombre,
                                             usuario.ApellidoPaterno,
                                             usuario.ApellidoMaterno,
                                             usuario.UserName,
                                             usuario.Email,
                                             usuario.Password,
                                             usuario.Sexo,
                                             usuario.Telefono,
                                             usuario.Celular,
                                             usuario.FechaNacimiento,
                                             usuario.CURP,
                                             usuario.IdRol
                                         }).ToList();

                    if (listaUsuarios.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var usuario in listaUsuarios)
                        {
                            ML.Usuario usuarioItem = new ML.Usuario();
                            usuarioItem.IdUsuario = usuario.IdUsuario;
                            usuarioItem.Nombre = usuario.Nombre;
                            usuarioItem.ApellidoPaterno = usuario.ApellidoPaterno;
                            usuarioItem.ApellidoMaterno = usuario.ApellidoMaterno;
                            usuarioItem.UserName = usuario.UserName;
                            usuarioItem.Email = usuario.Email;
                            usuarioItem.Password = usuario.Password;
                            usuarioItem.Sexo = usuario.Sexo;
                            usuarioItem.Telefono = usuario.Telefono;
                            usuarioItem.Celular = usuario.Celular;
                            usuarioItem.FechaNacimiento = usuario.FechaNacimiento.ToString();
                            usuarioItem.CURP = usuario.CURP;
                            usuarioItem.Rol = new ML.Rol();
                            usuarioItem.Rol.IdRol = Convert.ToInt32(usuario.IdRol);
                            //usuarioItem.IdRol = Convert.ToInt32(usuario.IdRol);

                            result.Objects.Add(usuarioItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros de la tabla Materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByIdEFLinq(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var usuarioResult = (from usuario in context.Usuario
                                         where usuario.IdUsuario == IdUsuario
                                         select usuario).SingleOrDefault();

                    if (usuarioResult != null)
                    {
                        ML.Usuario usuarioItem = new ML.Usuario();
                        usuarioItem.IdUsuario = usuarioResult.IdUsuario;
                        usuarioItem.Nombre = usuarioResult.Nombre;
                        usuarioItem.ApellidoPaterno = usuarioResult.ApellidoPaterno;
                        usuarioItem.ApellidoMaterno = usuarioResult.ApellidoMaterno;
                        usuarioItem.UserName = usuarioResult.UserName;
                        usuarioItem.Email = usuarioResult.Email;
                        usuarioItem.Password = usuarioResult.Password;
                        usuarioItem.Sexo = usuarioResult.Sexo;
                        usuarioItem.Telefono = usuarioResult.Telefono;
                        usuarioItem.Celular = usuarioResult.Celular;
                        usuarioItem.FechaNacimiento = usuarioResult.FechaNacimiento.ToString();
                        usuarioItem.CURP = usuarioResult.CURP;
                        usuarioItem.Rol = new ML.Rol();
                        usuarioItem.Rol.IdRol = Convert.ToInt32(usuarioResult.Rol.IdRol);
                        usuarioItem.Imagen = usuarioResult.Imagen;
                        //usuarioItem.IdRol = Convert.ToInt32(usuarioResult.IdRol);
                        //usuarioItem.Rol.IdRol = Convert.ToInt32(Usuario);

                        result.Object = usuarioItem;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result AddEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {

                    DL_EF.Usuario usuarioDB = new DL_EF.Usuario();
                    usuarioDB.IdUsuario = usuario.IdUsuario;
                    usuarioDB.Nombre = usuario.Nombre;
                    usuarioDB.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDB.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDB.UserName = usuario.UserName;
                    usuarioDB.Email = usuario.Email;
                    usuarioDB.Password = usuario.Password;
                    usuarioDB.Sexo = usuario.Sexo;
                    usuarioDB.Telefono = usuario.Telefono;
                    usuarioDB.Celular = usuario.Celular;
                    usuarioDB.FechaNacimiento = Convert.ToDateTime(usuario.FechaNacimiento);
                    usuarioDB.CURP = usuario.CURP;
                    usuarioDB.IdRol = Convert.ToInt32(usuario.Rol.IdRol);
                    usuarioDB.Imagen = usuario.Imagen;


                    context.Usuario.Add(usuarioDB); //Usuarios

                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Object = usuarioDB.IdUsuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteEFLinq(int IdUsuario)
         {
             ML.Result result = new ML.Result();

             try
             {
                 using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                 {
                     var usuarioResult = (from Usuario in context.Usuario
                                          where Usuario.IdUsuario == IdUsuario
                                          select Usuario).SingleOrDefault();

                     if (usuarioResult != null)
                     {
                         context.Usuario.Remove(usuarioResult);

                         int rowsAffected = context.SaveChanges();

                         if (rowsAffected > 0)
                         {
                             result.Correct = true;
                         }
                         else
                         {
                             result.Correct = false;
                             result.ErrorMessage = "No se pudo eliminar la materia";
                         }
                     }
                     else
                     {
                         result.Correct = false;
                         result.ErrorMessage = "No se encontro una materia con el id seleccionado";
                     }
                 }
             }
             catch(Exception ex)
             {
                 result.Correct = false;
                 result.ErrorMessage = ex.Message;
             }
             return result;
         }
        public static ML.Result UpdateEFLinq(ML.Usuario usuarioML)
         {
             ML.Result result = new ML.Result();

             try
             {
                 using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                 {
                     var usuarioResult = (from usuario in context.Usuario
                                          where usuario.IdUsuario == usuarioML.IdUsuario
                                          select usuario).SingleOrDefault();

                     if (usuarioResult != null)
                     {
                        usuarioResult.IdUsuario = usuarioML.IdUsuario;
                        usuarioResult.Nombre = usuarioML.Nombre;
                        usuarioResult.ApellidoPaterno = usuarioML.ApellidoPaterno;
                        usuarioResult.ApellidoMaterno = usuarioML.ApellidoMaterno;
                        usuarioResult.UserName = usuarioML.UserName;
                        usuarioResult.Email = usuarioML.Email;
                        usuarioResult.Password = usuarioML.Password;
                        usuarioResult.Sexo = usuarioML.Sexo;
                        usuarioResult.Telefono = usuarioML.Telefono;
                        usuarioResult.Celular = usuarioML.Celular;
                        usuarioResult.FechaNacimiento = Convert.ToDateTime(usuarioML.FechaNacimiento);
                        usuarioResult.CURP = usuarioML.CURP;
                        usuarioResult.IdRol = Convert.ToInt32(usuarioML.Rol.IdRol);
                        usuarioResult.Imagen = usuarioML.Imagen;


                        int rowsAffected = context.SaveChanges();

                         if (rowsAffected > 0)
                         {
                             result.Correct = true;
                         }
                         else
                         {
                             result.Correct = false;
                             result.ErrorMessage = "No se pudo eliminar el usuario";
                         }
                     }
                     else
                     {
                         result.Correct = false;
                         result.ErrorMessage = "No se encontro un usuario con el id seleccionado";
                     }
                 }
             }
             catch (Exception ex)
             {
                 result.Correct = false;
                 result.ErrorMessage = ex.Message;
             }
             return result;
         }*/


    }
}

