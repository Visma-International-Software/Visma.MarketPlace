namespace Visma.MarketPlace.Web.Controllers.Api.Internal
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac;
    using Visma.MarketPlace.Users.Entities;
    using Visma.MarketPlace.Users.Querries;

    public class UsersController : Controller
    {
        [Dependency]
        public required IGetAllUsers GetAllUsers { private get; init; }

        // GET: Users
        [HttpGet]
        public ActionResult ViewAll()
        {
           List<User> users = GetAllUsers.Execute().ToList<User>();
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ViewAll));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ViewAll));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ViewAll));
            }
            catch
            {
                return View();
            }
        }
    }
}
