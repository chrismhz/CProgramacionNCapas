using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Supplier
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF2.NorthwindEntities context = new DL_EF2.NorthwindEntities())
                {
                    var listaSuppliers = context.GetAllSupplier().ToList();

                    if (listaSuppliers.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var supplier in listaSuppliers)
                        {
                            ML.Supplier supplierItem = new ML.Supplier();
                            supplierItem.SupplierID = supplier.SupplierID;
                            supplierItem.CompanyName = supplier.CompanyName;
                            supplierItem.ContactName = supplier.ContactName;
                            supplierItem.ContactTitle = supplier.ContactTitle;
                            supplierItem.Address = supplier.Address;
                            supplierItem.City = supplier.City;
                            supplierItem.Region = supplier.Region;
                            supplierItem.PostalCode = supplier.PostalCode;
                            supplierItem.Country = supplier.Country;
                            supplierItem.Phone = supplier.Phone;
                            supplierItem.Fax = supplier.Fax;
                            supplierItem.HomePage = supplier.HomePage;

                            result.Objects.Add(supplierItem);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registross de la tabla Suppliers \n\n";
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
