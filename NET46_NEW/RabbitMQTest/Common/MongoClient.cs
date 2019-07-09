using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MongoBase
    {
        private MongoClient _client;
        private IMongoDatabase _dataBase;
        public MongoBase()
        {
            _client = new MongoClient("mongodb://192.168.1.211:27017");
            _dataBase = _client.GetDatabase("SMS201907");
            var connection = _dataBase.GetCollection<BsonDocument>("SMSlog");
        }

        public IMongoCollection<SMSlog> GetConnection()
        {
            return _dataBase.GetCollection<SMSlog>("SMSlog");
        }
        
    }



    public class SMSlog
    {        
        public string Num { get; set; }
        public int TD { get; set; }
        public int SH { get; set; }
        public string SJ { get; set; }
        public string NR { get; set; }
        public string Time { get; set; }

        //public async Task WriteToMongoAsync(IMongoCollection<BsonDocument> connection)
        //{
        //    var document = new BsonDocument
        //    {
        //        { "ID",Id},
        //        { "TD",TD},
        //        { "SH",SH},
        //        { "SJ",SJ},
        //        { "NR",NR},
        //        { "Time",Time}
        //    };

        //    await connection.InsertOneAsync(document, null, new System.Threading.CancellationToken());
        //}

        //public void WriteToMongo(IMongoCollection<BsonDocument> connection)
        //{
        //    var document = new BsonDocument
        //    {
        //        { "ID",Id},
        //        { "TD",TD},
        //        { "SH",SH},
        //        { "SJ",SJ},
        //        { "NR",NR},
        //        { "Time",Time}
        //    };

        //    connection.InsertOne(document, null, new System.Threading.CancellationToken());
        //}
    }
}
