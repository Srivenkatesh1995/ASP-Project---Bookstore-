using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ANVBookstore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ANVBookstore.Controllers
{
    public class CustController : Controller
    {

        private readonly Team117DBContext _context;

        public CustController(Team117DBContext context)
        {
            _context = context;
        }
        public IActionResult Login(string returnURL)
        {
            // if returnURL is null or empty, it is set to "/" (i.e., Home/Index)

            returnURL = String.IsNullOrEmpty(returnURL) ? "~/" : returnURL;

            // create a new instance of LoginInput and pass it to the Login View

            return View(new CustomerInput { ReturnURL = returnURL });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerLogin([Bind("CustomerUser,CustomerPass,ReturnURL")] CustomerInput custInput)
        {
            if (ModelState.IsValid)
            {
                // check if login credentials are valid

                var aUser = await _context.Customer.FirstOrDefaultAsync(u => u.UserName == custInput.CustomerUser && u.UserPassword == custInput.CustomerPass);

                // if valid

                if (aUser != null)
                {
                    // From Microsoft documentation - "A claim is a statement about a subject by an issuer. Claims represent attributes of the subject that are useful in the context of authentication and authorization operations"

                    // Examples of claims would be data on a Driver's License card (i.e., name, date of birth)

                    var claims = new List<Claim>();

                    // the Type property can be used to store information about the claim

                    claims.Add(new Claim(ClaimTypes.Name, aUser.UserName));
                    claims.Add(new Claim(ClaimTypes.Sid, aUser.CustomerId.ToString()));

                    // role(s) are stored as a comma-delimited list in the "UserRoles" column in the LoginInfo table

                    //    string[] roles = aUser.UserRoles.Split(",");


                    claims.Add(new Claim(ClaimTypes.Role, 5.ToString()));


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

                    return Redirect(custInput?.ReturnURL ?? "/");
                }

                // if credentials are not valid

                else
                {
                    ViewData["message"] = "Invalid credentials";
                }
            }

            // return user to Login View

            return View();
        }
    }
}