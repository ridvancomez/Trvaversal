using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> List();
        void Remove(T item);
        void Add(T entity);
        void Update(T entity);
        T GetById(int id);

    }
}
