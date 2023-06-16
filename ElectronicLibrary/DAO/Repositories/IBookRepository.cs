using ElectronicLibrary.DAO.Models;

namespace ElectronicLibrary.DAO.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetBookById(long id);
    }
}
