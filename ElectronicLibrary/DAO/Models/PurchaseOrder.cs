using ElectronicLibrary.Enums;

namespace ElectronicLibrary.DAO.Models
{
    public class PurchaseOrder : OrderBase
    {
        public PurchaseStatus Status { get; set; }

        public IEnumerable<BookCopy> Books { get; set; }
    }
}
