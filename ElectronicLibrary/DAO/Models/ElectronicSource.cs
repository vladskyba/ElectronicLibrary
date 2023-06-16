namespace ElectronicLibrary.DAO.Models
{
    public class ElectronicSource : BaseEntity
    {
        public string FilePath { get; set; }

        public int FileSize { get; set; }

        public string FileName { get; set; }

        public DateTime UploadDatetime { get; set; }

        public BookCopy BookCopy { get; set; }
    }
}
