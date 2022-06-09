using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MikoBussBusinessLayer;
using MikoBussEntityLayer;
using MikoBussUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MikoBussUI.Controllers
{
    public class HomeController : Controller
    {
        private IGuzergahService _guzergahService;
        private ICityService _cityService;
        private ITicketService  _ticketService;

        public HomeController(ICityService cityService, IGuzergahService guzergahService, ITicketService ticketService)
        {
            _cityService = cityService;
            _guzergahService = guzergahService;
            _ticketService = ticketService;

            
        }
        public IActionResult Index()
        {
            var sehirGuzergah = new SehirGuzergahModel()
            {
                Cities = _cityService.GetAll()
            };
            ViewBag.Sehirler = new SelectList(sehirGuzergah.Cities, "CityId", "CiytName");
            var seats = new List<int>() {1,2,3,4,5};
            ViewBag.Seat = new SelectList(seats);
            return View(sehirGuzergah);

        }
        [HttpPost]
        public IActionResult Index(string nereden, string nereye, DateTime tarih, string SeatNo) //??????*
        {
           
            var sehirler = new SehirGuzergahModel()
            {
                Cities = _cityService.GetAll(),
                Guzergahs = _guzergahService.GetBySelectedGuzergahList(nereden,nereye,tarih)
            };
            ViewBag.Sehirler = new SelectList(sehirler.Cities, "CityId", "CiytName");
            return View(sehirler);
        }
    
        public IActionResult BiletAl(int GuzergahId)
        {
            var guzergah = _guzergahService.GetById(GuzergahId);
            SehirGuzergahModel sehirGuzergah = new SehirGuzergahModel()
            {
                GuzergahId=GuzergahId,
                GuzergahStart = guzergah.GuzergahStart,
                GuzergahEnd = guzergah.GuzergahEnd,
                GuzargahFiyat =guzergah.GuzargahFiyat,
                GuzergahTarihi =guzergah.GuzergahTarihi
            };
            
            return View(sehirGuzergah);
            
        }

        [HttpPost]
        public IActionResult BiletAl(SehirGuzergahModel model)
        {
            var guzergah = _guzergahService.GetById(model.GuzergahId);
            var ticket = new Ticket()
            {
                TicketName = model.TicketName,
                TicketSurname = model.TicketSurname,
                TicketMail = model.TicketMail,
                TicketNereden = guzergah.GuzergahStart,
                TicketNereye = guzergah.GuzergahEnd,
                TicketPrice = guzergah.GuzargahFiyat,
                TicketSeatNo = model.TicketSeatNo,
                GuzergahId = model.GuzergahId
            };
            _ticketService.Create(ticket);
            return RedirectToAction("Basarılı");
        }
        public IActionResult Basarılı()
        {
            return View();
        }
        
        
       
    }
}
