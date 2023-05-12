using raamen.Handler;
using raamen.Model;
using System;
using System.Collections.Generic;

namespace raamen.Controller {
    public class MeatController {
        public static string add(string name) {
            if (String.IsNullOrEmpty(name)) {
                return "Please fill all the fields!";
            }

            Meat checkMeat = MeatHandler.getByName(name);

            if (checkMeat != null) {
                return name + " Meat is registered! Please choose another name!";
            }

            return MeatHandler.add(name);
        }
        public static Meat get(int Id) {
            return MeatHandler.get(Id);
        }

        public static List<Meat> getAll() {
            return MeatHandler.getAll();
        }

        public static List<string> getAllMeatString() {
            List<Meat> meats = MeatHandler.getAll();
            List<string> meatString = new List<string>();
            meatString.Add("Select Meat");
            foreach (Meat m in meats) {
                meatString.Add(m.Name);
            }

            return meatString;
        }

        public static Meat getByName(string name) {
            return MeatHandler.getByName(name);
        }

        public static string update(int Id, string name) {
            if (String.IsNullOrEmpty(name)) {
                return "Please fill all the fields!";
            }

            Meat checkMeat = MeatHandler.getByName(name);

            if (checkMeat != null) {
                return name + " Meat is registered! Please choose another name!";
            }

            return MeatHandler.update(Id, name);
        }

        public static bool delete(int Id) {
            return MeatHandler.delete(Id);
        }
    }
}