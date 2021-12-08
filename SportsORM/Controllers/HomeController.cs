using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsORM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // League ViewBags
            ViewBag.WomenLeague = _context.Leagues
                .Where(l => l.Name.Contains("Womens'"))
                .ToList();
            ViewBag.Hockey = _context.Leagues.Where(l => l.Sport.Contains("Hockey")).ToList();
            ViewBag.NoFootball = _context.Leagues.Where(l => !l.Sport.Contains("Football")).ToList();
            ViewBag.Conferences = _context.Leagues.Where(l => l.Name.Contains("Conference")).ToList();
            ViewBag.Atlantic = _context.Leagues.Where(l => l.Name.Contains("Atlantic")).ToList();
            //End League Viewbag

            //Teams ViewBag
            ViewBag.Dallas = _context.Teams.Where(t => t.Location.Contains("Dallas")).ToList();
            ViewBag.Raptors = _context.Teams.Where(t => t.TeamName.Contains("Raptors")).ToList();
            ViewBag.City = _context.Teams.Where(t => t.Location.Contains("City")).ToList();
            ViewBag.StartsWithT = _context.Teams.Where(t => t.TeamName.StartsWith("T")).ToList();
            ViewBag.OrderByCity = _context.Teams.OrderBy(t => t.Location).ToList();
            ViewBag.ReverseByName = _context.Teams.OrderBy(t => t.TeamName).Reverse().ToList();
            //End Teams ViewBag

            //Players ViewBag
            ViewBag.Cooper = _context.Players.Where(p => p.LastName.Contains("Cooper")).ToList();
            ViewBag.Josh = _context.Players.Where(p => p.FirstName.Contains("Joshua")).ToList();
            ViewBag.CooperNoJosh = _context.Players.Where(p => p.LastName.Contains("Cooper") && !p.FirstName.Contains("Joshua")).ToList();
            ViewBag.AlexOrWyatt = _context.Players.Where(p => p.FirstName.Contains("Alexander") || p.FirstName.Contains("Wyatt")).ToList();
            //End Players ViewBag
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}
