namespace ElectronicLibrary.DAO.Models
{
    public class ElectronicSource : BaseEntity
    {
        public string Path { get; set; }

        public int Size { get; set; }

        public DateTime UploadDatetime { get; set; }
    }
}
