namespace ElectronicLibrary.DataTransfer
{
    public class DiscountBaseDto
    {
        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public byte Percent { get; set; }

        public long UserId { get; set; }

        public long BookId { get; set; }
    }
}
