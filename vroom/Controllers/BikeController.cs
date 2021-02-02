using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vroom.AppDBContext;
using vroom.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System.Net.WebSockets;

namespace vroom.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class BikeController : Controller
    {
        private readonly VRoomDBContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public BikeViewModel BikeVM { get; set; }

        public BikeController(VRoomDBContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            BikeVM = new BikeViewModel()
            {
                Makes = _db.Makes.ToList(),
                Models = _db.Models.ToList(),
                Bike = new Models.Bike()
            };
        }
        public IActionResult Index()
        {
            var bikes = _db.Bikes.Include(m => m.Make).Include(m => m.Model);
            return View(bikes);
        }
        public IActionResult Create()
        {
            return View(BikeVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(BikeVM);
            }
            _db.Bikes.Add(BikeVM.Bike);
            _db.SaveChanges();

            //get bike id we have saved in db
            var BikeID = BikeVM.Bike.Id;

            //get wwwrootpath to save the file on server
            string wwwrootPath = _hostEnvironment.WebRootPath;

            //get the uploaded files
            var files = HttpContext.Request.Form.Files;

            //get the reference of DBSet for the bike we just have saved in db
            var SavedBike = _db.Bikes.Find(BikeID);

            //upload
            if(files.Count != 0)
            {
                var ImagePath = @"images\bike\";
                var Extension = Path.GetExtension(files[0].FileName);
                var RelativeImagePath = ImagePath + BikeID + Extension;
                var AbsImagePath = Path.Combine(wwwrootPath, RelativeImagePath);

                //upload the file on server
                using (var fileStream = new FileStream(AbsImagePath, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                //set the image path on db
                SavedBike.ImagePath = RelativeImagePath;
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Edit(int id)
        //{
        //    ModelVM.Model = _db.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
        //    if (ModelVM.Model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ModelVM);
        //}
        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(ModelVM);
        //    }
        //    _db.Update(ModelVM.Model);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Delete(int id)
        {
            Bike bike = _db.Bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }
            _db.Bikes.Remove(bike);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}