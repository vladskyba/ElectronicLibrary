using ElectronicLibrary.Enums;

namespace ElectronicLibrary.DAO.Models
{
    public class TakingOrder : OrderBase
    {
        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public TakingStatus Status { get; set; }

        public IEnumerable<BookCopy> Books { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
