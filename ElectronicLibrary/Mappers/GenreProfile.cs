using AutoMapper;
using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.DataTransfer;

namespace ElectronicLibrary.Mappers
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreBaseDto>()
                .ReverseMap();

            CreateMap<Genre, GenreReadDto>()
                .ReverseMap();
        }
    }
}
