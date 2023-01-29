using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        private IAuthorRepository _authorRepository;
        private IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _mapper= mapper;
            _authorRepository= authorRepository;
        }

        [HttpPut("{authorId}")]
        public async Task<ActionResult> UpdateDoctor(int authorId, [FromBody] AuthorForUpdateDto author)
        {
            if (!await _authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var authorToUpdate = _mapper.Map<AuthorDto>(author);
            authorToUpdate.AuthorId = authorId; 
            var authorAfterUpdate = await _authorRepository.UpdateAuthorAsync(_mapper.Map<Author>(authorToUpdate));
            return Ok(_mapper.Map<AuthorDto>(authorAfterUpdate));
        }
    }
}
