using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            UserRepository.Add(user);
            return RedirectToAction("Login");
        }
        return View(user);
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (UserRepository.ValidateLogin(username, password))
        {
            return RedirectToAction("Index", "PatientVisit");
        }
        ViewBag.Error = "Invalid login.";
        return View();
    }

    public IActionResult Logout()
    {
        return RedirectToAction("Login");
    }
}
