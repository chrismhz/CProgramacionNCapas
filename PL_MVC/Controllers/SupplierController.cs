using System;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PL_MVC.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        [HttpGet]
        public ActionResult GetAllSuppliers()
        {
            ML.Supplier supplier = new ML.Supplier();
            ML.Result result = BL.Supplier.GetAllEF();

            //REPORTES
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\SupplierR.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", result.Objects));
            ViewBag.ReportViewer = reportViewer;



            if (result.Correct)
            {
                supplier.Suppliers = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GetAllSuppliers", supplier);
        }

        [HttpPost]
        public ActionResult GetAllSuppliers(ML.Supplier supplier)
        {
            ML.Result result = BL.Supplier.GetAllEF();

            if (result.Correct)
            {
                supplier.Suppliers = result.Objects;
            }
            else
            {
                ViewBag.MensajeError = "No se encontraron registros " + result.ErrorMessage;
            }

            return View("GetAllSuppliers", supplier);
        }
    }
}