using raamen.Model;
using raamen.Repository;
using System.Collections.Generic;

namespace raamen {
    public class UserHandler {
        public static string register(string username, string email, string gender, string password, int roleId) {
            return UserRepository.register(username, email, gender, password, roleId);
        }

        public static User getByUsername(string username) {
            return UserRepository.getByUsername(username);
        }

        public static string update(string oldUsername, string newUsername, string email, string gender) {
            return UserRepository.update(oldUsername, newUsername, email, gender);
        }

        public static List<User> getUserByRole(int roleId) {
            return UserRepository.getByRole(roleId);
        }
    }
}