using ElectronicLibrary.DAO.Context;
using ElectronicLibrary.DAO.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ElectronicLibrary.DAO.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }

        public override async Task<Book> AddAsync(Book entity)
        {
            foreach (var genre in entity.Genres)
            {
                if (genre.Id != 0)
                {
                    _context.Entry(genre).State = EntityState.Unchanged;
                }
            }

            if (entity.Publisher.Id != 0)
            {
                _context.Entry(entity.Publisher).State = EntityState.Unchanged;
            }

            foreach (var author in entity.Authors)
            {
                if (author.Id != 0)
                {
                    _context.Entry(author).State = EntityState.Unchanged;
                }
            }

            await _context.Set<Book>().AddAsync(entity);

            int addedRows = await _context.SaveChangesAsync();

            if (addedRows > 0)
            {
                return entity;
            }

            return null;
        }

        public IEnumerable<Book> GetBookById(long id)
        {
            return _context.Books.Where(x => x.Id == id)
                .Include(i => i.Genres)
                .Include(i => i.Authors)
                .Include(i => i.Copies)
                .Include(i => i.Publisher)
                .ToList();
        }
    }
}
