using BlackRose.Data;
using BlackRose.Interfaces;
using BlackRose.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlackRose.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventA;
        public readonly ApplicationDbContext _db;
        public HomeController(IEventRepository eventA, ApplicationDbContext db)
        {
            _eventA = eventA;
            _db = db;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventA.GetFavEv();
            return View(events);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}