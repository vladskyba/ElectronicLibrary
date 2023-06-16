using ElectronicLibrary.Enums;

namespace ElectronicLibrary.DAO.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Bithday { get; set; }

        public string Phone { get; set; }

        public UserRole Role { get; set; } 

        public IEnumerable<TakingOrder> UserTakings { get; set; }

        public IEnumerable<PurchaseOrder> UserPurchases { get; set; }

        public IEnumerable<TakingOrder> CreatedTakings { get; set; }

        public IEnumerable<PurchaseOrder> CreatedPurchases { get; set; }

        public IEnumerable<Discount> Discounts { get; set; }
    }
}
