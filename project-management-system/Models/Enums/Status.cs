namespace project_management_system.Models.Enums
{
    using System.ComponentModel.DataAnnotations;
    
    public enum Status
    {
        Undefined = 0,
        [Display(Name = "To Do")]
        ToDo = 1,
        [Display(Name = "In Progress")]
        InProgress = 2,
        [Display(Name = "Ready for Test")]
        ReadyForTest = 3,
        Done = 4
    }
}
