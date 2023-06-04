using raamen.Factory;
using raamen.Model;

namespace raamen.Repository {

    public class DetailRepository {
        static DatabaseEntities db = new DatabaseEntities();
        public static void add(int headerId, int ramenId, int quantity) {
            Detail detail = DetailFactory.create(headerId, ramenId, quantity);
            db.Details.Add(detail);
            db.SaveChanges();
        }
    }
}