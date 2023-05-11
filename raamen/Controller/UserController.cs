using raamen.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

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

        public static bool isUserExists(string username) {
            User user = UserHandler.getByUsername(username);

            return user != null;
        }

        public static string login(string username, string password, bool rememberMe) {
            if (username.Equals("") || password.Equals("")) {
                return "Please fill all the fields!";
            }

            User user = UserHandler.getByUsername(username);

            if (user == null) {
                return "User not found!";
            }

            if (user.Password != password) {
                return "Incorrect Password!";
            }

            if (rememberMe) {
                setCookie(user.Username, user.Role.Name, 30);
            } else {
                setCookie(user.Username, user.Role.Name, 1);
            }

            HttpContext.Current.Response.Redirect("Home.aspx");

            return "Login Success!";
        }

        public static void setCookie(string username, string role, int daysExpire) {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie["username"] = username;
            cookie["role"] = role;
            cookie.Expires = DateTime.Now.AddDays(daysExpire);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void logout() {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfo"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Response.Redirect("Home.aspx");
        }

        public static bool isLoggedIn() {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfo"];
            return cookie != null;
        }

        public static User getUserInfo() {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfo"];

            if (cookie == null)
                return null;

            string username = cookie["username"];

            return UserHandler.getByUsername(username);
        }

        public static string update(string newUsername, string email, string gender, string password) {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfo"];
            string oldUsername = cookie["username"];
            string isFieldValidated = validateAllField(newUsername, email, gender, password, password);

            if (isFieldValidated != null) {
                return isFieldValidated;
            }

            User user = getUserInfo();

            if (!user.Password.Equals(password)) {
                return "Password is not match!";
            }

            if (!newUsername.Equals(oldUsername) && isUserExists(newUsername)) {
                return "Username is used!";
            }

            string notice = UserHandler.update(oldUsername, newUsername, email, gender);
            setCookie(user.Username, user.Role.Name, 30);
            return notice;
        }

        public static List<User> getUserByRole(int roleId) {
            return UserHandler.getUserByRole(roleId);
        }
    }
}