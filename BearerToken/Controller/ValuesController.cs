using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BearerToken.Controller
{
    public class ValuesController : ApiController
    {
        [Authorize]
        public string Get()
        {
            return User.Identity.Name;
        }
    }
}