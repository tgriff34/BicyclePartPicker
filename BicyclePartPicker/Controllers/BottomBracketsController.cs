using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BicyclePartPicker.Data;
using BicyclePartPicker.Models;

namespace BicyclePartPicker.Controllers
{
    public class BottomBracketsController : Controller
    {
        private readonly BicyclePartPickerContext _context;

        public BottomBracketsController(BicyclePartPickerContext context)
        {
            _context = context;
        }

        // GET: BottomBrackets
        public async Task<IActionResult> Index()
        {
            return View(await _context.BottomBracket.ToListAsync());
        }

        // GET: BottomBrackets/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bottomBracket = await _context.BottomBracket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bottomBracket == null)
            {
                return NotFound();
            }

            return View(bottomBracket);
        }

        // GET: BottomBrackets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BottomBrackets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,bBType")] BottomBracket bottomBracket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bottomBracket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bottomBracket);
        }

        // GET: BottomBrackets/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bottomBracket = await _context.BottomBracket.FindAsync(id);
            if (bottomBracket == null)
            {
                return NotFound();
            }
            return View(bottomBracket);
        }

        // POST: BottomBrackets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,bBType")] BottomBracket bottomBracket)
        {
            if (id != bottomBracket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bottomBracket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BottomBracketExists(bottomBracket.Id))
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
            return View(bottomBracket);
        }

        // GET: BottomBrackets/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var bottomBracket = await _context.BottomBracket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bottomBracket == null)
            {
                return NotFound();
            }

            return View(bottomBracket);
        }

        // POST: BottomBrackets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bottomBracket = await _context.BottomBracket.FindAsync(id);
            if (bottomBracket != null)
            {
                _context.BottomBracket.Remove(bottomBracket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BottomBracketExists(int id)
        {
            return _context.BottomBracket.Any(e => e.Id == id);
        }
    }
}
