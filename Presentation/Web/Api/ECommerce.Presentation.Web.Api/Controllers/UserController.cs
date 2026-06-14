using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

    }
}
