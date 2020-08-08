using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemCC.Models;
using projetos.Data;

namespace SystemCC.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ErrorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Errors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Error.ToListAsync());
        }

        // GET: Errors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var error = await _context.Error
                .FirstOrDefaultAsync(m => m.ID == id);
            if (error == null)
            {
                return NotFound();
            }

            return View(error);
        }

        // GET: Errors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Errors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Mensagem")] Error error)
        {
            if (ModelState.IsValid)
            {
                _context.Add(error);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(error);
        }

        // GET: Errors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var error = await _context.Error.FindAsync(id);
            if (error == null)
            {
                return NotFound();
            }
            return View(error);
        }

        // POST: Errors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Mensagem")] Error error)
        {
            if (id != error.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(error);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErrorExists(error.ID))
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
            return View(error);
        }

        // GET: Errors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var error = await _context.Error
                .FirstOrDefaultAsync(m => m.ID == id);
            if (error == null)
            {
                return NotFound();
            }

            return View(error);
        }

        // POST: Errors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var error = await _context.Error.FindAsync(id);
            _context.Error.Remove(error);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErrorExists(int id)
        {
            return _context.Error.Any(e => e.ID == id);
        }
    }
}
