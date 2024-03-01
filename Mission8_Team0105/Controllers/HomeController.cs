using Microsoft.AspNetCore.Mvc;
using Mission8_Team0105.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace Mission8_Team0105.Controllers
{
    public class HomeController : Controller
    {

        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp) //constructor
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddEdit");
        }

        [HttpPost]
        public IActionResult AddEdit(Models.Task response)
        {

            // add the record to the database
            _repo.Tasks.Add(response);
            _repo.SaveChanges(); //commit changes to the database


            // need to change the return view
            return View("TaskAddConfirm", response);
        }


        // view to look at all the tasks
        public IActionResult Quadrants()
        {

            // need to change the variable we are calling on here
            var collections = _repo.Tasks.Include("Category").ToList();
                //.OrderBy(x => x.CategoryName).ToList();

            // need to change the return view here
            return View(collections);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            return View("AddEdit", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);


            // change return view
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Models.Task task)
        {
            _repo.Tasks.Remove(task);
            _repo.SaveChanges();

            return RedirectToAction("ConfirmDelete");
        }
    }
}

