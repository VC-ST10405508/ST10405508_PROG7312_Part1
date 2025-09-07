using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        public string errMsg = "";
        public string successMsg = "";

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            errMsg = "Invalid username or password";
            try
            {
                if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
                {
                    var user = await _userInterface.Login(username);
                    if (user != null)
                    {
                        var passwordHasher = new PasswordHasher<User>();
                        var verificationResult = passwordHasher.VerifyHashedPassword(null, user.password, password);

                        if (verificationResult == PasswordVerificationResult.Success)
                        {
                            //using httpcontext session to keep track of which user is signed in (Anderson, Larkin & LaRose, 2025):
                            HttpContext.Session.SetString("uID", user.userId);
                            ViewBag.successMsg = "Successfully logged in";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.errorMsg = errMsg;
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.errorMsg = errMsg;
                        return View();
                    }

                }
                else
                {
                    ViewBag.errorMsg = "All Fields are required";
                    return View();
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                ViewBag.errorMsg = errMsg;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            ViewBag.errorMsg = null;
            ViewBag.successMsg = null;
            //getting the current amount of users so that we can see make a unique id
            var userID = "U" +_userInterface.GetCount();
            User newUser = new User();

            //setting the data that will be saved to the database
            try
            {
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
                {
                    if (ValidPassword(password))
                    {
                        if (ValidEmail(email))
                        {
                            newUser.username = name;
                            newUser.email = email;
                            newUser.password = password;
                            newUser.userId = userID;
                            newUser.role = "User";

                            _userInterface.Add(newUser);

                            ViewBag.successMsg = "You have successfully created an account";
                            //using httpcontext session to keep track of which user is signed in (Anderson, Larkin & LaRose, 2025):
                            HttpContext.Session.SetString("uID", userID);

                            RedirectToPage("Index", "Home");
                        }
                        else
                        {
                            ViewBag.errorMsg = "Please enter a valid email";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.errorMsg = "password needs to be at least 8 characters long, contain special character, number/s, upper and lower cases letters";
                        return View();
                    }
                }
                else
                {
                    ViewBag.errorMsg = "All fields are required.";
                    return View();
                }
            }
            catch (Exception ex) 
            {
                ViewBag.errorMsg = "Please contact support - an unexpected error occured: " + ex.Message;
                return View();
            }


            return View();
        }
        private Boolean ValidPassword(string password)
        {
            // Define the flag as false by default
            Boolean flag = false;

            // Check if password length is at least 8 characters
            if (password.Length >= 8)
            {
                // Check if password contains at least one uppercase letter, one lowercase letter, one digit, and one special character
                bool hasUpper = password.Any(char.IsUpper);
                bool hasLower = password.Any(char.IsLower);
                bool hasDigit = password.Any(char.IsDigit);
                bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

                // If all conditions are met, set flag to true
                if (hasUpper && hasLower && hasDigit && hasSpecialChar)
                {
                    flag = true;
                }
            }

            return flag;
        }


        private Boolean ValidEmail(string email)
        {
            Boolean validEmail = false;

            // Check if email contains '@' and '.' with basic validation
            if (!string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains("."))
            {
                // Simple additional check for email format - must contain at least one '@' and '.' after '@'
                int atIndex = email.IndexOf('@');
                int dotIndex = email.IndexOf('.', atIndex);

                // Ensure the dot comes after the '@' and there's at least one character before '@' and after '.'
                if (atIndex > 0 && dotIndex > atIndex + 1 && dotIndex < email.Length - 1)
                {
                    validEmail = true;
                }
            }

            return validEmail;
        }

    }
}
//Reference list:

//Anderson, R., Larkin, K. And LaRose, D. 2025. Session and state management in ASP.NET Core, 24 April 2025. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0 [Accessed 6 September 2025].
