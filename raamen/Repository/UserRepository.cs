using raamen.Factory;
using raamen.Model;
using System.Collections.Generic;
using System.Linq;

namespace raamen.Repository {
    public class UserRepository {
        static DatabaseEntities db = new DatabaseEntities();
        public static string register(string username, string email, string gender, string password, int roleId) {
            User user = UserFactory.create(username, email, gender, password, roleId);
            db.Users.Add(user);
            db.SaveChanges();

            return "Register Success!";
        }

        public static User getByUsername(string username) {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from u in db.Users where u.Username == username select u).FirstOrDefault();
        }

        public static string update(string oldUsername, string newUsername, string email, string gender) {
            User user = getByUsername(oldUsername);
            user.Username = newUsername;
            user.Email = email;
            user.Gender = gender;

            db.SaveChanges();
            return "User Updated!";
        }

        public static List<User> getByRole(int roleId) {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from u in db.Users where u.RoleId == roleId select u).ToList<User>();
        }
    }
}