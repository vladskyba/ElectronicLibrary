namespace ElectronicLibrary.DataTransfer
{
    public class BookBaseDto
    {
        public string Title { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string ISBN10 { get; set; }

        public string ISBN13 { get; set; }

        public string TitleImageUrl { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<BookCopyBaseDto> Copies { get; set; }

        public PublisherReadDto Publisher { get; set; }

        public ICollection<GenreReadDto> Genres { get; set; }

        public ICollection<AuthorReadDto> Authors { get; set; }
    }
}
