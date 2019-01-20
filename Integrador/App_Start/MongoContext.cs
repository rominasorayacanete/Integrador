using MongoDB.Driver;
using System;
using System.Configuration;

namespace MongoDemo.App_Start
{
    public class MongoContext
    {
        MongoClient _client;
        public IMongoDatabase database;
        
        public MongoContext()
        {
            var mongoClient = new MongoClient(ConfigurationManager.AppSettings["Diegobevilacqua1"]);

        }
    }
}