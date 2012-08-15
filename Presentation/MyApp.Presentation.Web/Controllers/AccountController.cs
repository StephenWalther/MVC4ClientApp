using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Presentation.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

    }
}
