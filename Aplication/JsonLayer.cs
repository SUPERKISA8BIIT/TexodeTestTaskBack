using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Model;

namespace Aplication
{
    public class JsonLayer
    {
        string path;

       
        public JsonLayer(string path)
        {
            this.path = path;
        }

      
        public List<Book> ReadFrom()
        {
            if (File.Exists(path))
            {
                List<Book> item = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(path));
                return item;                
            }
            return new List<Book>();

          
        }
        public bool WriteIn(List<Book> books)
        {            
            string item = JsonSerializer.Serialize(books);
            File.WriteAllText(path, item);
            return true;
        }
    }
}
