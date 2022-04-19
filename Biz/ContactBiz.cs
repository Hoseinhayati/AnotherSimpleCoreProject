using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netCore_MVC_.Common.Messaging;
using Asp.netCore_MVC_.Core.DataAccess;
using Asp.netCore_MVC_.Data;
using Asp.netCore_MVC_.Models;
using Asp.netCore_MVC_.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_MVC_.Biz
{
    public class ContactBiz:IContactBiz
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ContactBiz(ApplicationDbContext context,IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork= unitOfWork;
        }

        private bool IsExist(string name)
        {
            return _context.Contacts.Any(c => c.Name.Trim() == name.Trim());
        }
        private bool IsExist(int id)
        {
            return _context.Contacts.Any(c => c.Id != id);
        }


        public async Task<Result> AddAsync(Contact contact)
        {
            var result = new Result();
            if (IsExist(contact.Id))
            {
                result.AddError("خطا", "رکورد تکراری است");
                return result;
            }

            _context.Contacts.Add(contact);
            int rowEffect = await _context.SaveChangesAsync();
            _unitOfWork.Commit();
            if (rowEffect == 0)
            {
                result.AddError("خطا", "رکورد نا معتبر می باشد");

            }

            return result;
        }


        public async Task<Result> UpdateAsync(Contact contact)
        {
            var result = new Result();
     
            if (IsExist(contact.Id))
            {
                result.AddError("خطا", "رکورد تکراری است");
                return result;
            }

            _context.Contacts.Update(contact);

            int rowEffect = await _context.SaveChangesAsync();
            _unitOfWork.Commit();
            if (rowEffect == 0)
            {
                result.AddError("خطا", "رکورد نا معتبر می باشد");
            }

            return result;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var result = new Result();

            Contact contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                result.AddError("خطا", "رکورد یافت نشد");
                return result;

            }

            _context.Contacts.Remove(contact);
            int rowEffect = await _context.SaveChangesAsync();
            _unitOfWork.Commit();
            if (rowEffect == 0)
            {
                result.AddError("خطا", "رکورد نا معتبر می باشد");
            }

            return result;
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await _unitOfWork.Repository<Contact>().Get().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            IQueryable<Contact> contactQuery = _context.Contacts.AsNoTracking().AsQueryable();
            return await contactQuery.Select(c => new Contact
            {
                Id = c.Id,
                Address = c.Address,
                Email = c.Email,
                Name = c.Name
            }).ToListAsync();
        }
    }
}
