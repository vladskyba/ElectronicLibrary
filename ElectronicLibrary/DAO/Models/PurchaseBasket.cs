namespace ElectronicLibrary.DAO.Models
{
    public class PurchaseBasket
    {
        public long PurchaseId { get; set; }

        public long BookCopyId { get; set; }

        public decimal Price { get; set; }
    }
}
