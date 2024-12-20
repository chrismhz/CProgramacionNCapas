using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoPago
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.CMartinezProgramacionNCapasEntities context = new DL_EF.CMartinezProgramacionNCapasEntities())
                {
                    var listaTipoPago = context.TipoPagoGetAll().ToList();

                    if (listaTipoPago.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var tipoPago in listaTipoPago)
                        {
                            ML.TipoPago tipoPagoItem = new ML.TipoPago();
                            //tipoPagoItem.IdTipoPago = tipoPago.IdTipoPago;
                            tipoPagoItem.IdTipoPago = new byte[] { tipoPago.IdTipoPago };
                            tipoPagoItem.Nombre = tipoPago.Nombre;

                            result.Objects.Add(tipoPagoItem);
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
    }
}
