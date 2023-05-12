using raamen.Controller;
using raamen.Model;
using System;
using System.Web.UI.WebControls;

namespace raamen.View {
    public partial class ManageMeat : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null || user.Role.Name.Equals("Customer")) {
                    Response.Redirect("Home.aspx");
                    return;
                }

                loadData();
            }
        }

        protected void loadData() {
            meatGV.DataSource = MeatController.getAll();
            meatGV.DataBind();
        }

        protected void addMeat_ServerClick(object sender, EventArgs e) {
            Response.Redirect("AddMeat.aspx");
        }

        protected void manageRamen_ServerClick(object sender, EventArgs e) {
            Response.Redirect("ManageRamen.aspx");
        }

        protected void meatGV_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e) {
            GridViewRow row = meatGV.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[0].Text.ToString());

            bool deleteStatus = MeatController.delete(id);
            if (!deleteStatus) {
                errorLbl.InnerText = "Error, meat not found! Please refresh the page!";
                return;
            }

            loadData();
        }

        protected void meatGV_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e) {
            GridViewRow row = meatGV.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();

            Response.Redirect("EditMeat.aspx?id=" + id);
        }
    }
}