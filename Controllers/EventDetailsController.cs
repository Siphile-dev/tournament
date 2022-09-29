using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TournamentsWebApplication.Data;
using TournamentsWebApplication.Models;
using TournamentsWebApplication.ViewModels;

namespace TournamentsWebApplication.Controllers
{
    public class EventDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventDetails
        public async Task<IActionResult> Index(int id)
        {

            EventEventdetailsViewModel edcViewModel = new EventEventdetailsViewModel()
            {

                Event = (Event)_context.Event.Find(id),
                EventDetail = _context.EventDetail.ToList().Where(e => e.EventID == id).OrderBy(e => e.EventDetailID),
                FirstTimer = false
            

            };
            //var applicationDbContext = _context.EventDetail.Include(e => e.FK_EventDetailStatusID).Include(e => e.FK_EventID);



            //ViewData["EventDetailStatusID"] = new SelectList(_context.Set<EventDetailStatus>(), "EventDetailStatusID", "EventDetailStatusName");
            return View(edcViewModel);
        }

        // GET: EventDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetail
                .Include(e => e.FK_EventDetailStatusID)
                .Include(e => e.FK_EventID)
                .FirstOrDefaultAsync(m => m.EventDetailID == id);
            if (eventDetail == null)
            {
                return NotFound();
            }
            ViewData["EventDetailStatusID"] = new SelectList(_context.Set<EventDetailStatus>(), "EventDetailStatusID", "EventDetailStatusName", eventDetail.EventDetailStatusID);
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventID", eventDetail.EventID);
            return View(eventDetail);
        }

        // GET: EventDetails/Create
        public IActionResult Create()
        {

            //EventEventDetailStatusViewModel edcViewModel = new EventDetailCreateViewModel()
            //{
            //    Event = repositorywrapper.Event.GetById(id),
            //    EventDetailStatus = repositorywrapper.EventDetailStatus.FindAll().ToList()

            //};

            //ViewBag.Title = "Create Event Detail";
            //ViewBag.StatusList = new SelectList(repositorywrapper.EventDetailStatus.FindAll().ToList(), "EventDetailStatusID", "EventDetailStatusName");


            //return View(edcViewModel);



            ViewData["EventDetailStatusID"] = new SelectList(_context.Set<EventDetailStatus>(), "EventDetailStatusID", "EventDetailStatusName");
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventID");
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventDetailID,EventID,EventDetailStatusID,EventDetailName,EventDetailNumber,EventDetailOdd,FinishingPosition,FirstTimer")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EventDetailStatusID"] = new SelectList(_context.Set<EventDetailStatus>(), "EventDetailStatusID", "EventDetailStatusName", eventDetail.FK_EventDetailStatusID);
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventID", eventDetail.EventID);
            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetail.FindAsync(id);
            if (eventDetail == null)
            {
                return NotFound();
            }
            ViewData["EventDetailStatusID"] = new SelectList(_context.Set<EventDetailStatus>(), "EventDetailStatusID", "EventDetailStatusName", eventDetail.EventDetailStatusID);
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventID", eventDetail.EventID);
            return View(eventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventDetailID,EventID,EventDetailStatusID,EventDetailName,EventDetailNumber,EventDetailOdd,FinishingPosition,FirstTimer")] EventDetail eventDetail)
        {
            if (id != eventDetail.EventDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventDetailExists(eventDetail.EventDetailID))
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
            ViewData["EventDetailStatusID"] = new SelectList(_context.Set<EventDetailStatus>(), "EventDetailStatusID", "EventDetailStatusID", eventDetail.EventDetailStatusID);
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventID", eventDetail.EventID);
            return View(eventDetail);
        }

        // GET: EventDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetail
                .Include(e => e.FK_EventDetailStatusID)
                .Include(e => e.FK_EventID)
                .FirstOrDefaultAsync(m => m.EventDetailID == id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return View(eventDetail);
        }

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDetail = await _context.EventDetail.FindAsync(id);
            _context.EventDetail.Remove(eventDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventDetailExists(int id)
        {
            return _context.EventDetail.Any(e => e.EventDetailID == id);
        }
    }
}
