using AutoMapper;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;
using Microsoft.Extensions.Options;

namespace Library.Infrastructure.Mapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        //Gender CRUD
        CreateMap<GenderCreateDto, Gender>()
            .ForMember(destination => destination.Gender1, options => options.MapFrom(src =>src.Gender));
        CreateMap<Gender, GenderResponseDto>()
            .ForMember(destination => destination.Gender, options => options.MapFrom(src =>src.Gender1));
        CreateMap<GenderUpdateDto, Gender>()
            .ForMember(destination => destination.Gender1, options => options.MapFrom(src =>src.Gender));
        CreateMap<GenderDeleteDto, Gender>();
        
        //Author CRUD
        CreateMap<AuthorCreateDto, Author>();
        CreateMap<Author, AuthorResponseDto>();
        CreateMap<AuthorUpdateDto, Author>();
        CreateMap<AuthorDeleteDto, Author>();

        //Title CRUD
        CreateMap<TitleCreateDto, Title>()
            .ForMember(destination => destination.Title1, options => options.MapFrom(src => src.Title));
        CreateMap<Title, TitleResponseDto>()
            .ForMember(destination => destination.Title, options => options.MapFrom(src => src.Title1));
        CreateMap<TitleUpdateDto, Title>()
            .ForMember(destination => destination.Title1, options => options.MapFrom(src => src.Title));
        CreateMap<TitleDeleteDto, Title>();
        
        //User CRUD
        CreateMap<UserCreateDto, User>();
        CreateMap<User, UserResponseDto>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<UserDeleteDto, User>();
        
        //Book CRUD
        CreateMap<BookCreateDto, Book>();
        CreateMap<Book, BookResponseDto>()
            .ForMember(destination => destination.Title, options => options.MapFrom(src => src.Title.Title1));
        CreateMap<BookUpdateDto, Book>();
        CreateMap<BookDeleteDto, Book>();
    }
}