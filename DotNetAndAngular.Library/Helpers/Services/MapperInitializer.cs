namespace DotNetAndAngular.Library.Services;

public class MapperInitializer : Profile
{
	public MapperInitializer()
	{
		CreateMap<Employee, EmployeeDto>().ReverseMap();
	}
}
