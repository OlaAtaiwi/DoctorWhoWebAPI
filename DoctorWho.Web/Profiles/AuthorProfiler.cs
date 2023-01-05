using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class AuthorProfiler:Profile
    {
        public AuthorProfiler()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<AuthorForUpdateDto, AuthorDto>();
        }
    }
}
