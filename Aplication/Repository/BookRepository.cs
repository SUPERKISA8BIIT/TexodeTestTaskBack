
using Aplication.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplication.Repository
{
   public class BookRepository : IBookRepository
   {
         readonly JsonLayer jsonLayer;

        public BookRepository()
        {
            jsonLayer = new JsonLayer("EasyBook.json");
        }

        public IEnumerable<Book> GetAll()
        {
            var booklist = jsonLayer.ReadFrom();
            return booklist;
        }

        public Book Get(string name)
        {
            var booklist = jsonLayer.ReadFrom();
            return booklist.Single(p => p.BookName == name);
        }

        public bool Add(Book item)
        {
            var booklist = jsonLayer.ReadFrom();

         //   item.BookName = _nextId++;
            booklist.Add(item);
            var flag = jsonLayer.WriteIn(booklist);
            return flag;
        }

        public bool Remove(string name)
        {
            var booklist = jsonLayer.ReadFrom();
            var index = booklist.FindIndex((p) => p.BookName == name);

        
            if (index == -1)
            {
                return false;
            }

            booklist.RemoveAll(p => p.BookName == name);
            var flag = jsonLayer.WriteIn(booklist);
            return flag;
        }

        public bool Update(string name, Book item)
        {
            var booklist = jsonLayer.ReadFrom();

            var index = booklist.FindIndex((p) => p.BookName == name);
            if (index == -1)
            {
                return false;
            }
            booklist.RemoveAt(index);
            booklist.Add(item);
            var flag = jsonLayer.WriteIn(booklist);
            return flag;
       
        }



        public bool RemoveALot(List<string> namelist)
        {
            var booklist = jsonLayer.ReadFrom();
            int i = 0;
            foreach(var e in booklist)
            {
                foreach(var k in namelist)
                {
                    if (e.BookName == k) i++;
                }
            }

            if (i == namelist.Count)
            {
                foreach (var e in namelist)
                {
                    booklist.RemoveAll(x => x.BookName == e);                   
                }
                var flag = jsonLayer.WriteIn(booklist);
                return true;
            }
            return false;
        }
    }
}
