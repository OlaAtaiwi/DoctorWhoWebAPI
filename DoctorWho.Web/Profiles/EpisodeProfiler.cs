using AutoMapper;
using DoctorWho.Web.Models;
using DoctorWho.Db;
namespace DoctorWho.Web.Profiles
{
    public class EpisodeProfiler :Profile
    {
        public EpisodeProfiler()
        {
            CreateMap<Episode, EpisodeDto>();
            CreateMap<EpisodeDto, Episode>();
        }
    }
}
