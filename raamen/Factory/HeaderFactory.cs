using raamen.Model;
using System;

namespace raamen.Factory {
    public class HeaderFactory {
        public static Header create(int customerId) {
            Header header = new Header();
            header.CustomerId = customerId;
            header.Date = DateTime.Now;

            return header;
        }
    }
}