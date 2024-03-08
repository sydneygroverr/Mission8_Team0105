using Microsoft.AspNetCore.Mvc;
using Mission8_Team0105.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


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
            ViewBag.Category = _repo.Category
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Add", new Models.Task());
        }

        [HttpPost]
        public IActionResult Add(Models.Task response)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(response);
                _repo.SaveChanges();

                return View("ConfirmAddTask", response);
            }
            else
            {
                ViewBag.Category = _repo.Category
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);

            }
        }


        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = _repo.GetIncompleteTasksWithCategory();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Category = _repo.Category
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Add", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedInfo)
        {
            _repo.Edit(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.GetTaskByID(id);
            
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

