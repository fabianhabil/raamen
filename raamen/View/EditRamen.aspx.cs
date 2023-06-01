using raamen.Controller;
using raamen.Model;
using System;
using System.Collections.Generic;

namespace raamen.View {
    public partial class EditRamen : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null || user.Role.Name.Equals("Customer")) {
                    Response.Redirect("/");
                }

                string id = getIdParam();

                if (id == null) {
                    Response.Redirect("/");
                    return;
                }

                Ramen ramen = RamenController.get(int.Parse(id));

                if (ramen == null) {
                    Response.Redirect("/");
                    return;
                }

                List<string> meats = MeatController.getAllMeatString();
                meatSelect.DataSource = meats;
                meatSelect.DataBind();

                nameTextbox.Text = ramen.Name;
                meatSelect.Value = ramen.Meat.Name;
                brothTextbox.Text = ramen.Broth;
                priceTextbox.Text = ramen.Price.ToString();
            }
        }

        protected string getIdParam() {
            return Request["id"];
        }

        protected void editRamen_Click(object sender, EventArgs e) {
            string meatName = meatSelect.Value.ToString();
            string name = nameTextbox.Text.ToString();
            string broth = brothTextbox.Text.ToString();
            string price = priceTextbox.Text.ToString();
            string notice = RamenController.update(int.Parse(getIdParam()), name, broth, price, meatName);

            if (notice.Equals("Ramen updated!")) {
                errorLbl.Visible = false;
                successLbl.Visible = true;
                successLbl.InnerText = notice;
                Response.Redirect("/ramen");
                return;
            }

            errorLbl.Visible = true;
            errorLbl.InnerText = notice;
        }
    }
}