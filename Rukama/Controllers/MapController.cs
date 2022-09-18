
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rukama.Data;
using Rukama.Models;

namespace Rukama.Controllers
{
    public class MapController : Controller
    {
        private readonly AuthDbContext _context;

        public MapController(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Subjects()
        {
            dynamic myModel = new ExpandoObject();
            if (_context.Subject != null && _context.Specialization != null)
            {
                myModel.Subjects = await _context.Subject.ToListAsync();
                myModel.Specializations = await _context.Specialization.ToListAsync();
                return View(myModel);
            } else
            {
                return Problem("Entity set 'AuthDbContext.Subject' or AuthDbContext.Specialization'  is null.");
            }
        }

        public async Task<IActionResult> Objects()
        {
            return _context.Object != null ?
                        View(await _context.Object.ToListAsync()) :
                        Problem("Entity set 'AuthDbContext.Object'  is null.");
        }

    }
}