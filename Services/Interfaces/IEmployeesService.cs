using EmployeeTaskManager.Models;

namespace EmployeeTaskManager.Services.Interfaces
{
    public interface IEmployeesService
    {
        List<Employees> GetEmployeesList();

        Employees GetEmployeesById(long id);

        //bool DeleteEmployees(long id);

        bool SaveEmployee(Employees employee);
    }
}
