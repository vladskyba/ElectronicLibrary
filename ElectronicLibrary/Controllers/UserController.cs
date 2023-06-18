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
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepo;

        private readonly IMapper _mapper;

        public UserController(IGenericRepository<User> userRepo, IMapper mapper) 
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        //[HttpGet("getAll")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserReadDto))]
        //public async Task<IActionResult> GetUsers()
        //{
        //    var books = await _userRepo.GetAsync();

        //    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(books));
        //}

        //[HttpPost("add")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserReadDto))]
        //public async Task<IActionResult> AddBook([FromBody] UserBaseDto userDto)
        //{
        //    var userModel = _mapper.Map<User>(userDto);
        //    var addedUser = await _userRepo.AddAsync(userModel);

        //    var userReturn = _mapper.Map<UserReadDto>(addedUser);

        //    return Ok(userReturn);
        //}
    }
}
