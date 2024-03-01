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

        public void AddEdit(Task response)
        {
            _context.Add(response);
            _context.SaveChanges();
        }
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
