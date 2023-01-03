
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeEnemyRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodeEnemyRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public async Task AddEnemyToEpisodeAsync(int episodeId, int enemyId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);
            if (episode != null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy { EnemyId = enemyId, EpisodeId = episodeId });
               await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetEnemiesForEpisodeAsync(int id)
        {
            var enemies = await _context.Enemies.Select(e => _context.CallFnEnemies(id)).FirstOrDefaultAsync();
            return enemies;
        }
    }
}
