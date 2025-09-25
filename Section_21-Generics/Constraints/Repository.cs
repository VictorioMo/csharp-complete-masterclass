using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constraints
{
    internal interface IEntity
    {
        public int Id { get; }
    }

    // Generic type with type constraint where it forces
    // the type T to implement the interface IEntity
    internal class Repository<T> where T : IEntity
    {
        private List<T> values = new List<T>();

        public void Add(T entity)
        {
            values.Add(entity);
        }
    }
}
