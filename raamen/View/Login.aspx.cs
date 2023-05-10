using System;

namespace raamen.View {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void loginBtn_Click(object sender, EventArgs e) {
            noticeLbl.Text = usernameTextbox.Text.ToString() + passwordTextbox.Text.ToString() + rememberMe.Checked.ToString();
        }
    }
}