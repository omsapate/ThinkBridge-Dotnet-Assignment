using EmployeeTaskManager.DB;
using EmployeeTaskManager.Models;
using EmployeeTaskManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeTaskManager.Services
{
    public class TaskServices : ITaskService
    {
        private EmployeeTaskDBContext _context;

        public TaskServices(EmployeeTaskDBContext context)
        {
            _context = context;
        }

        public List<Models.Task> GetMonthlyTaskList()
        {
            List<Models.Task> taskList;

            try
            {
                taskList = _context.Set<Models.Task>().ToList().Where(x => x.DueDate.ToUniversalTime() >= DateTime.Now.ToUniversalTime() && x.DueDate.ToUniversalTime() <= DateTime.Now.AddDays(30).ToUniversalTime()).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return taskList;
        }

        public Models.Task GetTask(long id)
        {
            Models.Task task;
            try
            {
                task = _context.Find<Models.Task>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }

        public List<Models.Task> GetTaskList()
        {
            List<Models.Task> taskList;

            try
            {
                taskList = _context.Set<Models.Task>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return taskList;
        }

        public List<Models.Task> GetWeeklyReportTaskList()
        {
            List<Models.Task> taskList;

            try
            {
                taskList = _context.Set<Models.Task>().Where(x => x.DueDate.ToUniversalTime() >= DateTime.Now.ToUniversalTime() && x.DueDate.ToUniversalTime() <= DateTime.Now.AddDays(7).ToUniversalTime()).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return taskList;
        }

        public bool SaveDocumentsToTask(long taskId, Documents documents)
        {
            bool result;
            try
            {
                Models.Task _temp = GetTask(taskId);
                if (_temp != null)
                {
                    _temp.Documents = documents;

                    _context.Update<Models.Task>(_temp);
                    _context.SaveChanges();

                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool SaveNoteToTask(Models.Task task)
        {
            throw new NotImplementedException();
        }

        public bool SaveTask(Models.Task task)
        {
            bool result;
            try
            {
                Models.Task _temp = GetTask(task.TaskId);
                if (_temp != null)
                {
                    _temp.EmployeeID = task.EmployeeID;
                    _temp.TaskId = task.TaskId;
                    _temp.IsCompleted = task.IsCompleted;
                    _temp.Documents = task.Documents;
                    _temp.Notes = task.Notes;
                    _temp.DueDate = task.DueDate.ToUniversalTime();
                    _context.Update<Models.Task>(_temp);
                    result = true;
                }
                else
                {
                    _context.Add<Models.Task>(task);
                    result = true;
                }
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool UpdateTaskStatus(long taskId, bool isCompleted)
        {
            bool result;
            try
            {
                Models.Task _temp = GetTask(taskId);
                if (_temp != null)
                {
                    _temp.IsCompleted = isCompleted;

                    _context.Update<Models.Task>(_temp);
                    _context.SaveChanges();

                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
