using raamen.Model;
using raamen.Repository;
using System;
using System.Collections.Generic;
using System.Web;

namespace raamen {
    public class UserHandler {
        public static string register(string username, string email, string gender, string password, int roleId) {
            return UserRepository.register(username, email, gender, password, roleId);
        }

        public static string login(string username, string password, bool rememberMe) {
            User user = UserRepository.getByUsername(username);

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

            HttpContext.Current.Response.Redirect("/");

            return "Login Success!";
        }

        public static void logout() {
            removeUserCookie();
            // Remove the cart session, we dont want another user's cart is the same
            HttpContext.Current.Session.Remove("cart");
            HttpContext.Current.Response.Redirect("/");
        }

        public static bool isUserExists(string username) {
            User user = UserRepository.getByUsername(username);

            return user != null;
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

            return UserRepository.getByUsername(username);
        }

        public static string update(string newUsername, string email, string gender, string password) {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfo"];
            string oldUsername = cookie["username"];

            User user = getUserInfo();

            if (!user.Password.Equals(password)) {
                return "Password is not match!";
            }

            if (!newUsername.Equals(oldUsername) && isUserExists(newUsername)) {
                return "Username is used!";
            }

            string notice = UserRepository.update(oldUsername, newUsername, email, gender);
            setCookie(user.Username, user.Role.Name, 30);
            return notice;
        }

        public static List<User> getUserByRole(int roleId) {
            return UserRepository.getByRole(roleId);
        }

        public static void setCookie(string username, string role, int daysExpire) {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie["username"] = username;
            cookie["role"] = role;
            cookie.Expires = DateTime.Now.AddDays(daysExpire);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void removeUserCookie() {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfo"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

    }
}