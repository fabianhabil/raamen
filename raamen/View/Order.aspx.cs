﻿using raamen.Controller;
using raamen.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace raamen.View {
    public partial class Order : System.Web.UI.Page {
        public List<Ramen> ramen { get { return RamenController.getAll(); } }
        public List<Ramen> cart {
            get {
                if (Session["cart"] == null) {
                    Session["cart"] = new List<Ramen>();
                }
                return (List<Ramen>)Session["cart"];
            }
            set { Session["cart"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                User user = UserController.getUserInfo();

                if (user == null || !user.Role.Name.Equals("Customer")) {
                    Response.Redirect("/");
                }

                if (ramen.Count == 0) {
                    noItemAvailable.Visible = true;
                }

                ramenRepeater.DataSource = ramen;
                ramenRepeater.DataBind();

                cartRepeater.DataSource = cart;
                cartRepeater.DataBind();
            }
        }

        protected void buyBtn_Click(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            string value = btn.CommandArgument.ToString();
            cart.Add(ramen[int.Parse(value)]);
            Response.Redirect("/order");
        }

        protected void deleteCartBtn_Click(object sender, EventArgs e) {
            cart.Clear();
            Response.Redirect("/order");
        }

        protected void buyCartBtn_Click(object sender, EventArgs e) {
            if (cart.Count == 0 || cart == null) {
                successLbl.Visible = false;
                errorLbl.Visible = true;
                errorLbl.InnerText = "Please add some item to cart!";
                return;
            }
            successLbl.InnerText = TransactionController.create(cart);
            errorLbl.Visible = false;
            successLbl.Visible = true;
            cart.Clear();
        }
    }
}