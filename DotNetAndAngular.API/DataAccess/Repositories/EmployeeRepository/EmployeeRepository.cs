namespace DotNetAndAngular.API.DataAccess.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly CompanyDbContext _dbContext;

    public EmployeeRepository(CompanyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _dbContext.Employee!.Include(emp => emp.Department).ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(Guid employeeId)
    {
        var result = await _dbContext.Employee!.Include(emp => emp.Department)
            .FirstOrDefaultAsync(emp => emp.Guid == employeeId);
        return result!;
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var result = await _dbContext.Employee!.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Employee?> UpdateEmployee(Employee updated)
    {
        var employee = await _dbContext.Employee!.FirstOrDefaultAsync(emp => emp.Guid == updated.Guid);
        if (employee == null) return null;

        employee.FirstName = updated.FirstName;
        employee.LastName = updated.LastName;
        employee.Email = updated.Email;
        employee.Phone = updated.Phone;
        employee.Gender = updated.Gender;
        employee.Address = updated.Address;
        employee.DepartmentId = updated.DepartmentId;
        employee.Salary = updated.Salary;
        await _dbContext.SaveChangesAsync();

        return employee;
    }

    public async Task DeleteEmployee(Guid employeeId)
    {
        var employee = await _dbContext.Employee!.FirstOrDefaultAsync(emp => emp.Guid == employeeId);
        if (employee == null) return;

        _dbContext.Remove(employee);
        await _dbContext.SaveChangesAsync();
    }



}
