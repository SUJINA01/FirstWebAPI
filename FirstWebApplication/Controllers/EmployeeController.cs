
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;





namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet]
        // GET: EmployeeController
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
            return employees;
        }
        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmpViewModel> GetAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
            var empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }
                ).ToList();
            return empList;
        }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            //Customer customer = _repositoryCustomers.FindCustomerById(id);
            //return View(customer);
            Employee employees = _repositoryEmployee.GetEmployeeId(id);
            return employees;
        }
        [HttpPost("/AddNewEmployee")]
        public int AddNewEmployee([FromBody] Employee employee)
        {
            _repositoryEmployee.AddNewEmployee(employee);
            return 1;
        }
        [HttpPut("/EditEmployee")]
        public void EditEmployee([FromBody] EmpViewModel updatedEmployee)
        {
            Employee employee = new Employee()
            {
                EmployeeId = updatedEmployee.EmpId,
                FirstName = updatedEmployee.FirstName,
                LastName = updatedEmployee.LastName,
                BirthDate = updatedEmployee.BirthDate,
                HireDate = updatedEmployee.HireDate,
                City = updatedEmployee.City,
                ReportsTo = updatedEmployee.ReportsTo,
                Title = updatedEmployee.Title
            };





            _repositoryEmployee.UpdateEmployee(employee);
        }



        [HttpDelete("/DeleteEmployee")]
        public int DeleteEmployee(int id)
        {
            _repositoryEmployee.DeleteEmployee(id);
            return 1;
        }







    }
}