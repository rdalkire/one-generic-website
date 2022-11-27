using StarterApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarterApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace StarterApp.Controllers
{
    [Authorize]
    public class HomeTextController : Controller
    {
        private readonly SomeDbContext _context;

        public HomeTextController(SomeDbContext context)
        {
            _context = context;
        }

        // GET: HomeText
        public async Task<IActionResult> Index()
        {
              return _context.HomeText != null ? 
                          View(await _context.HomeText.ToListAsync()) :
                          Problem(
                            "Entity set 'SomeDbContext.HomeText' is null.");
        }

        // GET: HomeText/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HomeText == null)
            {
                return NotFound();
            }

            var homeText = await _context.HomeText
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeText == null)
            {
                return NotFound();
            }

            return View(homeText);
        }

        // GET: HomeText/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeText/Create
        // To protect from overposting attacks, enable the specific properties 
        // you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Value")] HomeText homeText)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(homeText);

                try
                { 
                    await _context.SaveChangesAsync();
                }catch( DbUpdateException )
                {
                    // If there's already a HomeText record for this, edit the
                    // existing one instead
                    _context.Remove(homeText);

                    var newText = homeText.Value;

                    homeText = await _context.HomeText.Where( 
                        h => h.Name == homeText.Name ).FirstAsync();

                    homeText.Value = newText;

                    _context.Update(homeText);
                    await _context.SaveChangesAsync();

                }

                return RedirectToAction(nameof(Index));
            }
            return View(homeText);
        }

        // GET: HomeText/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HomeText == null)
            {
                return NotFound();
            }

            var homeText = await _context.HomeText.FindAsync(id);
            if (homeText == null)
            {
                return NotFound();
            }
            return View(homeText);
        }

        // POST: HomeText/Edit/5
        // To protect from overposting attacks, enable the specific properties 
        // you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id,Name,Value")] HomeText homeText)
        {
            if (id != homeText.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {   
                try
                {
                    _context.Update(homeText);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeTextExists(homeText.Id))
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
            return View(homeText);
        }

        // GET: HomeText/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HomeText == null)
            {
                return NotFound();
            }

            var homeText = await _context.HomeText
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeText == null)
            {
                return NotFound();
            }

            return View(homeText);
        }

        // POST: HomeText/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HomeText == null)
            {
                return Problem(
                    "Entity set 'SomeDbContext.HomeText' is null.");
            }
            var homeText = await _context.HomeText.FindAsync(id);
            if (homeText != null)
            {
                _context.HomeText.Remove(homeText);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeTextExists(int id)
        {
          return (_context.HomeText?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
