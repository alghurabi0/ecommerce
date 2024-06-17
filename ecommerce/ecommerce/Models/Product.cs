using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ecommerce.Models
{
    public class Product
    {
        public Product(string title, string description, int price, string img)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.Img = img;
        }
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
    }
}
