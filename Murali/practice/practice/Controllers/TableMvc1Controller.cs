using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practice.Data;
using practice.Models;
using X.PagedList;

namespace practice.Controllers
{
    public class TableMvc1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableMvc1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableMvc1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TableMvc1.Include(t => t.tableMvc2);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult RawQuery(int id)
        {
            var sql = "select * from TableMvc1 where AutoId = {0}";
            var data = _context.TableMvc1.FromSqlRaw(sql, id).FirstOrDefault();
            return View(data);
        }
        //Paging
        //public async Task<IActionResult> paging(int ? page , int? pagesize)
        //{
        //    if(!page.HasValue)
        //    {
        //        page = 1;
        //    }
        //    if(!pagesize.HasValue)
        //    {
        //        pagesize = 3;
        //    }
        //    var data = await _context.TableMvc1.ToPagedListAsync(page.Value,pagesize.Value);
        //    return View(data);
        //}

        // GET: TableMvc1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableMvc1 = await _context.TableMvc1
                .Include(t => t.tableMvc2)
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (tableMvc1 == null)
            {
                return NotFound();
            }

            return View(tableMvc1);
        }

        // GET: TableMvc1/Create
        public IActionResult Create()
        {
            ViewData["AutoId"] = new SelectList(_context.Set<TableMvc2>(), "AutoId", "AutoId");
            return View();
        }

        // POST: TableMvc1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,FirstName,LastName,EmailId")] TableMvc1 tableMvc1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableMvc1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoId"] = new SelectList(_context.Set<TableMvc2>(), "AutoId", "AutoId", tableMvc1.AutoId);
            return View(tableMvc1);
        }

        // GET: TableMvc1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableMvc1 = await _context.TableMvc1.FindAsync(id);
            if (tableMvc1 == null)
            {
                return NotFound();
            }
            ViewData["AutoId"] = new SelectList(_context.Set<TableMvc2>(), "AutoId", "AutoId", tableMvc1.AutoId);
            return View(tableMvc1);
        }

        // POST: TableMvc1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,FirstName,LastName,EmailId")] TableMvc1 tableMvc1)
        {
            if (id != tableMvc1.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableMvc1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableMvc1Exists(tableMvc1.AutoId))
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
            ViewData["AutoId"] = new SelectList(_context.Set<TableMvc2>(), "AutoId", "AutoId", tableMvc1.AutoId);
            return View(tableMvc1);
        }

        // GET: TableMvc1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableMvc1 = await _context.TableMvc1
                .Include(t => t.tableMvc2)
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (tableMvc1 == null)
            {
                return NotFound();
            }

            return View(tableMvc1);
        }

        // POST: TableMvc1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableMvc1 = await _context.TableMvc1.FindAsync(id);
            _context.TableMvc1.Remove(tableMvc1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableMvc1Exists(int id)
        {
            return _context.TableMvc1.Any(e => e.AutoId == id);
        }
    }
}
