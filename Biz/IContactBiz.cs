using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netCore_MVC_.Common.Messaging;
using Asp.netCore_MVC_.Models;
using Asp.netCore_MVC_.ViewModel;

namespace Asp.netCore_MVC_.Biz
{
    public interface IContactBiz
    {
        Task<Result> AddAsync(Contact contact);
        Task<Result> UpdateAsync(Contact contact);
        Task<Result> DeleteAsync(int id);
        Task<Contact> GetAsync(int id);
        Task<List<Contact>> GetAllAsync();
    }
}
