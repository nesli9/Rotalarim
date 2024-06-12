using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Rotalarim.Models;
using Microsoft.EntityFrameworkCore;
using Rotalarim.Entity;

namespace Rotalarim.Controllers{
    public class UsersController : Controller
    {
        public UsersController(){

        }
        public IActionResult Login(){
            return View();
        }
    }
}