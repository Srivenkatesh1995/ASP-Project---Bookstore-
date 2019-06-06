using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANVBookstore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ANVBookstore.Controllers
{
    public class AdminController : Controller
    {
        private readonly Team117DBContext _context;

        public AdminController(Team117DBContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var team117DBContext = _context.Textbook.Include(t => t.Course);
            return View(await team117DBContext.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return Redirect(nameof(Index));
            }

            var textbook = await _context.Textbook
                .Include(t => t.Course)
                .FirstOrDefaultAsync(m => m.TextbookId == id);
            if (textbook == null)
            {
                return Redirect(nameof(Index));
            }

            return View(textbook);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course.OrderBy(t => t.CourseId), "CourseId", "CourseId");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TextbookId,Name,Author,Price,CourseId")] Textbook textbook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(textbook);
                await _context.SaveChangesAsync();
                TempData["message"] = $"{textbook.Name} has been added";
                return RedirectToAction(nameof(Index));
                
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", textbook.CourseId);
            return View(textbook);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var textbook = await _context.Textbook.FindAsync(id);
            if (textbook == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", textbook.CourseId);
            return View(textbook);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TextbookId,Name,Author,Price,CourseId")] Textbook textbook)
        {
            if (id != textbook.TextbookId)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(textbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["message"] = $"{textbook.Name} update Failed";
                    return RedirectToAction(nameof(Index));
                }
                TempData["message"] = $"{textbook.Name} update Completed";
                return RedirectToAction(nameof(Index));

            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", textbook.CourseId);
            return View(textbook);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var textbook = await _context.Textbook
                .Include(t => t.Course)
                .FirstOrDefaultAsync(m => m.TextbookId == id);
            if (textbook == null)
            {
                return NotFound();
            }

            return View(textbook);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var textbook = await _context.Textbook.FindAsync(id);
            _context.Textbook.Remove(textbook);
            await _context.SaveChangesAsync();
            TempData["message"] = $"{textbook.Name} Deletion Completed";
            return RedirectToAction(nameof(Index));
           
        }

        private bool TextbookExists(int id)
        {
            return _context.Textbook.Any(e => e.TextbookId == id);
        }

        public IActionResult Admin_Login(string returnURL)
        {
            // if returnURL is null or empty, it is set to "/" (i.e., Home/Index)

            returnURL = String.IsNullOrEmpty(returnURL) ? "~/" : returnURL;

            // create a new instance of LoginInput and pass it to the Login View

            return View(new LoginInput { ReturnURL = returnURL });
        }
        public async Task<RedirectToActionResult> Admin_Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }


        // Post action (when user submits the Login form)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Admin_Login([Bind("UserName,UserPassword,ReturnURL")] LoginInput loginInput)
        {
            if (ModelState.IsValid)
            {
                // check if login credentials are valid

                var aUser = await _context.Admin.FirstOrDefaultAsync(u => u.UserName == loginInput.UserName && u.Password == loginInput.UserPassword);

                // if valid

                if (aUser != null)
                {
                    // From Microsoft documentation - "A claim is a statement about a subject by an issuer. Claims represent attributes of the subject that are useful in the context of authentication and authorization operations"

                    // Examples of claims would be data on a Driver's License card (i.e., name, date of birth)

                    var claims = new List<Claim>();

                    // the Type property can be used to store information about the claim

                    claims.Add(new Claim(ClaimTypes.Name, aUser.UserName));
                    claims.Add(new Claim(ClaimTypes.Sid, aUser.AdminId.ToString()));

                    // role(s) are stored as a comma-delimited list in the "UserRoles" column in the LoginInfo table

                    //    string[] roles = aUser.UserRoles.Split(",");


                    claims.Add(new Claim(ClaimTypes.Role, 1.ToString()));


                    // From Microsoft documentation - "The ClaimsIdentity class is a concrete implementation of a claims-based identity; that is, an identity described by a collection of claims."

                    // a collection of claims can be used to create a ClaimsIndentity along with the authentication scheme (in this case, cookie-based authentication)

                    // Example of identity would be a Driver's License card

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // multiple identities can be stored in a ClaimsPrincipal

                    // Example, a user's multiple identities (driver's license, employee ID, passport) can make up a ClaimsPrincipal

                    var principal = new ClaimsPrincipal(identity);

                    // the SignInAsync method issues the authentication cookie to the user

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // return the user to the View they were originally trying to reach or Home/Index

                    return Redirect(loginInput?.ReturnURL ?? "Index");
                }

                // if credentials are not valid

                else
                {
                    ViewData["message"] = "Invalid credentials";
                }
            }

            // return user to Login View

            return View(loginInput);
        }
    }
}
