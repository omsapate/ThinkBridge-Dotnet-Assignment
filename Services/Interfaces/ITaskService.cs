using EmployeeTaskManager.Models;

namespace EmployeeTaskManager.Services.Interfaces
{
    public interface ITaskService
    {
        List<Models.Task> GetTaskList();
        List<Models.Task> GetWeeklyReportTaskList();
        List<Models.Task> GetMonthlyTaskList();

        Models.Task GetTask(long id);

        bool SaveTask(Models.Task task);

        bool SaveDocumentsToTask(long taskId, Documents documents);

        bool SaveNoteToTask(Models.Task task);

        bool UpdateTaskStatus(long taskId, bool isCompleted);

    }
}
