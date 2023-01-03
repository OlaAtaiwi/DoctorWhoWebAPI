using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorRepository:IDoctorRepository
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

        public async Task DeleteDoctorAsync(int doctorId)
        {
            var doctor = _context.Doctors.Where(d => d.DoctorId == doctorId).FirstOrDefault();
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
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

        public async Task<bool> DoctorExists(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            if(doctor!=null)
                return true;
           return false;   
        }
    }
}
