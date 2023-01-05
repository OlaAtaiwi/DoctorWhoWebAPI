
namespace DoctorWho.Db
{
    public interface IAuthorRepository
    {
        Task<Author> UpdateAuthorAsync(Author auth);
        Task<bool> AuthorExists(int authorId);
    }
}
