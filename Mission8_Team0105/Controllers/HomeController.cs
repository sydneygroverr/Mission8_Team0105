using Microsoft.AspNetCore.Mvc;
using Mission8_Team0105.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;

//namespace Mission8_Team0105.Controllers
//{

//    // many of these are copy pasted from mission 7 and havent had all of the variables changed yet since I am not sure what needs to be changed and what can be deleted
//    // once I have more info about the code you guys are writing I can better fit these to what actually needs to be executed

//    public class HomeController : Controller
//    {

//        private ToDoListContext _context;

//        public HomeController(ToDoListContext temp) //constructor
//        {
//            _context = temp;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult QuadrantsView()
//        {
//            return View("QuadrantsView");
//        }

//        public IActionResult TasksView()
//        {
//            return TasksView();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [HttpGet]
//        public IActionResult AddTask()
//        {
//            ViewBag.Tasks = _context.Tasks
//                .OrderBy(x => x.TaskName)
//                .ToList();

//            return View("AddTask");
//        }

//        [HttpPost]
//        public IActionResult AddTask(Movie response)
//        {

//            // add the record to the database
//            _context.Movies.Add(response);
//            _context.SaveChanges(); //commit changes to the database

//            return View("Confirmation", response);
//        }

//        public IActionResult TaskData()
//        {
//            var collections = _context.Movies.Include("Category")
//                .OrderBy(x => x.Title).ToList();

//            return View(collections);
//        }


//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            var recordToEdit = _context.Movies
//                .Single(x => x.MovieId == id);

//            ViewBag.Categories = _context.Categories
//            .OrderBy(x => x.CategoryName)
//            .ToList();

//            return View("AddMovie", recordToEdit);
//        }

//        [HttpPost]
//        public IActionResult Edit(Movie updatedInfo)
//        {
//            _context.Update(updatedInfo);
//            _context.SaveChanges();

//            return RedirectToAction("MovieData");
//        }

//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            var recordToDelete = _context.Movies
//                .Single(x => x.MovieId == id);

//            return View(recordToDelete);
//        }

//        [HttpPost]
//        public IActionResult Delete(Movie movie)
//        {
//            _context.Movies.Remove(movie);
//            _context.SaveChanges();

//            return RedirectToAction("MovieData");
//        }
//    }
//}










// mission 7 controller



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
            return View();
        }


        // potentially can take out depending on views created
        public IActionResult Privacy()
        {
            return View("Privacy");
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
            var collections = _context.Tasks.Include("Category")
                .OrderBy(x => x.Title).ToList();

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

