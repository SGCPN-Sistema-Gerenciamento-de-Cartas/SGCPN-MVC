using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGCPN.Models;
using SGCPN.Validators;

namespace SGCPN.Controllers
{
    public class PatronController : Controller
    {
        private IValidator<Patron> _patronValidator;

        private readonly SGCPNContext _context;

        public PatronController(SGCPNContext context, IValidator<Patron> patronValidator)
        {
            _context = context;
            _patronValidator = patronValidator;
        }

        // GET: Patron
        public async Task<IActionResult> Index()
        {
            return _context.Patron != null ?
                          View(await _context.Patron.ToListAsync()) :
                          Problem("Entity set 'SGCPNContext.Patron'  is null.");
        }

        // GET: Patron/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Patron == null)
            {
                return NotFound();
            }

            var Patron = await _context.Patron
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Patron == null)
            {
                return NotFound();
            }

            return View(Patron);
        }

        // GET: Patron/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patron/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatronName,Password,RgOrCnpj,Email,Sex,Telephone,Cellphone,Address,County,State,AddressComplement,ZipCode")] Patron Patron)
        {
            ValidationResult result = await _patronValidator.ValidateAsync(Patron);

            if (result.IsValid)
            {
                _context.Add(Patron);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            result.AddToModelState(this.ModelState);
            return View(Patron);
        }

        // GET: Patron/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Patron == null)
            {
                return NotFound();
            }

            var Patron = await _context.Patron.FindAsync(id);
            if (Patron == null)
            {
                return NotFound();
            }
            return View(Patron);
        }

        // POST: Patron/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatronName,Password,RgOrCnpj,Email,Sex,Telephone,Cellphone,Address,County,State,AddressComplement,ZipCode")] Patron Patron)
        {
            if (id != Patron.Id)
            {
                return NotFound();
            }

            ValidationResult result = await _patronValidator.ValidateAsync(Patron);

            if (result.IsValid)
            {
                try
                {
                    _context.Update(Patron);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatronExists(Patron.Id))
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
            result.AddToModelState(this.ModelState);
            return View(Patron);
        }

        // GET: Patron/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Patron == null)
            {
                return NotFound();
            }

            var Patron = await _context.Patron
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Patron == null)
            {
                return NotFound();
            }

            return View(Patron);
        }

        // POST: Patron/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Patron == null)
            {
                return Problem("Entity set 'SGCPNContext.Patron'  is null.");
            }
            var Patron = await _context.Patron.FindAsync(id);
            if (Patron != null)
            {
                _context.Patron.Remove(Patron);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatronExists(int id)
        {
            return _context.Patron.Any(e => e.Id == id);
        }


    }


}


