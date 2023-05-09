﻿using raamen.Model;

namespace raamen.Factory {
    public class RoleFactory {
        public Role create(string name) {
            Role role = new Role();
            role.Name = name;

            return role;
        }
    }
}