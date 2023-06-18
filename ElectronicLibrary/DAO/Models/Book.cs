namespace ElectronicLibrary.DAO.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string ISBN10 { get; set; }

        public string ISBN13 { get; set; }

        public string TitleImageUrl { get; set; }

        public int PagesCount { get; set; }

        public int PaperCount { get; set; } = 0;

        public int ElectronicCount { get; set; } = 0;

        public long PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public IEnumerable<BookCopy> Copies { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Author> Authors { get; set; }

        public IEnumerable<Discount> Discounts { get; set; }
    }
}
