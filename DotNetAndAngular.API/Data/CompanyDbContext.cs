using DotNetAndAngular.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAndAngular.API.Data;
public class CompanyDbContext : DbContext
{
	public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
		: base(options) { }

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
