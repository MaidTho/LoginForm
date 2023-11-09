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
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Core.Types;

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

            // Start the recurring cleanup task on controller instantiation
            StartCleanupTask();
        }

        private void StartCleanupTask()
        {
            // Set up a timer to execute the cleanup task every 10 minutes
           var timer = new System.Threading.Timer(CleanupTask, null, TimeSpan.Zero, TimeSpan.FromMinutes(10));
       }

        private void CleanupTask(object state)
        {
            // Your SQL cleanup logic here
            string connectionString = "Server=TOMSLAPTOP\\SQLEXPRESS;Database=PlayDatesDB2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to delete older records

                string sqlQuery = @"
                    DELETE FROM [PlayDatesDB2].[dbo].[PlayDate]
                    WHERE DateForPlayDate < DATEADD(MINUTE, -1, GETDATE())";                // <--- CHANGE SECOND TO MINUTE, HOUR, DAY for result.

                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
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
            var playDateVM = mapper.Map<PlayDateVM>(PlayDate);
            return View(playDateVM);

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


        public async Task<IActionResult> Create(PlayDateVM playDateVM)
        {
            if (ModelState.IsValid)
            {
                var PlayDate = mapper.Map<PlayDate>(playDateVM);
                PlayDate.DateCreated = DateTime.Now; // Set the creation date/time

                PlayDate.DateForPlayDate = playDateVM.DateForPlayDate; // Assuming this is the desired DateForPlayDate property

                await PlaydateRepository.AddAsync(PlayDate);
                return RedirectToAction(nameof(Index));
            }
            return View(playDateVM);
        }

 //       public async Task<IActionResult> Create(PlayDateVM playDateVM)
 //       {
 //           if (ModelState.IsValid)
 //           {
 //               var PlayDate = mapper.Map<PlayDate>(playDateVM);
 //              await PlaydateRepository.AddAsync(PlayDate);
 //               return RedirectToAction(nameof(Index));
 //          }
 //          return View(playDateVM);
 //      }

        // GET: Playdates/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            var playdate = await PlaydateRepository.GetAsync(Id);
            if (playdate == null)
            {
                return NotFound();
            }
            
            var playDateVM = mapper.Map<PlayDateVM>(playdate);
            return View(playDateVM);
        }

        // POST: Playdates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlayDateVM playDateVM)
        {
            if (id != playDateVM.Id)
            {
                return NotFound();
            }

            var playDate = await PlaydateRepository.GetAsync(id);

            if (playDate == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mapper.Map(playDateVM, playDate);
                    await PlaydateRepository.UpdateAsync(playDate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PlaydateRepository.Exists(playDateVM.Id))
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
            return View(playDateVM);
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

        public async Task<IActionResult> UserDisplay(int? Id)
        
            {
                var PetUser = mapper.Map<List<ApplicationUserVM>>(await PlaydateRepository.GetAllAsync());
                return View(PetUser);
            }
        
       

}
}
