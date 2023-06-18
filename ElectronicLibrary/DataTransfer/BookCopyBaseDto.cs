using ElectronicLibrary.Enums;

namespace ElectronicLibrary.DataTransfer
{
    public class BookCopyBaseDto
    {
        public BookType Type { get; set; }

        public decimal Price { get; set; }

        //public long BookId { get; set; }

        //public ElectronicSource Source { get; set; }

        //public long? SourceId { get; set; }

        public PhysicalCondition Condition { get; set; }
    }
}
