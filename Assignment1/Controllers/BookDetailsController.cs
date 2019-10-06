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
    public class BookDetailsController : Controller
    {
        private readonly LibraryDatabaseContext _context;

        public BookDetailsController(LibraryDatabaseContext context)
        {
            _context = context;
        }

        // GET: BookDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookDetails.ToListAsync());
        }

        // GET: BookDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = await _context.BookDetails
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookDetails == null)
            {
                return NotFound();
            }

            return View(bookDetails);
        }

        // GET: BookDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,BookAuthor,PublishDate,BookStocks")] BookDetails bookDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookDetails);
        }

        // GET: BookDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = await _context.BookDetails.FindAsync(id);
            if (bookDetails == null)
            {
                return NotFound();
            }
            return View(bookDetails);
        }

        // POST: BookDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookTitle,BookAuthor,PublishDate,BookStocks")] BookDetails bookDetails)
        {
            if (id != bookDetails.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookDetailsExists(bookDetails.BookId))
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
            return View(bookDetails);
        }

        // GET: BookDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = await _context.BookDetails
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookDetails == null)
            {
                return NotFound();
            }

            return View(bookDetails);
        }

        // POST: BookDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookDetails = await _context.BookDetails.FindAsync(id);
            _context.BookDetails.Remove(bookDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookDetailsExists(int id)
        {
            return _context.BookDetails.Any(e => e.BookId == id);
        }
    }
}
