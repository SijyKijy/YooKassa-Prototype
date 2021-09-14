using Microsoft.AspNetCore.Mvc;

namespace YooKassa.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : Controller { }
}
