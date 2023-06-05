using raamen.Handler;
using raamen.Model;
using System.Collections.Generic;

namespace raamen.Controller {
    public class TransactionController {
        public static string create(List<Ramen> cart) {
            return TransactionHandler.createTransaction(cart);
        }

        public static List<Header> getAllTransactions() {
            return TransactionHandler.getAllTransactions();
        }

        public static List<Header> getAllByCustomer(int customerId) {
            return TransactionHandler.getAllByCustomer(customerId);
        }
    }
}