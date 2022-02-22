namespace project_management_system.Services
{
    using project_management_system.ViewModels;

    public interface ITaskService
    {
        TasksViewModel GetById(int id);

        bool Edit(TaskInputViewModel model);
    }
}
