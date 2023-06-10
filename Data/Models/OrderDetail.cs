namespace ToyMarket.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int toyID { get; set; }
        public uint price { get; set; }
        public virtual Toy toys { get; set; }
        public virtual Order order { get; set; }

    }
}
