using System.Text.RegularExpressions;

namespace raamen.Controller {
    public class UserController {
        public static string register(string username, string email, string gender, string password, string confpass) {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || gender.Equals("null") || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confpass)) {
                return "Fields cannot be empty!";
            }

            string usernameValidated = validateUsername(username);

            if (usernameValidated != null) {
                return usernameValidated;
            }

            string emailValidated = validateEmail(email);

            if (emailValidated != null) {
                return emailValidated;
            }


            if (!password.Equals(confpass)) {
                return "Password is not match!";
            }

            return UserHandler.register(username, email, gender, password, 1);
        }

        public static string validateUsername(string username) {
            if (username.Length > 15 || username.Length < 5) {
                return "Length must be between 5 and 15";
            }

            // Regex obtained from stackoverflow.
            bool isStringContainNumber = Regex.IsMatch(username, @"^[a-zA-Z]+$");

            if (!isStringContainNumber) {
                return "Username can only contains alphabet!";
            }

            return null;
        }

        public static string validateEmail(string email) {
            if (!email.Contains(".com")) {
                return "Email must ends with '.com'";
            }

            return null;
        }
    }
}