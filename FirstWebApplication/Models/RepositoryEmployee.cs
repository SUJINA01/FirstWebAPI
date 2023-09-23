using FirstWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

 

 

namespace FirstWebApplication.Models
{

    public class RepositoryEmployee

    {

        private NorthWindContext _context;

        public RepositoryEmployee(NorthWindContext context)

        {

            _context = context;

        }

        public List<Employee> GetAllEmployees()

        {

            return _context.Employees.ToList();

        }

        public Employee GetEmployeeId(int id)

        {

            Employee employee = _context.Employees.Find(id);

            return employee;

        }

        //public Employee UpdateEmployee(Employee updatedEmployee)

        //{

        //    EntityState es = _context.Entry(updatedEmployee).State;

        //    Console.WriteLine($"EntityState b4 Update :{es.GetDisplayName()}");

        //    _context.Employees.Update(updatedEmployee);

        //    es = _context.Entry(updatedEmployee).State;

        //    Console.WriteLine($"EntityState After Update :{es.GetDisplayName()}");

        //    _context.SaveChanges();

        //    es = _context.Entry(updatedEmployee).State;

        //    Console.WriteLine($"EntityState After SaveChanges :{es.GetDisplayName()}");

        //    return updatedEmployee;

        //}

        public int UpdateEmployee(Employee modifiedEmployee)

        {

            EntityState es = _context.Entry(modifiedEmployee).State;

            Console.WriteLine($"EntityState B4Update:{es.GetDisplayName()}");

            _context.Employees.Update(modifiedEmployee);

            es = _context.Entry(modifiedEmployee).State;

            Console.WriteLine($"EntityState After Update : {es.GetDisplayName()}");

            int result = _context.SaveChanges();

            es = _context.Entry(modifiedEmployee).State;

            Console.WriteLine($"EntityState After SaveChanges : {es.GetDisplayName()}");

            return result;

        }

        public void AddNewEmployee(Employee employee)

        {

            Employee? foundEmp = _context.Employees.Find(employee.EmployeeId);

            if (foundEmp != null)

            {

                throw new Exception("Failed to add new employee.Duplicate Id");

            }

            EntityState es = _context.Entry(employee).State;

            Console.WriteLine($"EntityState b4 Add :{es.GetDisplayName()}");

            _context.Employees.Add(employee);

            es = _context.Entry(employee).State;

            Console.WriteLine($"EntityState b4 Add :{es.GetDisplayName()}");

            _context.SaveChanges();

            es = _context.Entry(employee).State;

            Console.WriteLine($"EntityState b4 Add :{es.GetDisplayName()}");

        }

        public int DeleteEmployee(int id)

        {

            Employee empToDelete = _context.Employees.Find(id);

            EntityState es = EntityState.Detached;

            int result = 0;

            if (empToDelete != null)

            {

                es = _context.Entry(empToDelete).State;

                Console.WriteLine($"EntityState B4Update : {es.GetDisplayName()}");

                _context.Employees.Remove(empToDelete);

                es = _context.Entry(empToDelete).State;

                Console.WriteLine($"EntityState After Update : {es.GetDisplayName()}");

                result = _context.SaveChanges();

                es = _context.Entry(empToDelete).State;

                Console.WriteLine($"EntityState After SaveChanges : {es.GetDisplayName()}");

            }

            return result;

        }

    }

}

