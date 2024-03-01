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
