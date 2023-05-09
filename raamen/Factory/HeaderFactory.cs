using raamen.Model;
using System;

namespace raamen.Factory {
    public class HeaderFactory {
        public Header create(int customerId, int staffId, DateTime date) {
            Header header = new Header();
            header.CustomerId = customerId;
            header.StaffId = staffId;
            header.Date = date;

            return header;
        }
    }
}