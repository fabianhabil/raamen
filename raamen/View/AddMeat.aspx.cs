using raamen.Controller;
using System;

namespace raamen.View {
    public partial class AddMeat : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void addMeatBtn_Click(object sender, EventArgs e) {
            string notice = MeatController.add(nameTextbox.Text.ToString());
            if (notice.Equals("Meat Added!")) {
                errorLbl.Visible = false;
                successLbl.Visible = true;
                successLbl.InnerText = notice;
                Response.Redirect("ManageMeat.aspx");
                return;
            }
            errorLbl.Visible = true;
            errorLbl.InnerText = notice;
        }
    }
}