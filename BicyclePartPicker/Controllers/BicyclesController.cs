using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BicyclePartPicker.Data;
using BicyclePartPicker.Models;

namespace BicyclePartPicker.Controllers
{
    public class BicyclesController : Controller
    {
        private readonly BicyclePartPickerContext _context;
        private static SelectedListViewModel selectedListViewModel = new SelectedListViewModel();
        
        public BicyclesController(BicyclePartPickerContext context)
        {
            _context = context;
        }

        // GET: Bicycles
        public async Task<IActionResult> Index(string selectedMakeId, string selectModelId, string selectedVersionId)
        {
            var list = await _context.Bicycle.ToArrayAsync();
            if (!string.IsNullOrEmpty(selectedMakeId))
            {
                System.Diagnostics.Debug.WriteLine($"Bicycle Make: {selectedMakeId} \n BicycleModel: {selectModelId} \n Bicycle Version: {selectedVersionId}");
            }

            /* var make = list[i].Make;
             var model = list[i].Model;
             var version = list[i].Version;*/
            selectedListViewModel.BicycleMakes = new List<SelectListItem>();
            selectedListViewModel.BicycleModels = new List<SelectListItem>();
            selectedListViewModel.BicycleVersions = new List<SelectListItem>();

            for (int i = 0; i < list.Count(); i++)
            {
                if (selectedListViewModel.BicycleMakes.Find(l1 => l1.Text == list[i].Make) == null)
                {
                    selectedListViewModel.BicycleMakes.Add(new SelectListItem(list[i].Make, list[i].Make));
                }
            }
            return View(selectedListViewModel);
        }

       /* [HttpGet]
        public async Task<IActionResult> Index(string bicycleMake, string bicycleModel, string bicycleVersion)
        {
            return View();
        }*/

        public JsonResult GetVersionByModelId(string modelId)
        {
            var list = new List<Bicycle>();
            var content = _context.Bicycle.ToArray();
            int count = _context.Bicycle.Count();

            for (int i = 0; i < count; i++)
            {
                if (list.Find(l => l.Version == content[i].Version) == null && content[i].Model == modelId)
                {
                    list.Add(content[i]);
                }
            }
            return Json(list);
        }

        public JsonResult GetModelByMakeId(string makeId)
        {
            var list = new List<Bicycle>();
            var content = _context.Bicycle.ToArray();
            int count = _context.Bicycle.Count();

            for (int i = 0; i < count; i++)
            {
                if (list.Find(l => l.Model == content[i].Model) == null && content[i].Make == makeId)
                {
                    list.Add(content[i]);
                }
            }
            return Json(list);
        }

        // GET: Bicycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // GET: Bicycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Version")] Bicycle bicycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicycle);
        }

        // GET: Bicycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle.FindAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }
            return View(bicycle);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Verison")] Bicycle bicycle)
        {
            if (id != bicycle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleExists(bicycle.Id))
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
            return View(bicycle);
        }

        // GET: Bicycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicycle = await _context.Bicycle.FindAsync(id);
            if (bicycle != null)
            {
                _context.Bicycle.Remove(bicycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.Id == id);
        }
    }
}
