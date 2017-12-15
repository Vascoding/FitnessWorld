using FitnessWorld.Web.Infrastructure.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorld.Web.Areas.Calculator.Controllers
{
    [Area(AreaConstants.Calculator)]
    [Authorize]
    public class BaseController : Controller
    {
    }
}
