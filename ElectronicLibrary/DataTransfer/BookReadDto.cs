using ElectronicLibrary.DAO.Models;

namespace ElectronicLibrary.DataTransfer
{
    public class BookReadDto : BookBaseDto
    {
        public long Id { get; set; }

        public IEnumerable<Discount> Discounts { get; set; }
    }
}