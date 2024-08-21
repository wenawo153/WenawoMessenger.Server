using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WenawoMessenger.Server.UserService.Models;
using WenawoMessenger.Server.UserService.Services.AuthorizationService;

namespace WenawoMessenger.Server.UserService.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AuthorizationController(IAuthorizationService authorizationService) : Controller
    {
        IAuthorizationService _authorizationService = authorizationService;

        [HttpPost ("Registration")]
        public ActionResult Registration([FromQuery] string name, [FromQuery] string password)
        {
            User user = _authorizationService.Registration(name, password);

            return Ok(user);
        }

        //public ActionResult Login(int id)
        //{
        //    return View();
        //}
    }
}
