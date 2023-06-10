namespace ToyMarket.Data.Models
{
    public class Toy
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public string img { set; get; }
        public ushort price { set; get; }
        public bool isFavourite { set; get; }
        public bool available { set; get; }
        public int categoryID { set; get; } //категорія товару
        public virtual Category Category { set; get; } //об'єкт, що містить всю інфу про категорію
    }
}
