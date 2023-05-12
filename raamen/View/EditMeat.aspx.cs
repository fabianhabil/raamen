using raamen.Controller;
using raamen.Model;
using System;

namespace raamen.View {
    public partial class EditMeat : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string id = getIdParam();

                if (id == null) {
                    Response.Redirect("Home.aspx");
                    return;
                }

                Meat meat = MeatController.get(int.Parse(id));

                if (meat == null) {
                    Response.Redirect("Home.aspx");
                    return;
                }

                nameTextbox.Text = meat.Name;
            }
        }

        protected void editMeatBtn_Click(object sender, EventArgs e) {
            string notice = MeatController.update(int.Parse(getIdParam()), nameTextbox.Text.ToString());
            if (notice.Equals("Meat updated!")) {
                errorLbl.Visible = false;
                successLbl.Visible = true;
                successLbl.InnerText = notice;
                Response.Redirect("ManageMeat.aspx");
                return;
            }
            errorLbl.Visible = true;
            errorLbl.InnerText = notice;
        }

        protected string getIdParam() {
            return Request["id"];
        }
    }
}