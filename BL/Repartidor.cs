using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repartidor
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaRepartidores = context.RepartidorGetAll().ToList();

                    if (listaRepartidores.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var repartidor in listaRepartidores)
                        {
                            ML.Repartidor repartidorItem = new ML.Repartidor();
                            repartidorItem.IdRepartidor = repartidor.IdRepartidor;
                            //repartidorItem.Nombre = repartidor.Nombre + " " +repartidor.ApellidoPaterno + " " + repartidor.ApellidoMaterno;
                            repartidorItem.Nombre = repartidor.Nombre;
                            repartidorItem.ApellidoPaterno = repartidor.ApellidoPaterno;
                            repartidorItem.ApellidoMaterno = repartidor.ApellidoMaterno;


                            result.Objects.Add(repartidorItem);
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
        public static ML.Result GetByIdEF(int IdRepartidor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var repartidor = context.RepartidorGetById(IdRepartidor).SingleOrDefault();

                    if (repartidor != null)
                    {
                        ML.Repartidor repartidorItem = new ML.Repartidor();

                        repartidorItem.IdRepartidor = repartidor.IdRepartidor;
                        repartidorItem.Nombre = repartidor.Nombre;
                        repartidorItem.ApellidoPaterno = repartidor.ApellidoPaterno;
                        repartidorItem.ApellidoMaterno = repartidor.ApellidoMaterno;

                        result.Object = repartidorItem;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Repartidor";
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
        public static ML.Result AddEF(ML.Repartidor repartidor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DL_EF.Repartidor repartidorItem = new DL_EF.Repartidor();

                    context.RepartidorAdd(repartidor.Nombre,
                                          repartidor.ApellidoPaterno,
                                          repartidor.ApellidoMaterno);

                    context.SaveChanges();

                    result.Object = repartidorItem.IdRepartidor;
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result UpdateEF(ML.Repartidor repartidor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    DL_EF.Repartidor repartidorItem = new DL_EF.Repartidor();

                    context.RepartidorGetUpdate(repartidor.IdRepartidor,
                                                repartidor.Nombre,
                                                repartidor.ApellidoPaterno,
                                                repartidor.ApellidoMaterno);
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
        public static ML.Result DeleteEF(int IdRepartidor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    context.RepartidorGetDelete(IdRepartidor);
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
