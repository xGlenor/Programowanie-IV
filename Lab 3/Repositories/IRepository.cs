using Lab_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Repositories
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        void Create(T t);
        void Edit(T t);

        void Delete(int id);
    }
}
