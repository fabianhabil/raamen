using raamen.Controller;
using raamen.Model;
using System;
using System.Linq;

namespace raamen.View {
    public partial class ViewOrder : System.Web.UI.Page {
        public Header transactions = null;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();
                string id = getIdParam();

                if (user == null || user.Role.Name.Equals("Staff") || id == null) {
                    Response.Redirect("/");
                }


                transactions = TransactionController.getById(int.Parse(id));

                if (transactions == null) {
                    Response.Redirect("/");
                    return;
                }

                price.InnerText = "Total - Rp" + transactions.Details.Sum(d => d.Ramen.Price * d.Quantity).ToString();
                ramenRepeater.DataSource = transactions.Details;
                ramenRepeater.DataBind();
            }
        }

        protected string getIdParam() {
            return Request["id"];
        }
    }
}