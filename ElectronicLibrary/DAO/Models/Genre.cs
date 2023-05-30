namespace ElectronicLibrary.DAO.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Book Book { get; set; }

        public long BookId { get; set; }
    }
}
