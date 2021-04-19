using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D2_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly BookContext _bookContext;
        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public Author Add(Author author)
        {
            _bookContext.Authors.Add(author);
            _bookContext.SaveChanges();
            return author;

        }

        public Author Get(int id)
        {
            return _bookContext.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors.ToList();
        }

        public void Remove(Author author)
        {
            _bookContext.Remove(author);
            _bookContext.SaveChanges();
        }

        public Author Update(Author author)
        {
            var curremtAuthor = Get(author.Id);

            if(curremtAuthor == null)
            {
                return null;
            }

            _bookContext.Entry(curremtAuthor)
                .CurrentValues
                .SetValues(author);

            _bookContext.Update(curremtAuthor);
            _bookContext.SaveChanges();

            return curremtAuthor;
        }
    }
}
