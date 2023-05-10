using raamen.Factory;
using raamen.Model;

namespace raamen.Repository {
    public class UserRepository {
        static DatabaseEntities db = new DatabaseEntities();
        public static string register(string username, string email, string gender, string password, int roleId) {
            User user = UserFactory.create(username, email, gender, password, roleId);
            db.Users.Add(user);
            db.SaveChanges();

            return "Register Success!";
        }
    }
}