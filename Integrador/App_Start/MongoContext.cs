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
            _client = new MongoClient("mongodb+srv://gentlemen:gentlemen@gentlemen-mqayu.azure.mongodb.net/test?retryWrites=true");
            database = _client.GetDatabase("foo");
        }
    }
}