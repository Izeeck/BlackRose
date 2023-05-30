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

namespace BlackRose.Controllers
{
    //[Authorize(Roles = "User")]
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentRepository _context;

        public EquipmentsController(IEquipmentRepository context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var equipment = await _context.Select();
            return View(equipment);
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var equipment = await _context.Get(id);
            if (equipment == null || _context == null)
            {
                return NotFound();
            }
            return View(equipment);
        }
        [Authorize(Roles = "Арендодатель, Админ, Модератор")]
        // GET: Equipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentModel model)
        {
            var equipment = await _context.Create(model);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        [Authorize(Roles = "Арендодатель, Админ, Модератор")]
        public async Task<IActionResult> Edit(int id)
        {
            var equipment = await _context.Get(id);
            if (equipment == null || _context == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, EquipmentModel model)
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

        // GET: Equipments/Delete/5
        [Authorize(Roles = "Арендодатель, Админ, Модератор")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipment = await _context.Get(id);
            if (equipment == null || _context == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Equipment entity)
        {
            var events = await _context.Delete(entity);
            return RedirectToAction(nameof(Index));
        }
    }
}
