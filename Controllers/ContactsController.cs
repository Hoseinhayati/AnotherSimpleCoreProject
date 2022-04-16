using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netCore_MVC_.Biz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asp.netCore_MVC_.Data;
using Asp.netCore_MVC_.Models;

namespace Asp.netCore_MVC_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactBiz _contactBiz;

        public ContactsController(IContactBiz contactBiz)
        {
            _contactBiz = contactBiz;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _contactBiz.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactBiz.GetAsync(id);
            if (contact == null)
            {
                return Ok("آیتم یافت نشد");
            }

            return contact;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(Contact contact)
        {
            var result = await _contactBiz.UpdateAsync(contact);
            if (!result.Success)
            {
               return Ok(result.Errors.Select(a => a.Message).ToList());
            }
            else
            {
                return Ok("رکورد ویرایش شد");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            var result = await _contactBiz.AddAsync(contact);
            if (!result.Success)
            {
                return Ok(result.Errors.Select(a => a.Message).ToList());
            }
            else
            {
                return Ok("رکورد با موفقیت اضافه شد");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactBiz.DeleteAsync(id);
            if (!result.Success)
            {
                return Ok(result.Errors.Select(a => a.Message).ToList());
            }
            else
            {
                return Ok("رکورد حذف شد");
            }
        }
    }
}
