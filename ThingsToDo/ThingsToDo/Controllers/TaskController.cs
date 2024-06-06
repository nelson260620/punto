using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ListModel = ThingsToDo.Models.List;

namespace ThingsToDo.Controllers
{
    public class TaskController : Controller
    {
        private static List<ListModel> lists = new List<ListModel>();
        public IActionResult Index()
        {
            return View(lists); 
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTask(ListModel list)
        {
            lists.Add(list); 
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTask(string id)
        {
         if (id != null)
         {
            if (int.TryParse(id, out int listId))
            {
              ListModel listToRemove = lists.Find(l => l.Id == listId);
              if (listToRemove != null)
              {
                 lists.Remove(listToRemove); // Elimina la lista de la lista de listas
              }
            }
         }

         return RedirectToAction(nameof(Index)); // Redirige al método Index para volver a cargar la vista actualizada
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkAsCompleted(int id)
        {
            ListModel listToComplete = lists.Find(l => l.Id == id);
            if (listToComplete != null)
            {
                listToComplete.IsCompleted = true; 
            }
            return RedirectToAction(nameof(Index)); 
        }
    }
}
