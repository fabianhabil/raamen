using raamen.Controller;
using raamen.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace raamen.View {
    public partial class Order : System.Web.UI.Page {
        public static List<Ramen> ramen { get { return RamenController.getAll(); } }
        public static List<Ramen> cart { get { return RamenController.getAllCart(); } }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                ramenRepeater.DataSource = ramen;
                ramenRepeater.DataBind();

                testRepeater.DataSource = cart;
                testRepeater.DataBind();
            }

        }

        protected void buyBtn_Click(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            string value = btn.CommandArgument.ToString();
            RamenController.addCart(ramen[int.Parse(value)]);
            Response.Redirect("Order.aspx");
        }

        protected void deleteCartBtn_Click(object sender, EventArgs e) {
            RamenController.deleteCart();
            Response.Redirect("Order.aspx");
        }

        protected void buyCartBtn_Click(object sender, EventArgs e) {

        }
    }
}