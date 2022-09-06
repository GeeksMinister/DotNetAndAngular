namespace DotNetAndAngular.API.DataAccess.Data;
public class CompanyDbContext : DbContext
{
	private readonly IConfiguration _config;

	public CompanyDbContext(DbContextOptions<CompanyDbContext> options, IConfiguration config)
		: base(options) 
	{
		_config = config;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		if (options.IsConfigured == false)
		{
			options.UseSqlite(_config.GetConnectionString("Default"));
		}
	}

	public DbSet<Employee>? Employee { get; set; }
	public DbSet<Department>? Department { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Employee>()
			.HasOne(emp => emp.Department)
			.WithMany(dep => dep.Employees)
			.HasForeignKey(emp => emp.DepartmentId);
	}
}
