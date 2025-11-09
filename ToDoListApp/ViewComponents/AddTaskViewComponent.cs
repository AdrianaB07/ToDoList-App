using Microsoft.AspNetCore.Mvc;

namespace ToDoListApp.ViewComponents
{
    public class AddTaskViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
