using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.netCore_MVC_.Data;
using Asp.netCore_MVC_.Models;
using Asp.netCore_MVC_.Repo;
using Asp.netCore_MVC_.ViewModel;
using AutoMapper;

namespace Asp.netCore_MVC_.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookBiz _bookBiz;

        public BooksController(IBookBiz bookBiz)
        {
            _bookBiz = bookBiz;
        }

        // GET: Books
        public IActionResult Index()
        {
            var data = _bookBiz.GetAll();
            return View(data);
        }

        //    // GET: Books/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var book = await _context.Books
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(book);
        //    }

        //    // GET: Books/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Books/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,Name,Price,CreateDate,UpdateDate,UserId,BookId")] Book book)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(book);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(book);
        //    }

        //    // GET: Books/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var book = await _context.Books.FindAsync(id);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(book);
        //    }

        //    // POST: Books/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CreateDate,UpdateDate,UserId,BookId")] Book book)
        //    {
        //        if (id != book.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(book);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!BookExists(book.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(book);
        //    }

        //    // GET: Books/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var book = await _context.Books
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(book);
        //    }

        //    // POST: Books/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var book = await _context.Books.FindAsync(id);
        //        _context.Books.Remove(book);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool BookExists(int id)
        //    {
        //        return _context.Books.Any(e => e.Id == id);
        //    }
        //}
    }
}