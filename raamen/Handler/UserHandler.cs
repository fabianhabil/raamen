using raamen.Repository;

namespace raamen {
    public class UserHandler {
        public static string register(string username, string email, string gender, string password, int roleId) {
            return UserRepository.register(username, email, gender, password, roleId);
        }
    }
}