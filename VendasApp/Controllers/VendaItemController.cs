using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendasApp.Models;

namespace VendasApp.Controllers
{
    public class VendaItemController : Controller
    {
        private readonly VendasContext _context;

        public VendaItemController(VendasContext context)
        {
            _context = context;
        }

        // GET: VendaItem
        public async Task<IActionResult> Index(long? idVenda)
        {
            ViewData["VendaId"] = idVenda;

            var vendasContext = _context.VendaItens.Include(v => v.Produto).Include(v => v.Venda);

            if (idVenda.HasValue)
            {
                return View(await vendasContext.Where(w => w.VendaId == idVenda).ToListAsync());
            }

            return View(await vendasContext.ToListAsync());
        }

        // GET: VendaItem/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaItem = await _context.VendaItens
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaItem == null)
            {
                return NotFound();
            }

            return View(vendaItem);
        }

        // GET: VendaItem/Create
        public IActionResult Create(long? idVenda)
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id");

            var vendaItem = new VendaItem();

            if (idVenda.HasValue)
            {
                vendaItem.VendaId = idVenda.Value;
            }

            return View(vendaItem);
        }

        // POST: VendaItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,VendaId,Quantidade,Valor,Desconto")] VendaItem vendaItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendaItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", vendaItem.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "Id", "Id", vendaItem.VendaId);
            return View(vendaItem);
        }

        // GET: VendaItem/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaItem = await _context.VendaItens.FindAsync(id);
            if (vendaItem == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", vendaItem.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "Id", "Id", vendaItem.VendaId);
            return View(vendaItem);
        }

        // POST: VendaItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ProdutoId,VendaId,Quantidade,Valor,Desconto")] VendaItem vendaItem)
        {
            if (id != vendaItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaItemExists(vendaItem.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", vendaItem.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "Id", "Id", vendaItem.VendaId);
            return View(vendaItem);
        }

        // GET: VendaItem/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaItem = await _context.VendaItens
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaItem == null)
            {
                return NotFound();
            }

            return View(vendaItem);
        }

        // POST: VendaItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vendaItem = await _context.VendaItens.FindAsync(id);
            _context.VendaItens.Remove(vendaItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaItemExists(long id)
        {
            return _context.VendaItens.Any(e => e.Id == id);
        }
    }
}
