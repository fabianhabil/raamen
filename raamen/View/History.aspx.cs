using raamen.Controller;
using raamen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace raamen.View {
    public partial class History : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null || user.Role.Name.Equals("Staff")) {
                    Response.Redirect("/");
                }

                if (user.Role.Name.Equals("Customer")) {
                    div_user.Visible = true;
                    userNotice.InnerText = "Transactions History for " + user.Username;

                    List<Header> headerCustomer = TransactionController.getAllByCustomer(user.Id);
                    if (headerCustomer.Count == 0) {
                        noTransactionUser.Visible = true;
                    }

                    userGV.DataSource = headerCustomer;
                    userGV.DataBind();
                }

                if (user.Role.Name.Equals("Admin")) {
                    div_admin.Visible = true;

                    List<Header> headerAll = TransactionController.getAllTransactions();
                    if (headerAll.Count == 0) {
                        noTransactionAdmin.Visible = true;
                    }

                    adminGV.DataSource = headerAll;
                    adminGV.DataBind();
                }
            }
        }

        protected void userGV_RowEditing(object sender, GridViewEditEventArgs e) {
            GridViewRow row = userGV.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();

            Response.Redirect("/history/view?id=" + id);
        }

        protected void adminGV_RowEditing(object sender, GridViewEditEventArgs e) {
            GridViewRow row = adminGV.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();

            Response.Redirect("/history/view?id=" + id);
        }

        protected void userGV_RowDataBound(object sender, GridViewRowEventArgs e) {
            // Because there is no total fields in table, we need to count the data one by one
            // by using aggregate Sum in LINQ.
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Header transaction = (Header)e.Row.DataItem;
                e.Row.Cells[2].Text = transaction.Details.Sum(d => d.Quantity).ToString() + " ramen";
                e.Row.Cells[3].Text = "Rp" + transaction.Details.Sum(d => d.Ramen.Price * d.Quantity).ToString();
            }
        }

        protected void adminGV_RowDataBound(object sender, GridViewRowEventArgs e) {
            // Because there is no total fields in table, we need to count the data one by one
            // by using aggregate Sum in LINQ.
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Header transaction = (Header)e.Row.DataItem;
                e.Row.Cells[3].Text = transaction.Details.Sum(d => d.Quantity).ToString() + " ramen";
                e.Row.Cells[4].Text = "Rp" + transaction.Details.Sum(d => d.Ramen.Price * d.Quantity).ToString();
            }
        }
    }
}