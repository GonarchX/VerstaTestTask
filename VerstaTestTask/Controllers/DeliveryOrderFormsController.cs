using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerstaTestTask.Data;
using VerstaTestTask.Models;

namespace VerstaTestTask.Controllers
{
    public class DeliveryOrderFormsController : Controller
    {
        private readonly VerstaTestTaskContext _context;

        public DeliveryOrderFormsController(VerstaTestTaskContext context)
        {
            _context = context;
        }

        // GET: DeliveryOrderForms
        public async Task<IActionResult> Index()
        {

            return _context.DeliveryOrderForm != null ?
                        View(await _context.DeliveryOrderForm.ToListAsync()) :
                        Problem("Entity set 'VerstaTestTaskContext.DeliveryOrderForm'  is null.");
        }

        // GET: DeliveryOrderForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeliveryOrderForm == null)
            {
                return NotFound();
            }

            var deliveryOrderForm = await _context.DeliveryOrderForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryOrderForm == null)
            {
                return NotFound();
            }

            return View(deliveryOrderForm);
        }

        // GET: DeliveryOrderForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryOrderForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenderCity,SenderAddress,RecipientCity,RecipientAddress,CargoWeight,CargoPickupDate")] DeliveryOrderForm deliveryOrderForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryOrderForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryOrderForm);
        }

        // GET: DeliveryOrderForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeliveryOrderForm == null)
            {
                return NotFound();
            }

            var deliveryOrderForm = await _context.DeliveryOrderForm.FindAsync(id);
            if (deliveryOrderForm == null)
            {
                return NotFound();
            }
            return View(deliveryOrderForm);
        }

        // POST: DeliveryOrderForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenderCity,SenderAddress,RecipientCity,RecipientAddress,CargoWeight,CargoPickupDate")] DeliveryOrderForm deliveryOrderForm)
        {
            if (id != deliveryOrderForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryOrderForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryOrderFormExists(deliveryOrderForm.Id))
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
            return View(deliveryOrderForm);
        }

        // GET: DeliveryOrderForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeliveryOrderForm == null)
            {
                return NotFound();
            }

            var deliveryOrderForm = await _context.DeliveryOrderForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryOrderForm == null)
            {
                return NotFound();
            }

            return View(deliveryOrderForm);
        }

        // POST: DeliveryOrderForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeliveryOrderForm == null)
            {
                return Problem("Entity set 'VerstaTestTaskContext.DeliveryOrderForm'  is null.");
            }
            var deliveryOrderForm = await _context.DeliveryOrderForm.FindAsync(id);
            if (deliveryOrderForm != null)
            {
                _context.DeliveryOrderForm.Remove(deliveryOrderForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryOrderFormExists(int id)
        {
            return (_context.DeliveryOrderForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
