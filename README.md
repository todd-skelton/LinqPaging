[![](https://img.shields.io/nuget/v/LinqPaging.svg)](https://www.nuget.org/packages/LinqPaging) [![](https://img.shields.io/nuget/vpre/LinqPaging.svg)](https://www.nuget.org/packages/LinqPaging)

# LinqPaging
Paging made easy with Linq syntax and extensions. Translates directly to SQL for database-side paging when using Entity Framework.

## Installation
### Package Manager
`Install-Package LinqPaging`

### .NET CLI
`dotnet add package LinqPaging`

### ToPagedList
Just call `ToPagedList` on your Linq expression to convert the source into a subset. When using Entity Framework, the extension will be translated to SQL using the `Skip` and `Take` methods for you.

```csharp
// defaults to page 1, 20 results per page
var employees = dbContext.Employees.ToPagedList(); 

// page 2, 30 results per page
var employees = dbContext.Employees.ToPagedList(2,30); 

```

### IPageable
You can include the IPageable interface to a strongly-typed request class and pass it to the `ToPagedList` method.


#### Request
```csharp
public class GetEmployeesRequest : IPageable
{
	public string Query { get; set; }

	public int? Page { get; set; }

	public int? Results { get; set; }
}
```

#### Usage
```csharp
// employees?query={query}&page={page}&results={results}
[Route("employees")]
public async Task<IActionResult> GetEmployeesRequest([FromQuery]GetEmployeesRequest request)
{
    return dbContext.Employees
		.Where(e=> e.Name.Contains(request.Query))
		.ToPagedList(request);
}
```