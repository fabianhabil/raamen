using raamen.Model;

namespace raamen.Factory {
    public class MeatFactory {
        public Meat create(string name) {
            Meat meat = new Meat();
            meat.Name = name;

            return meat;
        }
    }
}