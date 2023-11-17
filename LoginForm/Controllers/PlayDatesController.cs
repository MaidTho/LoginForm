﻿using System;
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
            string connectionString = "Server=TOMSLAPTOP\\SQLEXPRESS;Database=PuppyDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to delete older records

                string sqlQuery = @"
                    DELETE FROM [PuppyDB].[dbo].[PlayDate]
                    WHERE DateCreated < DATEADD(DAY, -7, GETDATE())";                // <--- CHANGE SECOND TO MINUTE, HOUR, DAY for result.

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
            if (id != playdateVM.ID)
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
                    if (!await PlaydateRepository.Exists(playdateVM.ID))
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
