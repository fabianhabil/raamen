using raamen.Handler;
using raamen.Model;
using System;
using System.Collections.Generic;

namespace raamen.Controller {
    public class RamenController {
        // UI State for cart.
        public readonly static List<Ramen> cart = new List<Ramen>();

        public static void addCart(Ramen ramen) {
            cart.Add(ramen);
        }

        public static List<Ramen> getAllCart() {
            return cart;
        }

        public static void deleteFromCart(int index) {
            cart.RemoveAt(index);
        }

        public static void deleteCart() {
            cart.Clear();
        }

        public static string add(string meatName, string name, string borth, string price) {
            string validateRamen = validateRamenData(meatName, name, borth, price);

            if (validateRamen != null) {
                return validateRamen;
            }

            int meatId = MeatController.getByName(meatName).Id;

            return RamenHandler.add(meatId, name, borth, int.Parse(price));
        }

        public static string validateRamenData(string meatName, string name, string borth, string price) {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(borth) || String.IsNullOrEmpty(price)) {
                return "Please fill all the fields!";
            }

            int priceInt = int.Parse(price);

            if (!checkRamenName(name)) {
                return "Ramen name must be contains Ramen in it! Example -> Ramen Chicken or Chicken Ramen";
            }

            if (meatName.Equals("Select Meat")) {
                return "Select Meat!";
            }

            if (priceInt < 3000) {
                return "Ramen price must be at least 3000!";
            }

            return null;
        }

        public static bool checkRamenName(string name) {
            string[] split = name.Split(' ');
            for (int i = 0; i < split.Length; i++) {
                if (split[i].Equals("Ramen")) {
                    return true;
                }
            }
            return false;
        }

        public static List<Ramen> getAll() {
            return RamenHandler.getAll();
        }

        public static Ramen get(int id) {
            return RamenHandler.get(id);
        }

        public static bool delete(int Id) {
            return RamenHandler.delete(Id);
        }

        public static string update(int id, string name, string broth, string price, string meatName) {
            string validateRamen = validateRamenData(meatName, name, broth, price);

            if (validateRamen != null) {
                return validateRamen;
            }

            int meatId = MeatController.getByName(meatName).Id;

            return RamenHandler.update(id, name, broth, int.Parse(price), meatId);
        }
    }
}