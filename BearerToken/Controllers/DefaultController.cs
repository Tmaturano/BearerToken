using BearerToken.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BearerToken.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            //We need to send the token on each request, because in WebApi we do not keep authenticated.
            //The Token will be stored in User.Identity.Name

            //Install-Package RestSharp.
            var client = new RestClient("http://localhost:50926");

            var request = new RestRequest("api/security/token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", userName);
            request.AddParameter("password", password);


            IRestResponse<TokenViewModel> response = client.Execute<TokenViewModel>(request);
            var token = response.Data.AccessToken;

            //With SPA apps, WebApi, we need on each request a token, and one of the more security ways of doing this in ASP.NET
            //is the SetAuthCookie, because it will create a encrypted cookie
            if (!string.IsNullOrEmpty(token))
                FormsAuthentication.SetAuthCookie(token, false);

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}