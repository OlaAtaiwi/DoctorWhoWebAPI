
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class EpisodeRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateEpisodeAsync(Episode episode)
        {
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();
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
