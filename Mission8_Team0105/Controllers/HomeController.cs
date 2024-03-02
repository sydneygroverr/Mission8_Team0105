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

            return View(new Models.Task());
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
            var tasks = _repo.GetIncompleteTasksWithCategory();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.GetTaskByID(id);
            if (recordToEdit == null)
            {
                return NotFound();
            }

            return View("AddEdit", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedInfo)
        {
            _repo.Edit(updatedInfo);

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
            _repo.Delete(task);

            return RedirectToAction("ConfirmDelete");
        }
    }
}

