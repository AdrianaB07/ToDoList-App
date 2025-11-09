using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acțiunea GET: Returnează un view component (UI)
        public IActionResult AddTask()
        {
            return ViewComponent("AddTask");
        }

        // Acțiunea POST: Adaugă task-ul în baza de date
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                var task = new ToDoTask { Title = title, IsCompleted = false };
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted; // Alternăm statusul
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
