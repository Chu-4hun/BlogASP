using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogAsp.Data;
using BlogAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAsp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext bd;
        
        // private readonly ILogger<HomeController> _logger;
        //
        public HomeController(ApplicationDbContext contex)
        {
            bd = contex;
        }

        public async Task<IActionResult> Index()
        {
            return View(await bd.Users.ToListAsync());
        }
        
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(User user)
        {
            bd.Users.Add(user);
            await bd.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // public IActionResult Privacy()
        // {
        //     return View();
        // }
        //
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
        public IActionResult Privacy()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ColDelete(int? id)
        {
            if (id != null)
            {
                User user = await bd.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                {
                    return View(user);
                }
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User user = await bd.Users.FirstOrDefaultAsync(predicate => predicate.Id == id);
                if (user != null)
                {
                    bd.Users.Remove(user);
                    await bd.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }

        

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }
    }
}