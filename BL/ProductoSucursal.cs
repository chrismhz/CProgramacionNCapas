using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductoSucursal
    {
        public static ML.Result GetAllEF(int IdSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaProductosSucursales = context.ProductoSucursalGetAll(IdSucursal).ToList();

                    if(listaProductosSucursales.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var productosucursal in listaProductosSucursales)
                        {
                            ML.ProductoSucursal productoSucursalItem = new ML.ProductoSucursal();
                            productoSucursalItem.IdProductoSucursal = productosucursal.IdProductoSucursal;
                            productoSucursalItem.Producto = new ML.Producto();
                            productoSucursalItem.Producto.Imagen = productosucursal.Imagen;
                            productoSucursalItem.Producto.Nombre = productosucursal.ProductoNombre;
                            productoSucursalItem.Sucursal = new ML.Sucursal();
                            productoSucursalItem.Sucursal.Nombre = productosucursal.SucursalNombre;
                            productoSucursalItem.Stock = Convert.ToInt32(productosucursal.Stock);

                            result.Objects.Add(productoSucursalItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Productos \n\n";
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

        public static ML.Result DeleteEF(int IdProductoSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    context.ProductoSucursalDelete(IdProductoSucursal);
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

        public static ML.Result UpdateEF(ML.ProductoSucursal productoSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DL_EF.ProductoSucursal productosucursalItem = new DL_EF.ProductoSucursal();

                    context.ProductoSucursalUpdate(productoSucursal.IdProductoSucursal,
                                                   productoSucursal.Stock);

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

        /*public static ML.Result UpdateEF(ML.ProductoSucursal productoSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var id = new SqlParameter("@IdProductoSucursal", productoSucursal.IdProductoSucursal);
                    var stock = new SqlParameter("@Stock", productoSucursal.Stock);

                    context.Database.ExecuteSqlCommand("EXEC ProductoSucursalUpdate @IdProductoSucursal, @Stock", id, stock);
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }*/

        /*public static ML.Result UpdateEF(ML.ProductoSucursal productoSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    int rowAffected = context.ProductoSucursalUpdate(productoSucursal.IdProductoSucursal,
                                                                     productoSucursal.Stock);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el Producto";
                    }

                   DL_EF.Producto productoItem = new DL_EF.Producto();

                    context.ProductoSucursalUpdate(productoSucursal.IdProductoSucursal,
                                                   productoSucursal.Stock);

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
        }*/

        /*public static ML.Result GetByIdEF(int IdSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var productosSucursales = context.ProductoSucursalGetAll(IdSucursal).ToList();

                    if (productosSucursales.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var productoSucursal in productosSucursales)
                        {
                            ML.ProductoSucursal productoSucursalItem = new ML.ProductoSucursal();
                            productoSucursalItem.IdProductoSucursal = Convert.ToInt32(productoSucursal.IdProductoSucursal);
                            productoSucursalItem.Producto = new ML.Producto();
                            productoSucursalItem.Producto.Imagen = productoSucursal.Imagen;
                            productoSucursalItem.Producto.Nombre = productoSucursal.ProductoNombre;
                            productoSucursalItem.Sucursal = new ML.Sucursal();
                            productoSucursalItem.Sucursal.Nombre = productoSucursal.SucursalNombre;
                            productoSucursalItem.Stock = Convert.ToInt32(productoSucursal.Stock);

                            result.Objects.Add(productoSucursalItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron productos para la sucursal seleccionada.";
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

        /*public static ML.Result GetByIdEF(int IdProductoSucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var productoSucursal = context.ProductoSucursalGetById(IdProductoSucursal).SingleOrDefault();

                    if (productoSucursal != null)
                    {
                        ML.ProductoSucursal productoSucursalItem = new ML.ProductoSucursal();
                        productoSucursalItem.IdProductoSucursal = Convert.ToInt32(productoSucursal.IdProductoSucursal);
                        productoSucursalItem.Producto = new ML.Producto();
                        productoSucursalItem.Producto.Imagen = productoSucursal.Imagen;
                        productoSucursalItem.Producto.Nombre = productoSucursal.ProductoNombre;
                        productoSucursalItem.Sucursal = new ML.Sucursal();
                        productoSucursalItem.Sucursal.Nombre = productoSucursal.SucursalNombre;
                        productoSucursalItem.Stock = Convert.ToInt32(productoSucursal.Stock);

                        result.Object = productoSucursalItem;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el ProductoSucursal.";
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
