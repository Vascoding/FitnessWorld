﻿using FitnessWorld.Web.Infrastructure.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorld.Web.Areas.Forum.Controllers
{
    [Area(AreaConstants.Forum)]
    [Authorize]
    public class BaseController : Controller
    {
    }
}
