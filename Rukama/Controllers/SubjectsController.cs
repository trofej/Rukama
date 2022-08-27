using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rukama.Data;
using Rukama.Models;
using Rukama.ViewModels;

namespace Rukama.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly AuthDbContext _context;

        public IWebHostEnvironment _hostEnvironment { get; }

        public SubjectsController(AuthDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment; 

        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
              return _context.Subject != null ? 
                          View(await _context.Subject.ToListAsync()) :
                          Problem("Entity set 'AuthDbContext.Subject'  is null.");
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {


                string uniqueFileName1 = await ProcessUploadedFile1(model);

                string uniqueFileName2 = await ProcessUploadedFile2(model);

                string uniqueFileName3 = await ProcessUploadedFile3(model);

                //Insert record
                Subject subject = new Subject
                {
                    SubjectName = model.SubjectName,
                    LegalForm = model.LegalForm,
                    CID = model.CID,
                    Specialization = model.Specialization,
                    GPS = model.GPS,
                    Street = model.Street,
                    StreetNr = model.StreetNr,
                    City = model.City,
                    Country = model.Country,
                    Region = model.Region,
                    MobileNr = model.MobileNr,
                    TelephoneNr = model.TelephoneNr,
                    FaxNr = model.FaxNr,
                    Email = model.Email,
                    URL = model.URL,
                    Comment = model.Comment,
                    OpeningHours = model.OpeningHours,
                    Icon = model.Icon,
                    ImagePath1 = uniqueFileName1,
                    ImagePath2 = uniqueFileName2,
                    ImagePath3 = uniqueFileName3,
                    CreationDate = model.CreationDate,
                    ModifiedDate = model.ModifiedDate,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude

                };
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { SubjectID = subject.SubjectID });
            }
            return View();
        }

        private async Task<string> ProcessUploadedFile3(SubjectCreateViewModel model)
        {

            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects");
            string uniqueFileName3 = Guid.NewGuid().ToString() + "_" + model.Image3.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName3);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.Image3.CopyToAsync(fileStream);
            }

            return uniqueFileName3;
        }

        private async Task<string> ProcessUploadedFile2(SubjectCreateViewModel model)
        {

            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects");
            string uniqueFileName2 = Guid.NewGuid().ToString() + "_" + model.Image2.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.Image2.CopyToAsync(fileStream);
            }

            return uniqueFileName2;
        }

        private async Task<string> ProcessUploadedFile1(SubjectCreateViewModel model)
        {

            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects");
            string uniqueFileName1 = Guid.NewGuid().ToString() + "_" + model.Image1.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.Image1.CopyToAsync(fileStream);
            }

            return uniqueFileName1;
        }

        // GET: Subjects/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);

            if (subject != null)
            {
                SubjectEditViewModel subjectEditViewModel = new SubjectEditViewModel
                {
                    SubjectID = subject.SubjectID,
                    SubjectName = subject.SubjectName,
                    LegalForm = subject.LegalForm,
                    CID = subject.CID,
                    Specialization = subject.Specialization,
                    GPS = subject.GPS,
                    Street = subject.Street,
                    StreetNr = subject.StreetNr,
                    City = subject.City,
                    Country = subject.Country,
                    Region = subject.Region,
                    MobileNr = subject.MobileNr,
                    TelephoneNr = subject.TelephoneNr,
                    FaxNr = subject.FaxNr,
                    Email = subject.Email,
                    URL = subject.URL,
                    Comment = subject.Comment,
                    OpeningHours = subject.OpeningHours,
                    Icon = subject.Icon,
                    ExistingImagePath1 = subject.ImagePath1,
                    ExistingImagePath2 = subject.ImagePath2,
                    ExistingImagePath3 = subject.ImagePath3,
                    CreationDate = subject.CreationDate,
                    ModifiedDate = subject.ModifiedDate,
                    Latitude = subject.Latitude,
                    Longitude = subject.Longitude
                };

                return View(subjectEditViewModel);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubjectEditViewModel model)
        {
            if (_context.Subject == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    var subject = await _context.Subject.FindAsync(id);

                    subject.SubjectName = model.SubjectName;
                    subject.LegalForm = model.LegalForm;
                    subject.CID = model.CID;
                    subject.Specialization = model.Specialization;
                    subject.GPS = model.GPS;
                    subject.Street = model.Street;
                    subject.StreetNr = model.StreetNr;
                    subject.City = model.City;
                    subject.Country = model.Country;
                    subject.Region = model.Region;
                    subject.MobileNr = model.MobileNr;
                    subject.TelephoneNr = model.TelephoneNr;
                    subject.FaxNr = model.FaxNr;
                    subject.Email = model.Email;
                    subject.URL = model.URL;
                    subject.Comment = model.Comment;
                    subject.OpeningHours = model.OpeningHours;
                    subject.Icon = model.Icon;
                    subject.CreationDate = model.CreationDate;
                    subject.ModifiedDate = model.ModifiedDate;
                    subject.Latitude = model.Latitude;
                    subject.Longitude = model.Longitude;

                    if (model.Image1 != null)
                    {
                        if (model.ExistingImagePath1 != null)
                        {
                            string filePath1 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects", model.ExistingImagePath1);
                            System.IO.File.Delete(filePath1);
                        }
                        subject.ImagePath1 = await ProcessUploadedFile1(model);

                    }

                    if (model.Image2 != null)
                    {
                        if (model.ExistingImagePath2 != null)
                        {
                            string filePath2 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects", model.ExistingImagePath2);
                            System.IO.File.Delete(filePath2);
                        }
                        subject.ImagePath2 = await ProcessUploadedFile2(model);
                    }

                    if (model.Image3 != null)
                    {
                        if (model.ExistingImagePath3 != null)
                        {
                            string filePath3 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects", model.ExistingImagePath3);
                            System.IO.File.Delete(filePath3);
                        }
                        subject.ImagePath3 = await ProcessUploadedFile3(model);

                    }

                    _context.Update(subject);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subject == null)
            {
                return Problem("Entity set 'AuthDbContext.Subject'  is null.");
            }

            var subject = await _context.Subject.FindAsync(id);

            if (subject != null)
            {
                if (subject.ImagePath1 != null)
                {
                    //delete 1. image from wwwroot/image
                    var Path1 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects", subject.ImagePath1);

                    if (System.IO.File.Exists(Path1))
                        System.IO.File.Delete(Path1);
                }
                if (subject.ImagePath2 != null)
                {
                    //delete 2. image from wwwroot/image
                    var Path2 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects", subject.ImagePath2);

                    if (System.IO.File.Exists(Path2))
                        System.IO.File.Delete(Path2);

                }
                if (subject.ImagePath3 != null)
                {
                    //delete 3. image from wwwroot/image
                    var Path3 = Path.Combine(_hostEnvironment.WebRootPath, "Images/Subjects", subject.ImagePath3);

                    if (System.IO.File.Exists(Path3))
                        System.IO.File.Delete(Path3);
                }

                _context.Subject.Remove(subject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
          return (_context.Subject?.Any(e => e.SubjectID == id)).GetValueOrDefault();
        }
    }
}
