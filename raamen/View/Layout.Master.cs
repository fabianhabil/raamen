using raamen.Controller;
using raamen.Model;
using System;

namespace raamen.View {
    public partial class Layout : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (!UserController.isLoggedIn()) {
                nav_guest.Visible = true;
                nav_loggedin.Visible = false;
                return;
            }
            User user = UserController.getUserInfo();

            if (user.Role.Name.Equals("Customer")) {
                nav_user.Visible = true;
            }

            if (user.Role.Name.Equals("Staff")) {
                nav_staff.Visible = true;
            }

            if (user.Role.Name.Equals("Admin")) {
                nav_admin.Visible = true;
            }

            username.InnerText = "Hi, " + user.Username;
        }

        protected void logoutBtn_ServerClick(object sender, EventArgs e) {
            UserController.logout();
        }
    }
}