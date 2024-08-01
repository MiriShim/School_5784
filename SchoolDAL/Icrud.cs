using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDAL
{
    internal interface Icrud<T>
    {
        public bool Add(T entity);
        public T Get(int id);
        public List<T> GetAll();
        public bool Update(T entity);
        public bool Delete(int id);




    }
}
