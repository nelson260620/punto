using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MyReservation = Reservation.Data.Reservation;

namespace Reservation.Controllers
{
    public class ReservationsController : Controller
    {
        private static List<MyReservation> reservations = new List<MyReservation>();

        public IActionResult Index()
        {
            return View(reservations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MyReservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.Id = reservations.Count + 1;
                reservation.Confirmed = false;
                reservations.Add(reservation);
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        public IActionResult Confirm(int id)
        {
            var reservation = reservations.Find(r => r.Id == id);
            if (reservation != null)
            {
                reservation.Confirmed = true;
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
