using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Interfaces;
using Aplication.Repository;
using Model;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace EasyBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository repository;
        
        public BookController()
        {
            repository = new BookRepository();
        }               

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{name}")]
        public IActionResult GetBook(string name)
        {
            Book item = repository.Get(name);
            if (item == null)
            {
                return BadRequest("запись не найдена");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult PostBook(Book item)
        {
            if (item == null)
            {
                return BadRequest(item);
            }

            bool flag = repository.Add(item);

            if (flag) return Ok();
            return BadRequest();

        }

        [HttpPut("{name}")]
        public IActionResult PutBook(string name, Book book)
        {

            book.BookName = name;
            if (!repository.Update(name, book))
            {
                return BadRequest(book);
            }
            return Ok(book);
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteBook (string name)
        {               
            if (repository.Remove(name)) return Ok();

            return BadRequest("Такой записи и не было");
        }

        [HttpDelete]
        public IActionResult DeleteAlot(List<string> names)
        {
            if (repository.RemoveALot(names)) return Ok();

            return BadRequest("Таких записей и не было либо чтото пошло не так");
        }
    }
}
