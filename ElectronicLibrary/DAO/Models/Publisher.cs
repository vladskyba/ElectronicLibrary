namespace ElectronicLibrary.DAO.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public Book Book { get; set; }

        public long BookId { get; set; }
    }
}
