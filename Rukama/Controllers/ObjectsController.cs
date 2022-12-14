using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rukama.Areas.Identity.Data;
using Rukama.Data;
using Rukama.Models;
using Rukama.ViewModels;

namespace Rukama.Controllers
{
    public class ObjectsController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<User> _userManager;

        public IWebHostEnvironment _hostEnvironment { get; }

        public ObjectsController(   AuthDbContext context,
                                    IWebHostEnvironment hostEnvironment,
                                    UserManager<User> userManager)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        // GET: Objects
        public async Task<IActionResult> Index()
        {
            ViewBag.userID = _userManager.GetUserId(User);

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
            ViewBag.objecttypes = new SelectList(_context.ObjectType, "Name", "Name");
            ViewBag.specializations = new SelectList(_context.Specialization, "Name", "Name");
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ObjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {


                string uniqueFileName1 = await ProcessUploadedFile1(model);

                string uniqueFileName2 = await ProcessUploadedFile2(model);

                string uniqueFileName3 = await ProcessUploadedFile3(model);

                var userID = _userManager.GetUserId(User);

                //Insert record
                Models.Object @object = new Models.Object()
                {
                    ObjectName = model.ObjectName,
                    UserID = userID,
                    ObjectType = model.ObjectType,
                    Specialization = model.Specialization,
                    Street = model.Street,
                    StreetNr = model.StreetNr,
                    City = model.City,
                    Country = model.Country,
                    MobileNr = model.MobileNr,
                    TelephoneNr = model.TelephoneNr,
                    Email = model.Email,
                    URL = model.URL,
                    Comment = model.Comment,
                    ImagePath1 = uniqueFileName1,
                    ImagePath2 = uniqueFileName2,
                    ImagePath3 = uniqueFileName3,
                    CreationDate = model.CreationDate,
                    ModifiedDate = model.ModifiedDate,

                };
                _context.Add(@object);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ObjectID = @object.ObjectID });
            }
            return View();
        }

        private async Task<string> ProcessUploadedFile3(ObjectCreateViewModel model)
        {
            string uniqueFileName3 = null;

            if (model.Image3 != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects");
                uniqueFileName3 = Guid.NewGuid().ToString() + "_" + model.Image3.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName3);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image3.CopyToAsync(fileStream);
                }
            }

            return uniqueFileName3;
        }

        private async Task<string> ProcessUploadedFile2(ObjectCreateViewModel model)
        {
            string uniqueFileName2 = null;

            if (model.Image2 != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects");
                uniqueFileName2 = Guid.NewGuid().ToString() + "_" + model.Image2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image2.CopyToAsync(fileStream);
                }
            }

            return uniqueFileName2;
        }

        private async Task<string> ProcessUploadedFile1(ObjectCreateViewModel model)
        {
            string uniqueFileName1 = null;
            if (model.Image1 != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects");
                uniqueFileName1 = Guid.NewGuid().ToString() + "_" + model.Image1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image1.CopyToAsync(fileStream);
                }
            }

            return uniqueFileName1;
        }

        // GET: Objects/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Object == null)
            {
                return NotFound();
            }

            var @object = await _context.Object.FindAsync(id);

            if (@object != null)
            {
                ObjectEditViewModel objectEditViewModel = new ObjectEditViewModel
                {
                    ObjectID = @object.ObjectID,
                    UserID = @object.UserID,
                    ObjectName = @object.ObjectName,
                    ObjectType = @object.ObjectType,
                    Specialization = @object.Specialization,
                    Street = @object.Street,
                    StreetNr = @object.StreetNr,
                    City = @object.City,
                    Country = @object.Country,
                    MobileNr = @object.MobileNr,
                    TelephoneNr = @object.TelephoneNr,
                    Email = @object.Email,
                    URL = @object.URL,
                    Comment = @object.Comment,
                    ExistingImagePath1 = @object.ImagePath1,
                    ExistingImagePath2 = @object.ImagePath2,
                    ExistingImagePath3 = @object.ImagePath3,
                    CreationDate = @object.CreationDate,
                    ModifiedDate = @object.ModifiedDate,
                };

                ViewBag.objecttypes = new SelectList(_context.ObjectType, "Name", "Name");
                ViewBag.specializations = new SelectList(_context.Specialization, "Name", "Name");

                return View(objectEditViewModel);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: Objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ObjectEditViewModel model)
        {
            if (_context.Object == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    var @object = await _context.Object.FindAsync(id);
                    var userID = _userManager.GetUserId(User);

                    @object.ObjectName = model.ObjectName;
                    @object.UserID = userID;
                    @object.ObjectType = model.ObjectType;
                    @object.Specialization = model.Specialization;
                    @object.Street = model.Street;
                    @object.StreetNr = model.StreetNr;
                    @object.City = model.City;
                    @object.Country = model.Country;
                    @object.MobileNr = model.MobileNr;
                    @object.TelephoneNr = model.TelephoneNr;
                    @object.Email = model.Email;
                    @object.URL = model.URL;
                    @object.Comment = model.Comment;
                    @object.CreationDate = model.CreationDate;
                    @object.ModifiedDate = model.ModifiedDate;

                    if (model.Image1 != null)
                    {
                        if (model.ExistingImagePath1 != null)
                        {
                            string filePath1 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects", model.ExistingImagePath1);
                            System.IO.File.Delete(filePath1);
                        }
                        @object.ImagePath1 = await ProcessUploadedFile1(model);

                    }

                    if (model.Image2 != null)
                    {
                        if (model.ExistingImagePath2 != null)
                        {
                            string filePath2 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects", model.ExistingImagePath2);
                            System.IO.File.Delete(filePath2);
                        }
                        @object.ImagePath2 = await ProcessUploadedFile2(model);
                    }

                    if (model.Image3 != null)
                    {
                        if (model.ExistingImagePath3 != null)
                        {
                            string filePath3 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects", model.ExistingImagePath3);
                            System.IO.File.Delete(filePath3);
                        }
                        @object.ImagePath3 = await ProcessUploadedFile3(model);

                    }

                    _context.Update(@object);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
            }

            return View();
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
                if (@object.ImagePath1 != null)
                {
                    //delete 1. image from wwwroot/image
                    var Path1 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects", @object.ImagePath1);

                    if (System.IO.File.Exists(Path1))
                        System.IO.File.Delete(Path1);
                }
                if (@object.ImagePath2 != null)
                {
                    //delete 2. image from wwwroot/image
                    var Path2 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects", @object.ImagePath2);

                    if (System.IO.File.Exists(Path2))
                        System.IO.File.Delete(Path2);

                }
                if (@object.ImagePath3 != null)
                {
                    //delete 3. image from wwwroot/image
                    var Path3 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Objects", @object.ImagePath3);

                    if (System.IO.File.Exists(Path3))
                        System.IO.File.Delete(Path3);
                }

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
