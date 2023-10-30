using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoginForm.Data;
using LoginForm.Models;
using AutoMapper;
using LoginForm.Contracts;

namespace LoginForm.Controllers
{
    public class PlayDatesController : Controller
    {
        private readonly IPlaydateRepository PlaydateRepository;
        private readonly IMapper mapper;

        public PlayDatesController(IPlaydateRepository PlayDateRepository, IMapper mapper)
        {
            this.PlaydateRepository = PlayDateRepository;
            this.mapper = mapper;
        }

        // GET: Playdates
        public async Task<IActionResult> Index()
        {
            var PlayDates = mapper.Map<List<PlayDateVM>>(await PlaydateRepository.GetAllAsync());
            return View(PlayDates);
        }

        // GET: Playdates/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            var PlayDate = await PlaydateRepository.GetAsync(Id);
            if (PlayDate == null)
            {
                return NotFound();
            }
            var PlayDateVM = mapper.Map<PlayDateVM>(PlayDate);
            return View(PlayDate);
        }

        // GET: Playdates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playdates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayDateVM playdateVM)
        {
            if (ModelState.IsValid)
            {
                var PlayDate = mapper.Map<PlayDate>(playdateVM);
                await PlaydateRepository.AddAsync(PlayDate);
                return RedirectToAction(nameof(Index));
            }
            return View(playdateVM);
        }

        // GET: Playdates/Edit/5
        public async Task<IActionResult> Edit(int? ID)
        {
            var playdate = await PlaydateRepository.GetAsync(ID);
            if (playdate == null)
            {
                return NotFound();
            }
            return View(playdate);
        }

        // POST: Playdates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreatorsName,PlaydateAccepted,Id,DateCreated,DateOfPlaydate")] PlayDateVM playdateVM)
        {
            if (id != playdateVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var PlayDate = mapper.Map<PlayDate>(playdateVM);
                    await PlaydateRepository.AddAsync(PlayDate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PlaydateRepository.Exists(playdateVM.Id))
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
            return View(playdateVM);
        }
        //Post:Platdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await PlaydateRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // private bool PlaydateExists(int id)
        // {
        //    return (_context.Playdates?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
