using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db;
using System.Text.Json;
using AutoMapper;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : Controller
    {
        private IDoctorRepository _doctorRepository;
        private IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository,IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors=await _doctorRepository.GetAllDoctorsAsync();

            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctors));
        }

        [HttpDelete("/{doctorId}")]
        public async Task<ActionResult> DeleteDoctor(int doctorId)
        {
            if(!await _doctorRepository.DoctorExists(doctorId)) 
            {
                return NotFound();
            }
            await _doctorRepository.DeleteDoctorAsync(doctorId);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor([FromBody]DoctorForCreationDto doctor)
        {
            var addedDocrtor=await _doctorRepository.CreateDoctorAsync(_mapper.Map<Doctor>(doctor));
            return Ok(_mapper.Map<DoctorDto>(addedDocrtor));
        }

        [HttpPut("{doctorId}")]
        public async Task<ActionResult> UpdateDoctor(int doctorId,[FromBody] DoctorForCreationDto doctor)
        {
            if(! await _doctorRepository.DoctorExists(doctorId))
            {
                return NotFound();
            }
            var doctorToUpdate=_mapper.Map<DoctorDto>(doctor);
            doctorToUpdate.DoctorId= doctorId;
            var doctorAfterUpdate = await _doctorRepository.UpdateDoctorAsync(_mapper.Map<Doctor>(doctorToUpdate));
            return Ok(_mapper.Map<DoctorDto>(doctorAfterUpdate));
        }
    } 
}

