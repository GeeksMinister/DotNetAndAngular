namespace DotNetAndAngular.API.DataAccess.Repositories.EmployeeRepository;
public interface IEmployeeRepository
{
    Task<Employee> AddEmployee(Employee employee);
    Task DeleteEmployee(Guid employeeId);
    Task<List<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(Guid employeeId);
    Task<Employee?> UpdateEmployee(Employee updated);
}