using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.Controllers
{
    public class RedirectController:BaseController
    {
        private readonly IRedirectService redirectService;
         public RedirectController(IRedirectService redirectService)
        {
            this.redirectService = redirectService;
        }
    }
}
