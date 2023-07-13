using AutoMapper;
using Library.Infrastructure.Models;
using Library.Infrastructure.Dtos.Gender;
using Library.Infrastructure.Dtos.Author;

namespace Library.Infrastructure.Mapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        /// Gender CRUD
        CreateMap<GenderCreateDto, Gender>()
            .ForMember(dest => dest.Gender1, opt => opt.MapFrom(src =>src.Gender));
        CreateMap<Gender, GenderResponseDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src =>src.Gender1));
        CreateMap<GenderUpdateDto, Gender>()
            .ForMember(dest => dest.Gender1, opt => opt.MapFrom(src =>src.Gender));
        CreateMap<GenderDeleteDto, Gender>();
        
        /// Author CRUD
        CreateMap<AuthorCreateDto, Author>();
        CreateMap<Author, AuthorResponseDto>();
        CreateMap<AuthorUpdateDto, Author>();
        CreateMap<AuthorDeleteDto, Author>();

    }
}