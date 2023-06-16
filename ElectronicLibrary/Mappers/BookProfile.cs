using AutoMapper;
using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.DataTransfer;

namespace ElectronicLibrary.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<Book, BookBaseDto>()
                .ReverseMap();

            CreateMap<Book, BookReadDto>()
                .ReverseMap();
        }
    }
}
