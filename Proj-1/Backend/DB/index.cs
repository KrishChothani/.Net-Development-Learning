using MongoDB.Driver;

namespace Backend.DB
{
    public class index
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _database;
        public MongoDBService(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectingString = _configuration.GetConnectionString("DbConnection");
            var mongoUrl = mongoUrl.create("mongodb+srv://Krish:Krish_259@cluster0.kti4z.mongodb.net");
            var MongoClient = new MongoClient(mongoUrl);
            _database = MongoClient.GetDatabase(mongoUrl.DB_NAME);
        }

        public IMongoDatabase? DataBase => _database; 
    }
}