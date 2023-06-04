using raamen.Handler;
using raamen.Model;
using System.Collections.Generic;

namespace raamen.Controller {
    public class OrderController {
        public static string create(List<Ramen> cart) {
            return OrderHandler.createTransaction(cart);
        }
    }
}