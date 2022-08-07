using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rukama.Data;
using Rukama.Models;

namespace Rukama.Controllers
{
    public class ObjectsController : Controller
    {
        private readonly AuthDbContext _context;

        public ObjectsController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: Objects
        public async Task<IActionResult> Index()
        {
              return _context.Object != null ? 
                          View(await _context.Object.ToListAsync()) :
                          Problem("Entity set 'AuthDbContext.Object'  is null.");
        }

        // GET: Objects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Object == null)
            {
                return NotFound();
            }

            var @object = await _context.Object
                .FirstOrDefaultAsync(m => m.ObjectID == id);
            if (@object == null)
            {
                return NotFound();
            }

            return View(@object);
        }

        // GET: Objects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectID,ObjectName,ObjectType,Specialization,GPS,Street,StreetNr,City,Country,Region,MobileNr,TelephoneNr,FaxNr,Email,URL,Comment,OpeningHours,IconURL,ImageURL1,ImageURL2,ImageURL3,CreationDate,ModifiedDate")] Models.Object @object)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@object);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@object);
        }

        // GET: Objects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Object == null)
            {
                return NotFound();
            }

            var @object = await _context.Object.FindAsync(id);
            if (@object == null)
            {
                return NotFound();
            }
            return View(@object);
        }

        // POST: Objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjectID,ObjectName,ObjectType,Specialization,GPS,Street,StreetNr,City,Country,Region,MobileNr,TelephoneNr,FaxNr,Email,URL,Comment,OpeningHours,IconURL,ImageURL1,ImageURL2,ImageURL3,CreationDate,ModifiedDate")] Models.Object @object)
        {
            if (id != @object.ObjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@object);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectExists(@object.ObjectID))
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
            return View(@object);
        }

        // GET: Objects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Object == null)
            {
                return NotFound();
            }

            var @object = await _context.Object
                .FirstOrDefaultAsync(m => m.ObjectID == id);
            if (@object == null)
            {
                return NotFound();
            }

            return View(@object);
        }

        // POST: Objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Object == null)
            {
                return Problem("Entity set 'AuthDbContext.Object'  is null.");
            }
            var @object = await _context.Object.FindAsync(id);
            if (@object != null)
            {
                _context.Object.Remove(@object);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectExists(int id)
        {
          return (_context.Object?.Any(e => e.ObjectID == id)).GetValueOrDefault();
        }
    }
}
