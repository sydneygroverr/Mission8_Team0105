using Microsoft.EntityFrameworkCore;

namespace Mission8_Team0105.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddEdit(Task response);
        public void Edit(Task task);
        public void Delete(Task task);
        public Task GetTaskByID(int taskId);
        public List<Task> GetIncompleteTasksWithCategory();
    }
}

//namespace ScaffoldingFun.Models
//{
//    public interface IBaseballRepository //public INTERFACE, which had to be changed from Class. Do not forget this.
//    {
//        List<Manager> Managers { get; }

//        public void AddManager(Manager manager);
//    }


//}