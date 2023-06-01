using raamen.Model;
using System.Collections.Generic;
using System.Linq;

namespace raamen.Repository {
    public class RamenRepository {
        static DatabaseEntities db = new DatabaseEntities();
        public static string add(int meatId, string name, string broth, int price) {
            Ramen ramen = new Ramen();
            ramen.MeatId = meatId;
            ramen.Name = name;
            ramen.Broth = broth;
            ramen.Price = price;

            db.Ramen1.Add(ramen);
            db.SaveChanges();

            return "Ramen added!";
        }

        public static List<Ramen> getAll() {
            // Reinstatiate DatabaseEntities, in case record from Meat table is updated
            // so its updated.
            db = new DatabaseEntities();
            return (from r in db.Ramen1.Include("Meat") select r).ToList<Ramen>();
        }

        public static Ramen get(int Id) {
            // Reinstatiate DatabaseEntities, in case record from Meat table is updated
            // so its updated.
            return (from r in db.Ramen1.Include("Meat") where r.Id == Id select r).FirstOrDefault();
        }

        public static string update(int id, string name, string broth, int price, int meatId) {
            Ramen ramen = get(id);

            if (ramen == null) {
                return "Ramen not found! Please refresh the page!";
            }

            ramen.Name = name;
            ramen.MeatId = meatId;
            ramen.Broth = broth;
            ramen.Price = price;

            db.SaveChanges();
            return "Ramen updated!";
        }

        public static bool delete(int id) {
            Ramen ramen = get(id);

            if (ramen == null) {
                return false;
            }

            db.Ramen1.Remove(ramen);
            db.SaveChanges();

            return true;
        }
    }
}