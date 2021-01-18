using System.Collections.Generic;
using CheeseTypeAPI.Models;
using MongoDB.Driver;

namespace CheeseTypeAPI.Service
{
    public class CheeseTypeService
    {
        private readonly IMongoCollection<CheeseType> _CheeseType;

        public CheeseTypeService(ICheeseTypeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _CheeseType = database.GetCollection<CheeseType>(settings.CheeseTypeCollectionName);
        }

        public List<CheeseType> Get() =>
            _CheeseType.Find(CheeseType => true).ToList();

        public CheeseType Get(string id) =>
            _CheeseType.Find<CheeseType>(CheeseType => CheeseType.Id == id).FirstOrDefault();

        public CheeseType Create(CheeseType CheeseType)
        {
            _CheeseType.InsertOne(CheeseType);
            return CheeseType;
        }

        public void Update(string id, CheeseType CheeseTypeIn) =>
            _CheeseType.ReplaceOne(CheeseType => CheeseType.Id == id, CheeseTypeIn);

        public void Remove(CheeseType CheeseTypeIn) =>
            _CheeseType.DeleteOne(CheeseType => CheeseType.Id == CheeseTypeIn.Id);

        public void Remove(string id) =>
            _CheeseType.DeleteOne(CheeseType => CheeseType.Id == id);
    }
}