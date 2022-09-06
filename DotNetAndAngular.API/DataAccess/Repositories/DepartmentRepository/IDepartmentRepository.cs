namespace DotNetAndAngular.API.DataAccess.Repositories.DepartmentRepository;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartments();
}