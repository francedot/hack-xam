using System.Collections.Generic;
using System.Linq;
using EyeCare.Backend.Data;
using EyeCare.Backend.Training.Abstractions;

namespace EyeCare.Backend.Training.Data
{
    public class SqlTrainingsesData : ITrainingsData
    {
        private readonly EyeCareDbContext _context;

        public SqlTrainingsesData(EyeCareDbContext context)
        {
            _context = context;
        }

        public Models.Training Get(int id)
        {
            return _context.Trainings.FirstOrDefault(t => id == t.TrainingId);
        }

        public IQueryable<Models.Training> GetAll()
        {
            return _context.Trainings;
        }

        public void Add(Models.Training training)
        {
            _context.Trainings.Add(training);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Models.Training> training)
        {
            _context.Trainings.AddRange(training);
            _context.SaveChanges();
        }

        public void Update(Models.Training training)
        {
            _context.Trainings.AddRange(training);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Trainings.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
