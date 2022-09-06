namespace DotNetAndAngular.API.DataAccess.Repositories.DepartmentRepository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly CompanyDbContext _dbContext;

    public DepartmentRepository(CompanyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Department>> GetAllDepartments()
    {
        var result = await _dbContext.Department!.ToListAsync();
        return result;
    }


}
