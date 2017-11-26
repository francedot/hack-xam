using System.Collections.Generic;
using System.Linq;
using EyeCare.Backend.Data;
using EyeCare.Backend.Models;
using EyeCare.Backend.Services.Abstractions;

namespace EyeCare.Backend.Services
{
    public class SqlEyesData : IEyesData
    {
        private readonly EyeCareDbContext _context;

        public SqlEyesData(EyeCareDbContext context)
        {
            _context = context;
        }

        public Eye Get(int id)
        {
            return _context.Eyes.FirstOrDefault(d => id == d.EyeId);
        }

        public IQueryable<Eye> GetAll()
        {
            return _context.Eyes;
        }

        public void Add(Eye eye)
        {
            _context.Eyes.Add(eye);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Eye> eyes)
        {
            _context.Eyes.AddRange(eyes);
            _context.SaveChanges();
        }

        public void Update(Eye eye)
        {
            _context.Eyes.Update(eye);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Eyes.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
