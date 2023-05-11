using raamen.Controller;
using raamen.Model;
using System;

namespace raamen.View {
    public partial class Home : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null) {
                    div_guest.Visible = true;
                    return;
                }

                if (user.Role.Name.Equals("User")) {
                    div_user.Visible = true;
                }

                if (user.Role.Name.Equals("Staff")) {
                    div_staff.Visible = true;
                    userGV.DataSource = UserController.getUserByRole(1);
                    userGV.DataBind();
                }

                if (user.Role.Name.Equals("Admin")) {
                    div_admin.Visible = true;
                }
            }
        }
    }
}