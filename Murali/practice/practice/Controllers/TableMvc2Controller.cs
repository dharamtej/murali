using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practice.Data;
using practice.Models;

namespace practice.Controllers
{
    public class TableMvc2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableMvc2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableMvc2
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableMvc2.ToListAsync());
        }

        // GET: TableMvc2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableMvc2 = await _context.TableMvc2
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (tableMvc2 == null)
            {
                return NotFound();
            }

            return View(tableMvc2);
        }

        // GET: TableMvc2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableMvc2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,PhoneNumber,Loc")] TableMvc2 tableMvc2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableMvc2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableMvc2);
        }

        // GET: TableMvc2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableMvc2 = await _context.TableMvc2.FindAsync(id);
            if (tableMvc2 == null)
            {
                return NotFound();
            }
            return View(tableMvc2);
        }

        // POST: TableMvc2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,PhoneNumber,Loc")] TableMvc2 tableMvc2)
        {
            if (id != tableMvc2.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableMvc2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableMvc2Exists(tableMvc2.AutoId))
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
            return View(tableMvc2);
        }

        // GET: TableMvc2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableMvc2 = await _context.TableMvc2
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (tableMvc2 == null)
            {
                return NotFound();
            }

            return View(tableMvc2);
        }

        // POST: TableMvc2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableMvc2 = await _context.TableMvc2.FindAsync(id);
            _context.TableMvc2.Remove(tableMvc2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableMvc2Exists(int id)
        {
            return _context.TableMvc2.Any(e => e.AutoId == id);
        }
    }
}
