using System.Collections.Generic;
using System.Linq;
using Asp.netCore_MVC_.Models;
using Asp.netCore_MVC_.ViewModel;

namespace Asp.netCore_MVC_.Biz
{
    public interface IBookBiz
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
        IEnumerable<BookViewModel> GetAll();
    }
}
