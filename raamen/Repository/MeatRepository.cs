using raamen.Factory;
using raamen.Model;
using System.Collections.Generic;
using System.Linq;

namespace raamen.Repository {
    public class MeatRepository {
        static DatabaseEntities db = new DatabaseEntities();
        public static string add(string name) {
            Meat meat = MeatFactory.create(name);
            db.Meats.Add(meat);
            db.SaveChanges();

            return "Meat Added!";
        }

        public static Meat get(int Id) {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from m in db.Meats where m.Id == Id select m).FirstOrDefault();
        }

        public static Meat getByName(string name) {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from m in db.Meats where m.Name.Equals(name) select m).FirstOrDefault();
        }

        public static List<Meat> getAll() {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from m in db.Meats select m).ToList<Meat>();
        }

        public static string update(int Id, string name) {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            Meat meat = get(Id);

            if (meat == null) {
                return "Meat not found! Please refresh the page!";
            }

            meat.Name = name;
            db.SaveChanges();

            return "Meat updated!";
        }

        public static bool delete(int Id) {
            Meat meat = get(Id);

            if (meat == null) {
                return false;
            }

            db.Meats.Remove(meat);
            db.SaveChanges();

            return true;
        }
    }
}