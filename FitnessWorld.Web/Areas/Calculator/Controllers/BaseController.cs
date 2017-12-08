using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorld.Web.Areas.Calculator.Controllers
{
    [Area("Calculator")]
    [Authorize]
    public class BaseController : Controller
    {
    }
}
