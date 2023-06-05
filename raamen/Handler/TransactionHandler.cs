﻿using raamen.Model;
using raamen.Repository;
using System.Collections.Generic;

namespace raamen.Handler {
    public class TransactionHandler {
        public static string createTransaction(List<Ramen> cart) {
            int headerId = createHeader();
            int totalPrice = addDetail(cart, headerId);
            return HeaderRepository.editTotalHeader(totalPrice, headerId);
        }

        public static int createHeader() {
            User customer = UserHandler.getUserInfo();
            return HeaderRepository.add(customer.Id);
        }

        public static int addDetail(List<Ramen> cart, int headerId) {
            Dictionary<int, int> details = populateDetail(cart);
            int totalPrice = 0;
            foreach (var ramenPopulated in details) {
                DetailRepository.add(headerId, ramenPopulated.Key, ramenPopulated.Value);
                // Get total price by increment the hashmap and get the price from cart
                // that have the same id in the database and times by the quantity.
                totalPrice += (cart.Find(r => r.Id == ramenPopulated.Key).Price * ramenPopulated.Value);
            }

            return totalPrice;
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

        public static List<Header> getAllTransactions() {
            return HeaderRepository.getAll();
        }

        public static List<Header> getAllByCustomer(int customerId) {
            return HeaderRepository.getAllByCustomer(customerId);
        }
    }
}