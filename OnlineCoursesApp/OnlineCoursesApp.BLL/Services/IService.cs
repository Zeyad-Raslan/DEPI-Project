using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.BLL.Services
{
    public interface IService<T> where T : class
    {
        IQueryable<T> Query();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}


