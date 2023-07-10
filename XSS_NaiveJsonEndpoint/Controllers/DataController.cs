using Microsoft.AspNetCore.Mvc;

namespace XSS_NaiveJsonEndpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    public List<string> GetData(string searchTerm)
    {
        return new List<string>
        {
            searchTerm + " 1",
            searchTerm + " 2",
            searchTerm + " 3"
        };
    }
}