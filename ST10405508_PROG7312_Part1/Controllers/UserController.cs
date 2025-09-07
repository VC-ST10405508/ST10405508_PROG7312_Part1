using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ST10405508_PROG7312_Part1.Data;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly Logger<UserController> _logger;
        public string errMsg = "";
        public string successMsg = "";
    
        public UserController(IUserInterface userInterface, Logger<UserController> logger)
        {
            _userInterface = userInterface;
            _logger = logger;
        }
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
            string errMsg = "Invalid username or password";

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    ViewBag.errorMsg = "All fields are required.";
                    return View();
                }

                var user = await _userInterface.Login(username);

                if (user == null)
                {
                    _logger.LogWarning("Failed login attempt for username {Username}", username);
                    ViewBag.errorMsg = errMsg;
                    return View();
                }

                var passwordHasher = new PasswordHasher<User>();
                var verificationResult = passwordHasher.VerifyHashedPassword(user, user.password, password);

                if (verificationResult == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("uID", user.userId);
                    _logger.LogInformation("User {Username} logged in successfully", username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _logger.LogWarning("Failed login attempt for username {Username}", username);
                    ViewBag.errorMsg = errMsg;
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception during login for username {Username}", username);
                ViewBag.errorMsg = "An unexpected error occurred. Please contact support.";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            try
            {
                ViewBag.errorMsg = null;
                ViewBag.successMsg = null;
                //getting the current amount of users so that we can see make a unique id
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    ViewBag.errorMsg = "All fields are required.";
                    return View();
                }

                if (!ValidEmail(email))
                {
                    ViewBag.errorMsg = "Please enter a valid email.";
                    return View();
                }

                if (!ValidPassword(password))
                {
                    ViewBag.errorMsg = "Password must be at least 8 characters long and contain uppercase, lowercase, number, and special character.";
                    return View();
                }


                //setting the data that will be saved to the database
                var userID = "U" + Guid.NewGuid().ToString("N");
                User newUser = new User
                {
                    userId = userID,
                    username = name,
                    email = email,
                    role = "User"
                };

                var passwordHasher = new PasswordHasher<User>();
                newUser.password = passwordHasher.HashPassword(newUser, password);

                _userInterface.Add(newUser);

                HttpContext.Session.SetString("uID", userID);
                _logger.LogInformation("New user registered: {Email}", email);

                ViewBag.successMsg = "You have successfully created an account";
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured during registration");
                ViewBag.errorMsg = "Please contact support - an unexpected error occured: " + ex.Message;
                return View();
            }
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
