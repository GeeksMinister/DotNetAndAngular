using DotNetAndAngular.API.DataAccess.Repositories.DepartmentRepository;
using DotNetAndAngular.API.DataAccess.Repositories.EmployeeRepository;
using DotNetAndAngular.Library.Models.Dto;

namespace DotNetAndAngular.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public CompanyController(IMapper mapper, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    [HttpGet("Employee")]
    public async Task<IActionResult> GetAllEmployees()
    {
        try
        {
            var result = await _employeeRepository.GetAllEmployees();
            if (result is null) return NoContent();
            Response.Headers.Add("total_employees", result.Count.ToString());
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status204NoContent, "Failed to retrive data from server");
        }
    }

    [HttpGet("Employee/{guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid guid)
    {
        try
        {
            var employee = await _employeeRepository.GetEmployeeById(guid);
            if (employee is null) return NotFound();
            return Ok(employee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Failed to retrieve data");
        }
    }

    [HttpPost("Employee")]
    public async Task<IActionResult> AddEmployee(EmployeeDto dto)
    {
        try
        {
            var employee = _mapper.Map<Employee>(dto);
            employee = await _employeeRepository.AddEmployee(employee);
            if (employee is null) return BadRequest();
            return CreatedAtAction(nameof(GetEmployeeById), new {Guid = employee.Guid}, employee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to add a new Employee. Check the DepartmentId");
        }
    }

    [HttpDelete("Employee/{guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid guid)
    {
        try
        {
            var employee = await _employeeRepository.GetEmployeeById(guid);
            if (employee is null) return NotFound($"Employee with Id: {guid} Was Not Found!");
            await _employeeRepository.DeleteEmployee(guid);
            return Ok($"Employee with Id: {guid} Was Successfully Removed.");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Remove the Employee");
        }
    }

    [HttpPut("Employee/{guid}")]
    public async Task<IActionResult> UpdateEmployee(Guid guid, EmployeeDto dto)
    {
        try
        {
            var employee = await _employeeRepository.GetEmployeeById(guid);
            if (employee is null) return NotFound($"Employee with Id: {guid} Was Not Found!");
            employee = _mapper.Map<Employee>(dto);
            employee.Guid = guid;
            employee = await _employeeRepository.UpdateEmployee(employee);
            if (employee is null) return BadRequest();
            return Ok(employee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to Update the Employee");
        }
    }

    [HttpGet("Department")]
    public async Task<IActionResult> GetAllDepartments()
    {
        try
        {
            var result = await _departmentRepository.GetAllDepartments();
            return Ok(result); 
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

}
