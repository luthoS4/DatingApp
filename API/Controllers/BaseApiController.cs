using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] //attribute
    [Route("api/[controller]")] //re-routes to the controller class
    public class BaseApiController : ControllerBase
    {
        
    }
}