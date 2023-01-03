using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class DoctorProfiler: Profile
    {
        public DoctorProfiler()
        {
            CreateMap<Doctor, DoctorDto>();
        }
    }
}
