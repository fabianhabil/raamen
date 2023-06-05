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

        public static Header getById(int headerId) {
            return TransactionHandler.getById(headerId);
        }

        public static List<Header> getUnhandledTransaction() {
            return TransactionHandler.getUnhandledTransaction();
        }

        public static string handleTransaction(int headerId) {
            return TransactionHandler.handleTransaction(headerId);
        }
    }
}