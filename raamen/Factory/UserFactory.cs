using raamen.Model;

namespace raamen.Factory {
    public class UserFactory {
        public User create(int roleId, string username, string email, string gender, string password) {
            User user = new User();
            user.Roleid = roleId;
            user.Username = username;
            user.Email = email;
            user.Gender = gender;
            user.Password = password;

            return user;
        }
    }
}