using System.Collections.Generic;
using System.Linq;

namespace EyeCare.Backend.Services.Abstractions
{
    public interface ICrudOperations<T>
    {
        T Get(int id);
        IQueryable<T> GetAll();
        void Add(T element);
        void AddRange(IEnumerable<T> element);
        void Update(T eye);
        void Delete(int id);
    }
}
