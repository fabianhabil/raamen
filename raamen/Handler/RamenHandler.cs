using raamen.Model;
using raamen.Repository;
using System.Collections.Generic;

namespace raamen.Handler {
    public class RamenHandler {
        public static string add(int meatId, string name, string broth, int price) {
            return RamenRepository.add(meatId, name, broth, price);
        }

        public static List<Ramen> getAll() {
            return RamenRepository.getAll();
        }

        public static Ramen get(int id) {
            return RamenRepository.get(id);
        }

        public static string update(int id, string name, string broth, int price, int meatId) {
            return RamenRepository.update(id, name, broth, price, meatId);
        }

        public static bool delete(int id) {
            return RamenRepository.delete(id);
        }
    }
}