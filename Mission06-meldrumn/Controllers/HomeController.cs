using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_meldrumn.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_meldrumn.Controllers
{
    public class HomeController : Controller
    {
        private MovieAppContext daContext { get; set; }

        // Constructor
        public HomeController(MovieAppContext name)
        {
            daContext = name;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();

            // return View(new ApplicationResponse());
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if(ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges(); 

                return View("Confirmation") ;
            }
            else //If Invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View();
            }

        }

        [HttpGet]
        public IActionResult MovieList ()
        {
            var applications = daContext.Responses
                .Include(x => x.Category)
                // Filter Data-  .Where(x => x.Rating == "PG-13")
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var movie = daContext.Responses.Single(x => x.MovieID == movieid);

            return View("MovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
            daContext.Update(ar);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = daContext.Responses.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (ApplicationResponse ar)
        {
            daContext.Responses.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
