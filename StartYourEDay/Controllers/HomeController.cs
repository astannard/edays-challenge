using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using ServiceLayer.Models;
using StartYourEDay.Models;

namespace StartYourEDay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDailyMessageService _dailyMessageService;
        private const string languageCookieKey = "StartYourEDay.LanguagePreference";

        public HomeController(ILogger<HomeController> logger, IDailyMessageService dailyMessageService)
        {
            _logger = logger;
            _dailyMessageService = dailyMessageService;
        }

        public IActionResult Index()
        {
            // var dailyMessage = _dailyMessageService.GetTodaysMessage(DateTime.Now);
            Console.WriteLine(GetUserLanguagePreference());

            return View(new HomeViewModel {
                Message = "Time to get up and have a stretch",// dailyMessage.GetMessage(GetUserLanguagePreference()),
                ImageUrl = "https://images.unsplash.com/photo-1569698045292-e14cb5393e79?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80" //dailyMessage.ImageUrl
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult SetLanguagePreferenceCookie(string language)
        {

            if (!String.IsNullOrWhiteSpace(language))
            {
                SetLanguagePreferenceInCookie(language);
                return new JsonResult(new { success = true });
            }
            return new JsonResult(new { sucess = false });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Language GetUserLanguagePreference()
        {
            string cookieLanguagePreference = Request.Cookies[languageCookieKey];
            if (!String.IsNullOrWhiteSpace(cookieLanguagePreference))
            {
                try
                {
                    var language =  Enum.Parse(typeof(Language), cookieLanguagePreference);
                    return (Language)language;
                }catch(Exception e)
                {
                    _logger.LogError("Invalid language found", cookieLanguagePreference);
                }
               
            }
            return Language.english;
        }

        private void SetLanguagePreferenceInCookie(string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddYears(10);

            Response.Cookies.Append(languageCookieKey, value, option);
        }
    }
}
