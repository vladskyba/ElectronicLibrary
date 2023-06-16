using ElectronicLibrary.Enums;

namespace ElectronicLibrary.DAO.Models
{
    public class BookCopy : BaseEntity
    {
        public BookType Type { get; set; }

        public string Number { get; set; }

        public string QRContent { get; set; }

        public Book Book { get; set; }

        public long BookId { get; set; }

        public ElectronicSource Source { get; set; }

        public long? SourceId { get; set; }

        public PhysicalCondition Condition { get; set; }

        public IEnumerable<TakingOrder> Takings { get;}

        public IEnumerable<PurchaseOrder> Purchases { get; }
    }
}
