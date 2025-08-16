using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class Repository<T> : IRepository<T>
    {
        private List<T> _items = new List<T>();
        public void Add(T item)
        {
            _items.Add(item);
        }
        public List<T> GetAll()
        {
            return _items;
        }
        public List<T> Find(Func<T, bool> predicate)
        {
            return _items.Where(predicate).ToList();
        }
    }
}
