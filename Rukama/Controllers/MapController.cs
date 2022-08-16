
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rukama.Data;
using Rukama.Models;
using static Rukama.Models.Subject;

namespace Rukama.Controllers
{
    public class MapController : Controller
    {
        private readonly AuthDbContext _context;

        public MapController(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Subjects()
        {
            return _context.Subject != null ?
                        View(await _context.Subject.ToListAsync()) :
                        Problem("Entity set 'AuthDbContext.Subject'  is null.");
        }

        public async Task<IActionResult> Objects()
        {
            return _context.Object != null ?
                        View(await _context.Object.ToListAsync()) :
                        Problem("Entity set 'AuthDbContext.Object'  is null.");
        }
    }
}