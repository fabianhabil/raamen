using raamen.Controller;
using raamen.Model;
using System;

namespace raamen.View {
    public partial class AddMeat : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null || user.Role.Name.Equals("Customer")) {
                    Response.Redirect("/");
                }
            }
        }

        protected void addMeatBtn_Click(object sender, EventArgs e) {
            string notice = MeatController.add(nameTextbox.Text.ToString());
            if (notice.Equals("Meat Added!")) {
                errorLbl.Visible = false;
                successLbl.Visible = true;
                successLbl.InnerText = notice;
                Response.Redirect("/meat");
                return;
            }
            errorLbl.Visible = true;
            errorLbl.InnerText = notice;
        }
    }
}