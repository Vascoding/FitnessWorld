using Microsoft.AspNetCore.Mvc;

namespace FitnessWorld.Web.Areas.Admin.Controllers
{
    public class AdminsController : BaseController
    {
        public IActionResult Index() => this.View();
    }
}
