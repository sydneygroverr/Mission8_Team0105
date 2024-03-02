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

            return View("AddEdit");
        }

        [HttpPost]
        public IActionResult AddEdit(Models.Task response)
        {

            _repo.AddEdit(response);

            // need to change the return view
            return View("ConfirmAddTask", response);
        }


        [HttpGet]
        public IActionResult Quadrants()
        {
            var collections = _repo.Tasks.ToList();

            return View("Quadrants", collections);
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

