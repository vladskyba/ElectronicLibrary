namespace ElectronicLibrary.DAO.Models
{
    public class Discount : BaseEntity
    {
        public bool IsSent { get; set; }

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public DateTime? SentDatetime { get; set; }

        public string EmailContent { get; set; }

        public byte Percent { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public User User { get; set; }

        public long UserId { get; set; }
    }
}
