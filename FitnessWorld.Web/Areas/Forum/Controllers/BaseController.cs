using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorld.Web.Areas.Forum.Controllers
{
    [Area("Forum")]
    [Authorize]
    public class BaseController : Controller
    {
    }
}
