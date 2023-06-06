using raamen.Controller;
using raamen.Dataset;
using raamen.Model;
using raamen.Report;
using System;
using System.Collections.Generic;
using System.Linq;

namespace raamen.View {
    public partial class Report : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            CrystalReport report = new CrystalReport();
            CrystalReportViewer1.ReportSource = report;
            DataSet data = getDataSet(TransactionController.getHandledTransaction());
            report.SetDataSource(data);
        }

        private DataSet getDataSet(List<Header> transactions) {
            DataSet data = new DataSet();
            var headerTable = data.Transaction_Header;
            var detailTable = data.Transaction_Detail;

            foreach (Header h in transactions) {
                var hrow = headerTable.NewRow();
                hrow["Id"] = h.Id;
                hrow["CustomerID"] = h.CustomerId;
                hrow["StaffID"] = h.StaffId;
                hrow["Date"] = h.Date;
                hrow["Total"] = "Rp" + h.Details.Sum(d => d.Quantity * d.Ramen.Price).ToString();
                headerTable.Rows.Add(hrow);

                foreach (Detail d in h.Details) {
                    var drow = detailTable.NewRow();
                    drow["HeaderId"] = d.HeaderId;
                    drow["RamenId"] = d.RamenId;
                    drow["Quantity"] = d.Quantity + " pcs";
                    drow["RamenName"] = d.Ramen.Name;
                    drow["Price"] = "Rp" + d.Ramen.Price.ToString();
                    detailTable.Rows.Add(drow);
                }

            }
            return data;
        }
    }
}