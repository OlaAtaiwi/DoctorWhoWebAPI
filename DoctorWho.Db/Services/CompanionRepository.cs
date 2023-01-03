
namespace DoctorWho.Db
{
    public class CompanionRepository
    {
        private DoctorWhoCoreDbContext _context;
        public CompanionRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateCompanionAsync(string companionName, string whoPlayed)
        {
            if (!string.IsNullOrEmpty(companionName))
            {
                var companion = new Companion { CompanionName = companionName, WhoPlayed = whoPlayed };
                _context.Companions.Add(companion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCompanionAsync(string companionName)
        {
            var companion =_context.Companions.Where(c => c.CompanionName == companionName).FirstOrDefault();
            if (companion != null)
            {
                _context.Companions.Remove(companion);
                await _context.SaveChangesAsync();
                Console.WriteLine("Companion Deleted");
            }
        }

        public async Task UpdateCompanionAsync(Companion companion)
        {
            _context.Companions.Update(companion);
            await _context.SaveChangesAsync();
        }

        async Task<Companion> GetCompanionByIdAsync(int id)
        {
            var companion =await  _context.Companions.FindAsync(id);
            if (companion != null)
            {
                return companion;
            }
            throw new NullReferenceException("No companions with the provided Id !");
        }
    }
}
