namespace ElectronicLibrary.DAO.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Biography { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
