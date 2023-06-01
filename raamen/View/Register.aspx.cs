using raamen.Controller;
using System;

namespace raamen.View {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (UserController.isLoggedIn()) {
                Response.Redirect("/");
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e) {
            string username = usernameTextbox.Text.ToString();
            string email = emailTextbox.Text.ToString();
            string gender = genderSelect.Value.ToString();
            string password = passwordTextbox.Text.ToString();
            string confpass = passconfTextbox.Text.ToString();

            string notice = UserController.register(username, email, gender, password, confpass);

            if (notice.Equals("Register Success!")) {
                errorLbl.Visible = false;
                successLbl.Visible = true;
                successLbl.InnerText = notice;
                return;
            }

            successLbl.Visible = false;
            errorLbl.Visible = true;
            errorLbl.InnerText = notice;
        }
    }
}