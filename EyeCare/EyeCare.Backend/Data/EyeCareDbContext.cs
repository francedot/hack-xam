using EyeCare.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EyeCare.Backend.Data
{
    public class EyeCareDbContext : DbContext
    {
        public EyeCareDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Eye> Eyes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Training.Models.Training> Trainings { get; set; }
    }
}