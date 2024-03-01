namespace Mission8_Team0105.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        object Categories { get; }

        public void AddEdit(Task response);
        void SaveChanges();
        void Update(Task updatedInfo);
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