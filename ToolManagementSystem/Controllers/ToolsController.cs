
using Microsoft.AspNetCore.Mvc;
using ToolManagementSystem.Data;
using ToolManagementSystem.Models;

namespace ToolManagementSystem.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tools
        public IActionResult Index()
        {
            var tools = _context.Tools.ToList();
            return View(tools);
        }

        // GET: Tools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tool tool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tool);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tool added successfully!";

                return RedirectToAction(nameof(Index));
            }

            return View(tool);
        }

        // GET: Tools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools.FindAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // POST: Tools/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tool tool)
        {
            if (id != tool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(tool);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tool updated successfully!";

                return RedirectToAction(nameof(Index));
            }

            return View(tool);
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools.FindAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Tools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools.FindAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tool = await _context.Tools.FindAsync(id);

            if (tool != null)
            {
                _context.Tools.Remove(tool);
                await _context.SaveChangesAsync();

                // TempData["SuccessMessage"] = "Tool deleted successfully!";
                TempData["SuccessMessage"] = "Good bye Mr Tool";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
