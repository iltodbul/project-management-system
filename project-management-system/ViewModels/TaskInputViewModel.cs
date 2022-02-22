namespace project_management_system.ViewModels
{
    public class TaskInputViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Assignee { get; set; }

        public int TaskType { get; set; }

        public int Priority { get; set; }

        public int Status { get; set; }

        public int Estimate { get; set; }

        public string CreatedAt { get; set; }
    }
}
