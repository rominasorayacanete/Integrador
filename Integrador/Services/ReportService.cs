using System.Collections.Generic;
using Newtonsoft.Json;
using Integrador.DAL;
using Integrador.Models;
using Integrador.Models.Clases;
using System.Linq;
using System;
using MongoDemo.App_Start;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Integrador.Services
{
    public class ReportService
    {
        private MongoContext mongo = new MongoContext();

        public Report ExistReport(string searchName, int periodo)
        {
            var collection = mongo.database.GetCollection<Report>("foo");
            var filterBuilder = Builders<Report>.Filter;
            var filter = filterBuilder.Eq(r => r.SearchName, searchName);

            var document = collection.Find(filter).SingleOrDefault();
            if (document != null)
            {
                return document;
            }
            return null;
        }


        public void SaveReport(string searchName, string displayName, int periodo, double value)
        {
            var collection = mongo.database.GetCollection<Report>("foo");
            Report newReport = new Report(searchName, displayName, periodo, value);
            collection.InsertOne(newReport);
            return;
        }

    }
}