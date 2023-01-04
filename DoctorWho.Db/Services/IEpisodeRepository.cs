
namespace DoctorWho.Db
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetEpisodesAsync();
        Task<Episode> CreateEpisodeAsync(Episode episode);
        Task<bool> AddEnemyToEpisodeAsync(int episodeId, int enemyId);
        Task<bool> AddCompanionToEpisodeAsync(int episodeId, int companionId);
    }
}
