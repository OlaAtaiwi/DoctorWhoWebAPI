
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DoctorWho.Db
{
    public class AuthorRepository:IAuthorRepository
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
        public async Task<Author> UpdateAuthorAsync(Author auth)
        {
           var original = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId== auth.AuthorId);
            _context.Entry(original).CurrentValues.SetValues(auth);
            await _context.SaveChangesAsync();
            return auth;
        }
        public async Task<bool> AuthorExists(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author != null)
                return true;
            return false;
        }
    }
}
