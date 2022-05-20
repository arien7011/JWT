using System.Text;
using AutoMapper;
using JWTBooks.DTO;
using JWTBooks.Models;

namespace JWTBooks.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<TblBook, BookListDto>();
            CreateMap<LoginDto, TblUser>();
            CreateMap<RegisterDto, TblUser>()
           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.Unicode.GetBytes(src.Password)));
        }
    }
}