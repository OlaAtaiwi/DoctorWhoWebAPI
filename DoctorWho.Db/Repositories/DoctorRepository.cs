
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository
    {
        private DoctorWhoCoreDbContext _context;
        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateDoctorAsync(string doctorName, int doctorNumber)
        {
            if (!string.IsNullOrEmpty(doctorName))
            {
                var doctor = new Doctor { DoctorName = doctorName, DoctorNumber = doctorNumber };
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDoctorAsync(string doctorName)
        {
            if (!string.IsNullOrEmpty(doctorName))
            {
                var doctor =_context.Doctors.Where(d => d.DoctorName == doctorName).FirstOrDefault();
                if (doctor != null)
                {
                    _context.Doctors.Remove(doctor);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync(); 
        }
    }
}
