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

        private readonly IGenericRepository<Genre> _genreRepo;

        private readonly IMapper _mapper;

        public LibraryController(IBookRepository bookRepo, IGenericRepository<Author> authorRepo, IGenericRepository<Genre> genreRepo, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _genreRepo = genreRepo;
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

        [HttpPost("genre")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookReadDto))]
        public async Task<IActionResult> CreateGenre([FromBody] GenreBaseDto genreDto)
        {
            var genreModel = _mapper.Map<Genre>(genreDto);
            var addedBook = await _genreRepo.AddAsync(genreModel);
            var bookReturn = _mapper.Map<GenreReadDto>(addedBook);

            return Ok(bookReturn);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(GenreReadDto))]
        public async Task<IActionResult> GetReservationByUser()
        {
            var genres = await _genreRepo.GetAsync();

            return Ok(_mapper.Map<IEnumerable<GenreReadDto>>(genres));
        }

        //[HttpGet("getActive")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[SwaggerResponse(StatusCodes.Status201Created, Type = typeof(GenreReadDto))]
        //public async Task<IActionResult> GetByParameters(string? gender, int? price)
        //{
        //    var query = $"SELECT user_name " +
        //        $"FROM user " +
        //        $"WHERE (gender IS NULL OR gender = {gender}" +
        //        $"AND (price is NULL OR price < {price})";

        //    var data = ...


        //    return Ok(_mapper.Map<IEnumerable<GenreReadDto>>(data));
        //}
    }
}