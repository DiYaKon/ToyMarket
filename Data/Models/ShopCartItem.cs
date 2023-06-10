namespace ToyMarket.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Toy toy { get; set; }
        public int price { get; set; }

        public string ShopCartId { get; set; }
    }
}
