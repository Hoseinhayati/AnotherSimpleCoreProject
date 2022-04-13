using System.Collections.Generic;
using System.Linq;
using Asp.netCore_MVC_.Data;
using Asp.netCore_MVC_.Models;
using Asp.netCore_MVC_.ViewModel;
using AutoMapper;

namespace Asp.netCore_MVC_.Biz
{
    public class BookBiz:IBookBiz
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BookBiz(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            List<Book> data = _context.Books.ToList();
            IEnumerable<BookViewModel> result = _mapper.Map<IEnumerable<BookViewModel>>(data);
            return result;
        }
    }
}
