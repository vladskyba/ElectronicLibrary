namespace ElectronicLibrary.DataTransfer
{
    public class DiscountReadDto
    {
        public long Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public byte Percent { get; set; }

        public long UserId { get; set; }
    }
}
