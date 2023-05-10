using raamen.Model;

namespace raamen.Factory {
    public class DetailFactory {
        public static Detail create(int headerId, int ramenId, int quantity) {
            Detail detail = new Detail();
            detail.HeaderId = headerId;
            detail.RamenId = ramenId;
            detail.Quantity = quantity;

            return detail;
        }
    }
}