using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetDirectoryList(); // получение всех объектов
        T GetDirectory(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(T item); // удаление объекта по id
        bool Save();  // сохранение изменений
    }
}
