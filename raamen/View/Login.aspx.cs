using raamen.Controller;
using System;

namespace raamen.View {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (UserController.isLoggedIn()) {
                Response.Redirect("/");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e) {
            string username = usernameTextbox.Text.ToString();
            string password = passwordTextbox.Text.ToString();
            bool remember = rememberMe.Checked;

            string notice = UserController.login(username, password, remember);

            if (!notice.Equals("Login Success!")) {
                errorLbl.Visible = true;
                errorLbl.InnerText = notice;
                return;
            }
            errorLbl.Visible = false;
        }
    }
}