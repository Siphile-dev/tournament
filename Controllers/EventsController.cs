using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TournamentsWebApplication.Data;
using TournamentsWebApplication.Models;
using TournamentsWebApplication.ViewModels;

namespace TournamentsWebApplication.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;  
        }

       // [AllowAnonymous]
        // GET: Events
        public async Task<IActionResult> Index(int id)
        {


            EventTourViewModel eventTourViewModel = new EventTourViewModel()
            {
                Tournament = (Tournament)_context.Tournament.Find(id),
                Event = _context.Event.ToList().Where(e => e.TournamentID == id).OrderBy(e => e.EventID),
                AutoClose = false

            };


            return View(eventTourViewModel);

            //string redirectUrl = Url.Action("Refresh");
            //return Json(new { redirectUrl });
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(e => e.FK_TournamentID)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        private object FK_TournamentID(Event arg)
        {
            throw new NotImplementedException();
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["TournamentID"] = new SelectList(_context.Tournament, "TournamentID", "TournamentID");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,TournamentID,EventName,EventNumber,EventDateTime,EventEndDateTime,AutoClose")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["TournamentID"] = new SelectList(_context.Tournament, "TournamentID", "TournamentID", @event.TournamentID);
            return View(@event);
        }
       

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["TournamentID"] = new SelectList(_context.Tournament, "TournamentID", "TournamentID", @event.TournamentID);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,TournamentID,EventName,EventNumber,EventDateTime,EventEndDateTime,AutoClose")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
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
            ViewData["TournamentID"] = new SelectList(_context.Tournament, "TournamentID", "TournamentID", @event.TournamentID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
               .Include(e => e.FK_TournamentID)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventID == id);
        }
    }
}
