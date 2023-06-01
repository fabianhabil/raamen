using raamen.Controller;
using raamen.Model;
using System;

namespace raamen.View {
    public partial class Profile : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!UserController.isLoggedIn()) {
                Response.Redirect("/");
                return;
            }

            if (!IsPostBack) {
                User user = UserController.getUserInfo();
                usernameTextbox.Text = user.Username;
                emailTextbox.Text = user.Email;
                genderSelect.Value = user.Gender;
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e) {
            string username = usernameTextbox.Text.ToString();
            string email = emailTextbox.Text.ToString();
            string gender = genderSelect.Value.ToString();
            string password = passwordTextbox.Text.ToString();

            string notice = UserController.update(username, email, gender, password);

            if (notice.Equals("User Updated!")) {
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