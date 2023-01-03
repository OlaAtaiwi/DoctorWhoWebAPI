
namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository
    {
        private DoctorWhoCoreDbContext _context;
        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
                _context=context;
        }
        public async Task CreateAuthorAsync(string authorName)
        {
            if (!string.IsNullOrEmpty(authorName))
            {
                var author = new Author { AuthorName = authorName };
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAuthorAsync(string authorName)
        {
            if (!string.IsNullOrEmpty(authorName))
            {
                var author =_context.Authors.Where(a => a.AuthorName == authorName).FirstOrDefault();
                if (author != null)
                {
                    _context.Authors.Remove(author);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task UpdateAuthorAsync(Author auth)
        {
           _context.Authors.Update(auth);
            await _context.SaveChangesAsync();
        }
    }
}
