using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Sucursal
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaSucursales = context.SucursalGetAll().ToList();

                    if (listaSucursales.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var sucursal in listaSucursales)
                        {
                            ML.Sucursal sucursalItem = new ML.Sucursal();
                            sucursalItem.IdSucursal = sucursal.IdSucursal;
                            sucursalItem.Nombre = sucursal.SucursalNombre;
                            sucursalItem.Latitud = sucursal.Latitud;
                            sucursalItem.Longitud = sucursal.Longitud;

                            result.Objects.Add(sucursalItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Sucursales \n\n";
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
        public static ML.Result GetByIdEF(int IdSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var sucursal = context.SucursalGetById(IdSucursal).SingleOrDefault();

                    if (sucursal != null)
                    {
                        ML.Sucursal sucursalItem = new ML.Sucursal();

                        sucursalItem.IdSucursal = sucursal.IdSucursal;
                        sucursalItem.Nombre = sucursal.SucursalNombre;
                        sucursalItem.Latitud = sucursal.Latitud;
                        sucursalItem.Longitud = sucursal.Longitud;

                        result.Object = sucursalItem;

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
        public static ML.Result AddEF(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DL_EF.Sucursal sucursalItem = new DL_EF.Sucursal();
                    

                    context.SucursalAdd(sucursal.Nombre,
                                        sucursal.Latitud,
                                        sucursal.Longitud);

                    context.SaveChanges();

                    result.Object = sucursalItem.IdSucursal;
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
        public static ML.Result DeleteEF(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    context.SucursalGetDelete(IdProducto);
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
        public static ML.Result UpdateEF(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DL_EF.Sucursal sucursalItem = new DL_EF.Sucursal();

                    context.SucursalGetUpdate(sucursal.IdSucursal,
                                                sucursal.Nombre,
                                                sucursal.Latitud,
                                                sucursal.Longitud);
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
    }
}
