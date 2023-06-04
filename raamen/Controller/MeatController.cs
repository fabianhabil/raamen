using raamen.Handler;
using raamen.Model;
using System.Collections.Generic;

namespace raamen.Controller {
    public class MeatController {
        public static string add(string name) {
            if (string.IsNullOrEmpty(name)) {
                return "Please fill all the fields!";
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
            return MeatHandler.getAllMeatString();
        }

        public static Meat getByName(string name) {
            return MeatHandler.getByName(name);
        }

        public static string update(int Id, string name) {
            if (string.IsNullOrEmpty(name)) {
                return "Please fill all the fields!";
            }

            return MeatHandler.update(Id, name);
        }

        public static bool delete(int Id) {
            return MeatHandler.delete(Id);
        }
    }
}