namespace CheeseTypeAPI.Models
{
    public class CheeseTypeDatabaseSettings : ICheeseTypeDatabaseSettings
    {
        public string CheeseTypeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICheeseTypeDatabaseSettings
    {
        string CheeseTypeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}