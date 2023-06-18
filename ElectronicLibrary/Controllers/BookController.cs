using AutoMapper;
using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.DAO.Repositories;
using ElectronicLibrary.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography.X509Certificates;

namespace ElectronicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepo, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepo = bookRepo;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookReadDto))]
        public async Task<IActionResult> AddBook([FromBody] BookBaseDto bookDto)
        {
            var bookModel = _mapper.Map<Book>(bookDto);
            var addedBook = await _bookRepo.AddAsync(bookModel);

            var bookReturn = _mapper.Map<BookReadDto>(addedBook);

            return Ok(bookReturn);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookReadDto))]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepo.GetAsync(null,
                i=> i.Include(g => g.Genres)
                     .Include(a => a.Authors)
                     .Include(p => p.Publisher)
                     .Include(p => p.Copies)
                );

            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
        }

        [HttpGet("getById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookReadDto))]
        public async Task<IActionResult> GetById(long bookId)
        {
            var books = await _bookRepo.GetAsync(q => q.Id == bookId,
                i => i.Include(g => g.Genres)
                     .Include(a => a.Authors)
                     .Include(p => p.Publisher)
                     .Include(b => b.Copies)
                );

            return Ok(_mapper.Map<BookReadDto>(books.FirstOrDefault()));
        }
    }
}
