namespace DotNetAndAngular.Library.Models.Dto;

public class EmployeeDto
{
    [Required]
    [DisplayName("First Name")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be between 3 - 50 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [DisplayName("Last Name")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be between 3 - 50 characters")]
    public string LastName { get; set; } = string.Empty;

    [StringLength(6, MinimumLength = 4, ErrorMessage = "Gender is too long. Check your input!")]
    public string? Gender { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Address is too long")]
    public string? Address { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Range(0, Int64.MaxValue, ErrorMessage = "Contact number should not contain characters")]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [Range(100, double.MaxValue, ErrorMessage = "Too low value. Check your input!")]
    public decimal Salary { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }


    public string FullName() => FirstName + ' ' + LastName;


    public EmployeeDto()
    {

    }
}
