
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeCompanionRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodeCompanionRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanionToEpisodeAsync(int episodeId, int companionId)
        {
            var episode =await _context.Episodes.FindAsync(episodeId);
            if (episode != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { CompanionId = companionId, EpisodeId = episodeId });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetCompanionsForEpisodeAsync(int id)
        {
            var companions = await _context.Companions.Select(c => _context.CallFnCompanions(id)).FirstOrDefaultAsync();
            return companions;
        }
    }
}
