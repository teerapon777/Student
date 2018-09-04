using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R_Student.Report
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new Entity.Entities())
            {
                var data = db.ViewTeacher.ToList();

                var rd = new ReportDataSource("DataSet1", data); // binding datatable
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/ReportTeacher.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rd); // Add dataDataSource

            }
        }
    }
}