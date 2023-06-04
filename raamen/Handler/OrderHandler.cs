using raamen.Model;
using raamen.Repository;
using System.Collections.Generic;

namespace raamen.Handler {
    public class OrderHandler {
        public static string createTransaction(List<Ramen> cart) {
            int headerId = createHeader();
            return addDetail(cart, headerId);
        }

        public static int createHeader() {
            User customer = UserHandler.getUserInfo();
            return HeaderRepository.add(customer.Id);
        }

        public static string addDetail(List<Ramen> cart, int headerId) {
            Dictionary<int, int> details = populateDetail(cart);
            foreach (var ramenPopulated in details) {
                DetailRepository.add(headerId, ramenPopulated.Key, ramenPopulated.Value);
            }

            return "Order Successful!";
        }

        public static Dictionary<int, int> populateDetail(List<Ramen> cart) {
            // Returning hashmap of details ramen cart
            // Example, there is two ramen A with id 1
            // then the hashmap is details[1] = 2
            // so we can input to the database the ramen is already populated.
            Dictionary<int, int> details = new Dictionary<int, int>();
            foreach (Ramen r in cart) {
                if (details.ContainsKey(r.Id)) {
                    details[r.Id]++;
                } else {
                    details.Add(r.Id, 1);
                }
            }
            return details;
        }
    }
}