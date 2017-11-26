using System.Collections.Generic;
using System.Linq;
using EyeCare.Backend.Data;
using EyeCare.Backend.Models;
using EyeCare.Backend.Services.Abstractions;

namespace EyeCare.Backend.Services
{
    public class SqlPatientsData : IPatientsData
    {
        private readonly EyeCareDbContext _context;

        public SqlPatientsData(EyeCareDbContext context)
        {
            _context = context;
        }

        public Patient Get(int id)
        {
            return _context.Patients.FirstOrDefault(d => id == d.PatientId);
        }

        public IQueryable<Patient> GetAll()
        {
            return _context.Patients.OrderBy(p => p.Diagnoses.FirstOrDefault().Date);
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Patient> patient)
        {
            _context.Patients.AddRange(patient);
            _context.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Patients.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
