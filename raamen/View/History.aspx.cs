using raamen.Controller;
using raamen.Model;
using System;
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

                    userGV.DataSource = TransactionController.getAllByCustomer(user.Id);
                    userGV.DataBind();
                }

                if (user.Role.Name.Equals("Admin")) {
                    div_admin.Visible = true;

                    adminGV.DataSource = TransactionController.getAllTransactions();
                    adminGV.DataBind();
                }
            }
        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e) {
            GridViewRow row = userGV.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();

            Response.Redirect("/history/view?id=" + id);
        }
    }
}