using MongoDB.Bson;
using MongoDB.Driver;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class ProductController
    {
        private const string MONGO_DB_CONN_STRING = "mongodb+srv://zaid:5siggKarh7Nf0Nqg@chatapp.pc4oix7.mongodb.net/?retryWrites=true&w=majority&appName=chatApp";
        private static MongoClient mongoClient = new MongoClient(MONGO_DB_CONN_STRING);
        private static IMongoDatabase database = mongoClient.GetDatabase("ecommerce");
        private static IMongoCollection<Product> collection = database.GetCollection<Product>("products");

        public Task<List<Product>> GetAllProducts()
        {
            List<Product> products = collection.Find(new BsonDocument()).ToList();
            
            return Task.FromResult(products);
        }

        public Task<Product> GetProduct(ObjectId id)
        {
            Product product = collection.Find(new BsonDocument()).ToList().Where(p => p.Id == id).ToList()[0];

            return Task.FromResult(product);
        }

        // Method to create a product
        public Task<Product> AddProduct(Product product)
        {
            collection.InsertOne(product);

            return Task.FromResult(product);
        }

        // Method to delete a product
        public Task<DeleteResult> DeleteProduct(ObjectId id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("_id", id);
            DeleteResult result = collection.DeleteOne(filter);

            return Task.FromResult(result);
        }
    }
}
