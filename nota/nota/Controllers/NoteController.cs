using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using nota.date;

namespace YourAppName.Controllers
{
    public class NoteController : Controller
    {
        private static List<Note> notes = new List<Note>();
        private static List<Category> categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Personal" },
            new Category { Id = 2, Name = "Trabajo" },
            new Category { Id = 3, Name = "Estudio" }
        };

        public ActionResult Index()
        {
            return View(notes);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            note.Id = notes.Count + 1;
            note.CreatedAt = DateTime.Now;
            notes.Add(note);
            return RedirectToAction("Index");
        }
    }
}
