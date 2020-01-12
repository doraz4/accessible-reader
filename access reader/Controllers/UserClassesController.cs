using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using accessreader.Models;

namespace accessreader.Controllers
{
    public class UserClassesController : Controller
    {
        private readonly accessreaderContext _context;

        public UserClassesController(accessreaderContext context)
        {
            _context = context;
        }

        // GET: UserClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserClass.ToListAsync());
        }

        // GET: UserClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClass = await _context.UserClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userClass == null)
            {
                return NotFound();
            }

            return View(userClass);
        }

        // GET: UserClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_name,Password,Id")] UserClass userClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userClass);
        }

        // GET: UserClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClass = await _context.UserClass.FindAsync(id);
            if (userClass == null)
            {
                return NotFound();
            }
            return View(userClass);
        }

        // POST: UserClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_name,Password,Id")] UserClass userClass)
        {
            if (id != userClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserClassExists(userClass.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userClass);
        }

        // GET: UserClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClass = await _context.UserClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userClass == null)
            {
                return NotFound();
            }

            return View(userClass);
        }

        // POST: UserClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userClass = await _context.UserClass.FindAsync(id);
            _context.UserClass.Remove(userClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserClassExists(int id)
        {
            return _context.UserClass.Any(e => e.Id == id);
        }
    }
}
