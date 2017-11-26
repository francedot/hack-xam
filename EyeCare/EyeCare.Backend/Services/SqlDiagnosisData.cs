using System.Collections.Generic;
using System.Linq;
using EyeCare.Backend.Data;
using EyeCare.Backend.Models;
using EyeCare.Backend.Services.Abstractions;

namespace EyeCare.Backend.Services
{
    public class SqlDiagnosisData : IDiagnosisData
    {
        private readonly EyeCareDbContext _context;

        public SqlDiagnosisData(EyeCareDbContext context)
        {
            _context = context;
        }

        public Diagnosis Get(int id)
        {
            return _context.Diagnoses.FirstOrDefault(d => id == d.DiagnosisId);
        }

        public IQueryable<Diagnosis> GetAll()
        {
            return _context.Diagnoses.OrderBy(d => d.Date);
        }

        public void Add(Diagnosis diagnosis)
        {
            _context.Diagnoses.Add(diagnosis);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Diagnosis> diagnosis)
        {
            _context.Diagnoses.AddRange(diagnosis);
            _context.SaveChanges();
        }

        public void Update(Diagnosis eye)
        {
            _context.Diagnoses.Update(eye);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Diagnoses.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
