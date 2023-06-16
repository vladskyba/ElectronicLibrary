using AutoMapper;
using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.DataTransfer;

namespace ElectronicLibrary.Mappers
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherBaseDto>()
                .ReverseMap();

            CreateMap<Publisher, PublisherReadDto>()
                .ReverseMap();
        }
    }
}
