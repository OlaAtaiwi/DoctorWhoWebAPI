using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetEpisodesAsync();
        Task<Episode> CreateEpisodeAsync(Episode episode);
        Task<bool> AddEnemyToEpisodeAsync(int episodeId, int enemyId);
    }
}
