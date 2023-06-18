namespace ElectronicLibrary.DataTransfer
{
    public class BookCopyReadDto : BookCopyBaseDto
    {
        public IEnumerable<BookCopyReadDto> Copies { get; set; }

        public long BookId { get; set; } 
    }
}
