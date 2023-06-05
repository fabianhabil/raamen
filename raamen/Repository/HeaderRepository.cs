using raamen.Factory;
using raamen.Model;
using System.Collections.Generic;
using System.Linq;

namespace raamen.Repository {
    public class HeaderRepository {
        static DatabaseEntities db = new DatabaseEntities();
        public static int add(int customerId) {
            Header header = HeaderFactory.create(customerId);
            db.Headers.Add(header);
            db.SaveChanges();

            return header.Id;
        }

        public static List<Header> getAll() {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from h in db.Headers select h).ToList<Header>();
        }

        public static List<Header> getAllByCustomer(int customerId) {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from h in db.Headers where h.CustomerId == customerId select h).ToList<Header>();
        }

        public static Header get(int headerId) {
            // Reinstatiate DatabaseEntities, in case record from another table is updated
            db = new DatabaseEntities();
            return (from h in db.Headers where h.Id == headerId select h).FirstOrDefault();

        }

        public static string editTotalHeader(int totalPrice, int headerId) {
            Header header = get(headerId);
            header.Total = totalPrice;

            db.SaveChanges();
            return "Order Successful!";
        }
    }
}