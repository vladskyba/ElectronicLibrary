namespace ElectronicLibrary.DAO.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string ISBN10 { get; set; }

        public string ISBN13 { get; set; }

        public int PagesCount { get; set; }

        public long PublisherId { get; set; }

        public Publisher Pusblisher { get; set; }

        public ICollection<BookCopy> Copies { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
