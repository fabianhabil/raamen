using raamen.Model;

namespace raamen.Factory {
    public class RamenFactory {

        public Ramen create(int meatId, string name, string broth, int price) {
            Ramen ramen = new Ramen();
            ramen.MeatId = meatId;
            ramen.Name = name;
            ramen.Broth = broth;
            ramen.Price = price;

            return ramen;
        }
    }
}