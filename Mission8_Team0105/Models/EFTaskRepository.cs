using Microsoft.AspNetCore.Mvc;

namespace Mission8_Team0105.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private task_context _context;

        public EFTaskRepository(task_context temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();

        public dynamic Category { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(Task response)
        {
            _context.Add(response);
            _context.SaveChanges();
        }

        public void Delete(Task response)
        {
            _context.Remove(response);
            _context.SaveChanges();
        }

        public void Edit(Task response)
        {
            _context.Update(response);
            _context.SaveChanges();
        }

        public Task GetTaskById(int taskId)
        {
            var task = _context.Tasks
                .FirstOrDefault(t => t.TaskId == taskId);

            if (task == null)
            {
                throw new InvalidOperationException($"No Task found with ID {taskId}.");
            }

            return task;
        }

        public List<Task> GetIncompleteTasksWithCategory()
        {
            return _context.Tasks.Where(t => t.Completed == false).ToList();
        }

        public Task GetTaskByID(int taskId)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        //public Task GetTaskById(int id)
        //{
        //    return _context.Tasks.SingleOrDefault(x => x.TaskId == id);
        //}

        //public List<Category> GetAllCategoriesOrderedByName()
        //{
        //    return _context.Categories.OrderBy(x => x.CategoryName).ToList();
        //}

    }
}

//namespace ScaffoldingFun.Models
//{
//    public class EFBaseballRepository : IBaseballRepository
//    {
//        private Lahman18712022Context _context;
//        public EFBaseballRepository(Lahman18712022Context temp)
//        {
//            _context = temp;
//        }

//        public List<Manager> Managers => _context.Managers.ToList();

//        public void AddManager(Manager manager)
//        {
//            _context.Add(manager);
//            _context.SaveChanges();
//        }
//    }
//}
