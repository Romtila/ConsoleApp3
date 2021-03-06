﻿using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    public class BaseRepository<T> where T : IHasId
    {
        private IMongoCollection<T> collection;

        public BaseRepository()
        {
            var db = new MongoClient("mongodb://localhost:27017");

            var edb = db.GetDatabase("exampledb");

            collection = edb.GetCollection<T>(nameof(T));
        }

        public void Create(T user)
        {
            collection.InsertOne(user);
        }
        public T Get(ObjectId id)
        {
            var cursor = collection.FindSync(x => x.Id == id);
            return cursor.FirstOrDefault();
        }

        public void Update(T user)
        {
            collection.ReplaceOne(x => x.Id == user.Id, user);
        }

        public List<T> GetMany()
        {
            //var query = collection.AsQueryable().Where(x => x.Tname == "login");

            //return query.ToList();

            return collection.FindSync(Builders<T>.Filter.Empty).ToList();

            //return collection.FindSync(x => true).ToList();
        }
    }
}
