using raamen.Model;
using raamen.Repository;
using System.Collections.Generic;

namespace raamen.Handler {
    public class MeatHandler {

        public static string add(string name) {
            return MeatRepository.add(name);
        }

        public static Meat get(int Id) {
            return MeatRepository.get(Id);
        }
        public static Meat getByName(string name) {
            return MeatRepository.getByName(name);
        }

        public static List<Meat> getAll() {
            return MeatRepository.getAll();
        }

        public static string update(int Id, string name) {
            return MeatRepository.update(Id, name);
        }

        public static bool delete(int Id) {
            return MeatRepository.delete(Id);
        }
    }
}