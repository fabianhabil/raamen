using raamen.Controller;
using System;
using System.Collections.Generic;

namespace raamen.View {
    public partial class AddRamen : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                List<string> meats = MeatController.getAllMeatString();
                meatSelect.DataSource = meats;
                meatSelect.DataBind();
            }
        }

        protected void addRamenBtn_Click(object sender, EventArgs e) {
            string meatName = meatSelect.Value.ToString();
            string name = nameTextbox.Text.ToString();
            string broth = brothTextbox.Text.ToString();
            string price = priceTextbox.Text.ToString();
            string notice = RamenController.add(meatName, name, broth, price);

            if (notice.Equals("Ramen added!")) {
                errorLbl.Visible = false;
                successLbl.Visible = true;
                successLbl.InnerText = notice;
                Response.Redirect("ManageRamen.aspx");
                return;
            }

            errorLbl.Visible = true;
            errorLbl.InnerText = notice;
        }
    }
}