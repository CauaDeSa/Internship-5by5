namespace Lesson21_ProductRegister
{
    internal class Product
    {
        public int id { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

        public Product(int id, string description, double price, int quantity)
        {
            this.id = id;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        public override string? ToString()
        {
            return $"{id};{description};{price};{quantity}";
        }
    }
}
