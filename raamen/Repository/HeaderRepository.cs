using raamen.Factory;
using raamen.Model;

namespace raamen.Repository {
    public class HeaderRepository {
        static DatabaseEntities db = new DatabaseEntities();
        public static int add(int customerId) {
            Header header = HeaderFactory.create(customerId);
            db.Headers.Add(header);
            db.SaveChanges();

            return header.Id;
        }
    }
}