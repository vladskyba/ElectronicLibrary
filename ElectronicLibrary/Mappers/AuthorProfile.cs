using AutoMapper;
using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.DataTransfer;

namespace ElectronicLibrary.Mappers
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorReadDto>()
                .ReverseMap();

            CreateMap<Author, AuthorBaseDto>()
                .ReverseMap();
        }
    }
}
