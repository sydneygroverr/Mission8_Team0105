using Microsoft.AspNetCore.Mvc;
using Mission8_Team0105.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Mission8_Team0105.Controllers
{

    // many of these are copy pasted from mission 7 and havent had all of the variables changed yet since I am not sure what needs to be changed and what can be deleted
    // once I have more info about the code you guys are writing I can better fit these to what actually needs to be executed

    public class HomeController : Controller
    {

        private ToDoListContext _context;

        public HomeController(ToDoListContext temp) //constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuadrantsView()
        {
            return View("QuadrantsView");
        }

        public IActionResult TasksView()
        {
            return TasksView();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Tasks = _context.Tasks
                .OrderBy(x => x.TaskName)
                .ToList();

            return View("AddTask");
        }

        [HttpPost]
        public IActionResult AddTask(Movie response)
        {

            // add the record to the database
            _context.Movies.Add(response);
            _context.SaveChanges(); //commit changes to the database

            return View("Confirmation", response);
        }

        public IActionResult TaskData()
        {
            var collections = _context.Movies.Include("Category")
                .OrderBy(x => x.Title).ToList();

            return View(collections);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieData");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieData");
        }
    }
}











//This is some of the homecontroller from mission7 that i havent implemented into our code yet

//    public class HomeController : Controller
//    {



//        [HttpGet]
//        public IActionResult AddMovie()
//        {
//            ViewBag.Categories = _context.Categories
//                .OrderBy(x => x.CategoryName)
//                .ToList();

//            return View("AddMovie");
//        }

//        [HttpPost]
//        public IActionResult AddMovie(Movie response)
//        {

//            // add the record to the database
//            _context.Movies.Add(response);
//            _context.SaveChanges(); //commit changes to the database

//            return View("Confirmation", response);
//        }

//        public IActionResult MovieData()
//        {
//            var collections = _context.Movies.Include("Category")
//                .OrderBy(x => x.Title).ToList();

//            return View(collections);
//        }

//    }
//}
