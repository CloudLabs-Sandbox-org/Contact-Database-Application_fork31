using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            var users = userlist;
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, pass it to the Details view
            if (user != null)
            {
                return View(user);
            }

            // If no user is found, return a HttpNotFoundResult
            return HttpNotFound();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Add the new user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, pass it to the Edit view
            if (user != null)
            {
                return View(user);
            }

            // If no user is found, return a HttpNotFoundResult
            return HttpNotFound();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Retrieve the user from the userlist based on the provided ID
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, update its information with the new values
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If no user is found, return a HttpNotFoundResult
            return HttpNotFound();
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, pass it to the Delete view
            if (user != null)
            {
                return View(user);
            }

            // If no user is found, return a HttpNotFoundResult
            return HttpNotFound();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, remove it from the userlist
            if (user != null)
            {
                userlist.Remove(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If no user is found, return a HttpNotFoundResult
            return HttpNotFound();
        }
        // GET: User/Search
        public ActionResult Search(string searchTerm)
        {
            // Search for users in the userlist based on the provided search term
            var users = userlist.Where(u => u.Name.Contains(searchTerm) || u.Email.Contains(searchTerm)).ToList();

            // Pass the search results to the Search view
            return View(users);
        }
    }
}
