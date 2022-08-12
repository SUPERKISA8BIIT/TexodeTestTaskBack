using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
   public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(string name);
        bool Add(Book item);
        bool Remove(string name);
        bool Update(string name, Book item);
        bool RemoveALot(List<string> idlist);
        

    }
}
