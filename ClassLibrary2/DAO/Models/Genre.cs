namespace ElectronicLibrary.DAO.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
