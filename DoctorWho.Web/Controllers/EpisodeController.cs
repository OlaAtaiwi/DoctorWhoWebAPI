using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db;
using DoctorWho.Web.Models;
using AutoMapper;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodeController : Controller
    {
        private IEpisodeRepository _episodeRepository;
        private IMapper _mapper;

        public EpisodeController(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetEpisodes()
        {
            var episodes= await _episodeRepository.GetEpisodesAsync();
            return Ok(_mapper.Map<IEnumerable<EpisodeDto>>(episodes));
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor([FromBody] EpisodeDto episode)
        {
            var addedEpisode = await _episodeRepository.CreateEpisodeAsync(_mapper.Map<Episode>(episode));
            return Ok(_mapper.Map<EpisodeDto>(addedEpisode));
        }

        [HttpPost("/{episodeId}/enemy/{enemyId}")]
        public async Task<ActionResult> AddEnemyToEpisode(int episodeId,int enemyId)
        {
            var result=await _episodeRepository.AddEnemyToEpisodeAsync(episodeId,enemyId);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

    }
}
