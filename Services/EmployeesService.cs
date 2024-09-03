using EmployeeTaskManager.DB;
using EmployeeTaskManager.Models;
using EmployeeTaskManager.Services.Interfaces;

namespace EmployeeTaskManager.Services
{
    public class EmployeesService : IEmployeesService
    {
        private EmployeeTaskDBContext _context;

        public EmployeesService(EmployeeTaskDBContext context)
        {
            _context = context;
        }

        //public bool DeleteEmployees(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public Employees GetEmployeesById(long id)
        {
            Employees emp;
            try
            {
                emp = _context.Find<Employees>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }

        public List<Employees> GetEmployeesList()
        {
            List<Employees> empList;

            try
            {
                empList = _context.Set<Employees>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }

        public bool SaveEmployee(Employees employee)
        {
            bool result;
            try
            {
                Employees _temp = GetEmployeesById(employee.EmployeeID);
                if (_temp != null)
                {
                    _temp.EmployeeID = employee.EmployeeID;
                    _temp.EmployeeName = employee.EmployeeName;
                    _temp.Role = employee.Role;
                    _temp.ManagerID = employee.ManagerID;
                    _context.Update<Employees>(_temp);
                    result = true;
                }
                else
                {
                    _context.Add<Employees>(employee);
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
    }
}
