using FitnessWorld.Web.Infrastructure.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorld.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleConstants.Admin)]
    [Area(AreaConstants.Admin)]
    public class BaseController : Controller
    {
    }
}
