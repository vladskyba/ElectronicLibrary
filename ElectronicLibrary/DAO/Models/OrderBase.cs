namespace ElectronicLibrary.DAO.Models
{
    public class OrderBase : BaseEntity
    {
        public string Phone { get; set; }

        public string Email { get; set; }

        public long CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public long CreatedForId { get; set; }

        public User CreatedFor { get; set; }

    }
}
