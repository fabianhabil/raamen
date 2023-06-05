using System.Web.Routing;

namespace raamen.App_Start {
    public class RouteConfig {
        public static void registerRoute(RouteCollection routes) {
            routes.MapPageRoute("Add Meat", "meat/add", "~/View/AddMeat.aspx");
            routes.MapPageRoute("Add Ramen", "ramen/add", "~/View/AddRamen.aspx");
            routes.MapPageRoute("Edit Meat", "meat/edit", "~/View/EditMeat.aspx");
            routes.MapPageRoute("Edit Ramen", "ramen/edit", "~/View/EditRamen.aspx");
            routes.MapPageRoute("Homepage", "", "~/View/Home.aspx");
            routes.MapPageRoute("Login", "login", "~/View/Login.aspx");
            routes.MapPageRoute("Manage Meat", "meat", "~/View/ManageMeat.aspx");
            routes.MapPageRoute("Manage Ramen", "ramen", "~/View/ManageRamen.aspx");
            routes.MapPageRoute("Order", "order", "~/View/Order.aspx");
            routes.MapPageRoute("Profile", "profile", "~/View/Profile.aspx");
            routes.MapPageRoute("Register", "register", "~/View/Register.aspx");
            routes.MapPageRoute("History", "history", "~/View/History.aspx");
        }
    }
}