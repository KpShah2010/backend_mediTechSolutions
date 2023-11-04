using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class DoctorRepository : IDoctor
    {
        private readonly ApplicatinDbContext dbContext; 

        public DoctorRepository(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            await dbContext.Doctors.AddAsync(doctor);
            await dbContext.SaveChangesAsync();

            return doctor;
        }

        public async Task<List<Doctor>> GetAllDoctorAsync()
        {
            return await dbContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var existingId = await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }

        public async Task<List<Doctor>> GetDoctorByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var doctors = await dbContext.Doctors
                .Where(d => d.DoctorName.Contains(name))
                .ToListAsync();

            if (doctors == null || doctors.Count == 0)
            {
                return null;
            }
            return doctors;
        }
    }
}
