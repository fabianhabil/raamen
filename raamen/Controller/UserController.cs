using raamen.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace raamen.Controller {
    public class UserController {
        public static string register(string username, string email, string gender, string password, string confpass) {
            string isFieldValidated = validateAllField(username, email, gender, password, confpass);

            if (isFieldValidated != null) {
                return isFieldValidated;
            }

            if (!password.Equals(confpass)) {
                return "Password is not match!";
            }

            if (isUserExists(username)) {
                return "Username is used!";
            }

            return UserHandler.register(username, email, gender, password, 1);
        }

        public static string isFieldFilled(string username, string email, string gender, string password, string confpass) {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || gender.Equals("null") || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confpass)) {
                return "Please fill all the fields!";
            }

            return null;
        }

        public static string validateUsername(string username) {
            if (username.Length > 15 || username.Length < 5) {
                return "Length must be between 5 and 15";
            }

            // Regex obtained from stackoverflow.
            bool isStringContainNumber = Regex.IsMatch(username, "^[A-Za-z ]*$");

            if (!isStringContainNumber) {
                return "Username can only contains alphabet and space!";
            }

            return null;
        }

        public static string validateEmail(string email) {
            if (!email.Contains(".com")) {
                return "Email must ends with '.com'";
            }

            return null;
        }

        public static string validateAllField(string username, string email, string gender, string password, string confpass) {
            string fieldValidated = isFieldFilled(username, email, gender, password, confpass);

            if (fieldValidated != null) {
                return fieldValidated;
            }

            string usernameValidated = validateUsername(username);

            if (usernameValidated != null) {
                return usernameValidated;
            }

            string emailValidated = validateEmail(email);

            if (emailValidated != null) {
                return emailValidated;
            }

            return null;
        }
        public static string login(string username, string password, bool rememberMe) {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
                return "Please fill all the fields!";
            }

            return UserHandler.login(username, password, rememberMe);
        }

        public static void logout() {
            UserHandler.logout();
        }

        public static bool isUserExists(string username) {
            return UserHandler.isUserExists(username);
        }

        public static bool isLoggedIn() {
            return UserHandler.isLoggedIn();
        }

        public static User getUserInfo() {
            return UserHandler.getUserInfo();
        }

        public static string update(string newUsername, string email, string gender, string password) {
            string isFieldValidated = validateAllField(newUsername, email, gender, password, password);

            if (isFieldValidated != null) {
                return isFieldValidated;
            }

            return UserHandler.update(newUsername, email, gender, password);
        }

        public static List<User> getUserByRole(int roleId) {
            return UserHandler.getUserByRole(roleId);
        }
    }
}