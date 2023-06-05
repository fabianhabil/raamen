using raamen.Controller;
using raamen.Model;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace raamen.View {
    public partial class HandleOrder : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null || user.Role.Name.Equals("Customer")) {
                    Response.Redirect("/");
                }

                bindData();
            }
        }

        protected void handleGV_RowEditing(object sender, GridViewEditEventArgs e) {
            GridViewRow row = handleGV.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();

            successLbl.InnerText = TransactionController.handleTransaction(int.Parse(id));
            successLbl.Visible = true;

            bindData();
        }

        protected void handleGV_RowDataBound(object sender, GridViewRowEventArgs e) {
            // Because there is no total fields in table, we need to count the data one by one
            // by using aggregate Sum in LINQ.
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Header transaction = (Header)e.Row.DataItem;
                e.Row.Cells[2].Text = transaction.Details.Sum(d => d.Quantity).ToString() + " ramen";
            }
        }

        protected void bindData() {
            handleGV.DataSource = TransactionController.getUnhandledTransaction();
            handleGV.DataBind();
        }
    }
}