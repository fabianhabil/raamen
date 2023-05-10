using System;

namespace raamen.View {
    public partial class Layout : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            username.Visible = true;
        }
    }
}