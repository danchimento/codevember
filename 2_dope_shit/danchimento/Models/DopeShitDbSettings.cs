namespace danchimento.Models
{
    public class DopeShitDbSettings : IDopeShitDbSettings
    {
        public string DopeShitCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDopeShitDbSettings
    {
        string DopeShitCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}