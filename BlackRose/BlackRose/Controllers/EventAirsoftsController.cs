using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackRose.Data;
using BlackRose.Models;
using BlackRose.ViewModel;
using Microsoft.AspNetCore.Authorization;
using BlackRose.Interfaces;
using System.Runtime.ConstrainedExecution;

namespace BlackRose.Controllers
{
    //[Authorize(Roles ="User")]
    public class EventAirsoftsController : Controller
    {
        private readonly IEventRepository _context;

        public EventAirsoftsController(IEventRepository context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var events =  await _context.Select();
            return View(events);
        }



        // GET: EventAirsofts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var events = await _context.Get(id);
            if (events == null || _context == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // GET: EventAirsofts/Create
        [Authorize(Roles = "Организатор, Админ, Модератор")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventAirsofts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(EventAirsoftModel model)
        {
            var events = await _context.Create(model);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        // GET: EventAirsofts/Edit/5
        [Authorize(Roles = "Организатор, Админ, Модератор")]
        public async Task<IActionResult> Edit(int id)
        {
            var events = await _context.Get(id);
            if (events == null || _context == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: EventAirsofts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(EventAirsoftModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await _context.Create(model);
                }
                else
                {
                    await _context.Updated(model.Id, model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EventAirsofts/Delete/5
        [Authorize(Roles = "Организатор, Админ, Модератор")]
        public async Task<IActionResult> Delete(int id)
        {
            var events = await _context.Get(id);
            if (events == null || _context == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: EventAirsofts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(EventAirsoft entity)
        {
            var events = await _context.Delete(entity);
            return RedirectToAction(nameof(Index));
        }
    }
}
