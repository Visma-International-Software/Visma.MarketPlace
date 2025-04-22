namespace Visma.MarketPlace.Web.Controllers.Api.Internal
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Visma.MarketPlace.Bootstrapping.DependencyInjection.Autofac;
    using Visma.MarketPlace.Users.Entities;
    using Visma.MarketPlace.Users.Querries;
    using Visma.MarketPlace.Users.Transactions;

    public class UsersController : Controller
    {
        [Dependency]
        public required IGetAllUsers GetAllUsers { private get; init; }

        [Dependency]
        public required IAddUser AddUser { private get; init; }

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
            User user = new User()
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DirectManagerId = Guid.Parse("B38249BD-087A-40D7-840A-77D78175548A"),
                Id = Guid.NewGuid(),
                LastName = "Szasz",
                FirstName = "Cris",
                HiringLegalUnitId = Guid.Parse("58796ef4-cf00-4841-bfcd-9ceb33f35dc6"),
                IsITResponsible = false
            };

            user = AddUser.Execute(user);

            return View(user);
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
