using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class BooksBorrowedsController : Controller
    {
        private readonly LibraryDatabaseContext _context;

        public BooksBorrowedsController(LibraryDatabaseContext context)
        {
            _context = context;
        }

        // GET: BooksBorroweds
        public async Task<IActionResult> Index()
        {
            return View(await _context.BooksBorrowed.ToListAsync());
        }

        // GET: BooksBorroweds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksBorrowed = await _context.BooksBorrowed
                .FirstOrDefaultAsync(m => m.BorrowedId == id);
            if (booksBorrowed == null)
            {
                return NotFound();
            }

            return View(booksBorrowed);
        }

        // GET: BooksBorroweds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BooksBorroweds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowedId,BookId,MemberId,BookTitle,MemberFname,MemberLname,DateBorrowed,ReturnDate")] BooksBorrowed booksBorrowed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booksBorrowed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booksBorrowed);
        }

        // GET: BooksBorroweds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksBorrowed = await _context.BooksBorrowed.FindAsync(id);
            if (booksBorrowed == null)
            {
                return NotFound();
            }
            return View(booksBorrowed);
        }

        // POST: BooksBorroweds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowedId,BookId,MemberId,BookTitle,MemberFname,MemberLname,DateBorrowed,ReturnDate")] BooksBorrowed booksBorrowed)
        {
            if (id != booksBorrowed.BorrowedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booksBorrowed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksBorrowedExists(booksBorrowed.BorrowedId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booksBorrowed);
        }

        // GET: BooksBorroweds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksBorrowed = await _context.BooksBorrowed
                .FirstOrDefaultAsync(m => m.BorrowedId == id);
            if (booksBorrowed == null)
            {
                return NotFound();
            }

            return View(booksBorrowed);
        }

        // POST: BooksBorroweds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booksBorrowed = await _context.BooksBorrowed.FindAsync(id);
            _context.BooksBorrowed.Remove(booksBorrowed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksBorrowedExists(int id)
        {
            return _context.BooksBorrowed.Any(e => e.BorrowedId == id);
        }
    }
}
