using raamen.Model;
using raamen.Repository;
using System.Collections.Generic;

namespace raamen.Handler {
    public class RamenHandler {
        public static string add(string meatName, string name, string broth, int price) {
            int meatId = MeatRepository.getByName(meatName).Id;

            return RamenRepository.add(meatId, name, broth, price);
        }

        public static List<Ramen> getAll() {
            return RamenRepository.getAll();
        }

        public static Ramen get(int id) {
            return RamenRepository.get(id);
        }

        public static string update(int id, string meatName, string name, string broth, int price) {
            int meatId = MeatRepository.getByName(meatName).Id;

            return RamenRepository.update(id, name, broth, price, meatId);
        }

        public static bool delete(int id) {
            return RamenRepository.delete(id);
        }
    }
}