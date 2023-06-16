using AutoMapper;
using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.DAO.Repositories;
using ElectronicLibrary.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElectronicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly IGenericRepository<Author> _authorRepo;

        private readonly IBookRepository _bookRepo;

        private readonly IMapper _mapper;

        public LibraryController(IBookRepository bookRepo, IGenericRepository<Author> authorRepo, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }

        [HttpPost("author")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(AuthorReadDto))]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorBaseDto authorDto)
        {
            var authorModel = _mapper.Map<Author>(authorDto);
            var addedAuthor = await _authorRepo.AddAsync(authorModel);
            
            var authorReturn = _mapper.Map<AuthorReadDto>(addedAuthor);

            return Ok(authorReturn);
        }

        [HttpPost("book")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookReadDto))]
        public async Task<IActionResult> CreateBook([FromBody] BookBaseDto bookDto)
        {
            var bookModel = _mapper.Map<Book>(bookDto);
            var addedBook = await _bookRepo.AddAsync(bookModel);

            var bookReturn = _mapper.Map<BookReadDto>(addedBook);

            return Ok(bookReturn);
        }
    }
}