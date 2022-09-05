namespace DotNetAndAngular.Library.Models;

public class Department
{
    [Key]
    [Required]
    public Guid Guid { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(60, ErrorMessage = "Department name is too long")]
    public string DepartmentName { get; set; } = string.Empty;
    public List<Employee> Employees { get; set; } = new();

    public Department()
    {

    }
}