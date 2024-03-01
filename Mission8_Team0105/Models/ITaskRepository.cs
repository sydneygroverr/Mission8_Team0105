namespace Mission8_Team0105.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        public void AddEdit(Task response);
          
    }
}
