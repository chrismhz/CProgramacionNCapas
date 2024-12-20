using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAllEF(int IdSubcategoria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaProductos = context.ProductoGetAll(IdSubcategoria).ToList();

                    if(listaProductos.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach(var producto in listaProductos)
                        {
                            ML.Producto productoItem = new ML.Producto();
                            productoItem.IdProducto = producto.IdProducto;
                            productoItem.Nombre = producto.Nombre;
                            productoItem.Descripcion = producto.Descripcion;
                            productoItem.Precio = Convert.ToDecimal(producto.Precio);
                            productoItem.Imagen = producto.Imagen;

                            productoItem.SubCategoria = new ML.SubCategoria();
                            productoItem.SubCategoria.IdSubCategoria = Convert.ToInt32(producto.IdSubCategoria);
                            productoItem.SubCategoria.Nombre = producto.SubCategoriaNombre;

                            productoItem.SubCategoria.Categoria = new ML.Categoria();
                            productoItem.SubCategoria.Categoria.IdCategoria = Convert.ToInt32(producto.IdCategoria);
                            productoItem.SubCategoria.Categoria.Nombre = producto.CategoriaNombre;


                            result.Objects.Add(productoItem);
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

        public static ML.Result GetByIdEF(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities contex = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var producto = contex.ProductoGetById(IdProducto).SingleOrDefault();

                    if(producto != null) 
                    {
                        ML.Producto productoItem = new ML.Producto();
                        
                        productoItem.IdProducto = producto.IdProducto;
                        productoItem.Nombre = producto.Nombre;
                        productoItem.Descripcion = producto.Descripcion;
                        productoItem.Precio = Convert.ToDecimal(producto.Precio);
                        productoItem.Imagen = producto.Imagen;

                        productoItem.SubCategoria = new ML.SubCategoria();
                        productoItem.SubCategoria.IdSubCategoria = Convert.ToInt32(producto.IdSubCategoria);
                        productoItem.SubCategoria.Nombre = producto.SubCategoriaNombre;

                        productoItem.SubCategoria.Categoria = new ML.Categoria();
                        productoItem.SubCategoria.Categoria.IdCategoria = Convert.ToInt32(producto.IdCategoria);
                        productoItem.SubCategoria.Categoria.Nombre = producto.CategoriaNombre;

                        result.Object = productoItem;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros de la tabla Producto";
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

        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DL_EF.Producto productoItem = new DL_EF.Producto();

                    context.ProductoAdd(producto.Nombre,
                                        producto.Descripcion,
                                        producto.Precio,
                                        producto.Imagen,
                                        producto.SubCategoria.IdSubCategoria);

                    context.SaveChanges();

                    result.Object = productoItem.IdProducto;
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
                    context.ProductoGetDelete(IdProducto);
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

        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DL_EF.Producto productoItem = new DL_EF.Producto();

                    context.ProductoGetUpdate(producto.IdProducto,
                                              producto.Nombre,
                                              producto.Descripcion,
                                              producto.Precio,
                                              producto.Imagen,
                                              producto.SubCategoria.IdSubCategoria);

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
