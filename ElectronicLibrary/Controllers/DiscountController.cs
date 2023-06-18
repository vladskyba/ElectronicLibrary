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
    public class DiscountController : ControllerBase
    {
        private readonly IGenericRepository<Discount> _discountRepo;

        private readonly IMapper _mapper;

        public DiscountController(IGenericRepository<Discount> discountRepo, IMapper mapper)
        {
            _discountRepo = discountRepo;
            _mapper = mapper;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(DiscountReadDto))]
        public async Task<IActionResult> AddBook([FromBody] DiscountBaseDto discountDto)
        {
            var discountModel = _mapper.Map<Discount>(discountDto);

            discountModel.Books = new List<Book>() { new Book { Id = discountDto.BookId } };
            var existingDiscount = await _discountRepo.GetAsync(q=> q.UserId == discountDto.UserId);

            if (existingDiscount.Any())
            {
                return BadRequest("Скидка на даний проміжок часу на цю книгу вже існує!");
            }

            var addedDiscount = await _discountRepo.AddAsync(discountModel);
            var discountReturn = _mapper.Map<BookReadDto>(addedDiscount);

            return Ok(discountReturn);
        }

    }
}
