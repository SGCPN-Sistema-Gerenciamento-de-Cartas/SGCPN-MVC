using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGCPN.Models;
using SGCPN.Validators;

namespace SGCPN.Controllers
{
    public class InstitutionController : Controller
    {
        private IValidator<Institution> _institutionValidator;

        private readonly SGCPNContext _context;

        public InstitutionController(SGCPNContext context,IValidator<Institution> institutionValidator)
        {
            _context = context;
            _institutionValidator = institutionValidator;
        }

        // GET: Institution
        public async Task<IActionResult> Index()
        {
            return _context.Institution != null ?
                          View(await _context.Institution.ToListAsync()) :
                          Problem("Entity set 'SGCPNContext.Intitution'  is null.");
        }

        // GET: Institution/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Institution == null)
            {
                return NotFound();
            }

            var institution = await _context.Institution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        // GET: Institution/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institution/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InstitutionName,Password,Cnpj,Email,ResponsibleName,Telephone,Cellphone,Address,County,State,AddressComplement,ZipCode,Description")] Institution institution)
        {
            ValidationResult result = await _institutionValidator.ValidateAsync(institution);

            if (result.IsValid)
            {
                _context.Add(institution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            result.AddToModelState(this.ModelState);
            return View(institution);
        }

        // GET: Institution/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Institution == null)
            {
                return NotFound();
            }

            var institution = await _context.Institution.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }
            return View(institution);
        }

        // POST: Institution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InstitutionName,Password,Cnpj,Email,ResponsibleName,Telephone,Cellphone,Address,County,State,AddressComplement,ZipCode,Description")] Institution institution)
        {
            if (id != institution.Id)
            {
                return NotFound();
            }

            ValidationResult result = await _institutionValidator.ValidateAsync(institution);

            if (result.IsValid)
            {
                try
                {
                    _context.Update(institution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionExists(institution.Id))
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
            return View(institution);
        }

        // GET: Institution/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Institution == null)
            {
                return NotFound();
            }

            var institution = await _context.Institution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        // POST: Institution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Institution == null)
            {
                return Problem("Entity set 'SGCPNContext.Institution'  is null.");
            }
            var institution = await _context.Institution.FindAsync(id);
            if (institution != null)
            {
                _context.Institution.Remove(institution);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionExists(int id)
        {
          return _context.Institution.Any(e => e.Id == id);
        }
    }
}
