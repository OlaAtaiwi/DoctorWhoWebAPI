
using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class EpisodeRepository:IEpisodeRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public async Task<Episode> CreateEpisodeAsync(Episode episode)
        {
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();
            return episode; 
        }

        public async Task DeleteEpisodeAsync(int episodeNumber, string episodeTitle)
        {
            var episode = await _context.Episodes.Where(e => e.EpisodeNumber == episodeNumber && e.Title == episodeTitle).FirstOrDefaultAsync();
            if (episode != null)
            {
                _context.Episodes.Remove(episode);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Episode>> GetEpisodesAsync()
        {
            return await _context.Episodes.ToListAsync();
        }

        public async Task UpdateEpisodeAsync(Episode episode)
        {
            _context.Episodes.Update(episode);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ViewEpisodes>> ViewEpisodesAsync()
        {
            var episodes = await _context.ViewEpisodes.ToListAsync();
            return episodes;
        }
    }
}
