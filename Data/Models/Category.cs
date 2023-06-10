using System.Collections.Generic;
namespace ToyMarket.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string desc { set; get; }
        public List <Toy> toys { set; get; }//список товарів в категорії

    }
}
