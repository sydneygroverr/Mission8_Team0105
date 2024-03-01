using Microsoft.AspNetCore.Mvc;
using Mission8_Team0105.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace Mission8_Team0105.Controllers
{
    public class HomeController : Controller
    {

        private task_context _context;

        public HomeController(task_context temp) //constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View("Index");
        }


        // potentially can take out depending on views created
        public IActionResult AddEdit()
        {
            return View("AddEdit");
        }


        // this will be the add task controller once we have a add task view 
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie");
        }

        // again this will go with the add task view 
        [HttpPost]
        public IActionResult AddMovie(Models.Task response)
        {

            // add the record to the database
            _context.Tasks.Add(response);
            _context.SaveChanges(); //commit changes to the database


            // need to change the return view
            return View("Confirmation", response);
        }


        // view to look at all the tasks
        public IActionResult MovieData()
        {

            // need to change the variable we are calling on here
            var collections = _context.Tasks.Include("Category");
                //.OrderBy(x => x.CategoryName).ToList();

            // need to change the return view here
            return View(collections);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            // need to change the return view 
            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            // need to change trhe return view
            return RedirectToAction("MovieData");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskId == id);


            // change return view
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Models.Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();


            // need to change return view
            return RedirectToAction("MovieData");
        }
    }
}

