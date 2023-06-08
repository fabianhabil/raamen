using raamen.Controller;
using raamen.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace raamen.View {
    public partial class ManageRamen : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null || user.Role.Name.Equals("Customer")) {
                    Response.Redirect("/");
                }

                loadData();
            }
        }

        protected void loadData() {
            List<Ramen> ramens = RamenController.getAll();

            if (ramens.Count == 0) {
                noRamen.Visible = true;
            }

            ramenGV.DataSource = ramens;
            ramenGV.DataBind();
        }

        protected void addRamen_ServerClick(object sender, EventArgs e) {
            Response.Redirect("/ramen/add");
        }

        protected void manageMeat_ServerClick(object sender, EventArgs e) {
            Response.Redirect("/meat");
        }

        protected void ramenGV_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e) {
            GridViewRow row = ramenGV.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[0].Text.ToString());

            bool deleteStatus = RamenController.delete(id);
            if (!deleteStatus) {
                errorLbl.InnerText = "Error, Ramen not found! Please refresh the page!";
                return;
            }

            loadData();
        }

        protected void ramenGV_RowEditing(object sender, GridViewEditEventArgs e) {
            GridViewRow row = ramenGV.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text.ToString();

            Response.Redirect("/ramen/edit?id=" + id);
        }
    }
}