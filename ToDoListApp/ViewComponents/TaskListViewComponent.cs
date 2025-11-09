using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Data;
using ToDoListApp.Models;
using System.Linq;

namespace ToDoListApp.ViewComponents
{
    public class TaskListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TaskListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Preluăm toate task-urile din baza de date
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }
    }
}
