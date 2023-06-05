using raamen.Model;

namespace raamen.Factory {
    public class UserFactory {
        public static User create(string username, string email, string gender, string password, int roleId) {
            User user = new User();
            user.Username = username;
            user.Email = email;
            user.Gender = gender;
            user.Password = password;

            // 1 = Member, 2 = Staff, 3 = Admin
            user.RoleId = roleId;

            return user;
        }
    }
}