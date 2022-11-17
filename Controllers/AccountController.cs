using KeyboArt.Data;
using KeyboArt.Data.Cart;
using KeyboArt.Data.Static;
using KeyboArt.Data.ViewModels;
using KeyboArt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KeyboArt.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, ShoppingCart shoppingCart)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [AllowAnonymous]
        public IActionResult Login() => View(new LoginVM());
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Zły login lub hasło. Proszę spróbować ponownie.";
                return View(loginVM);
            }

            TempData["Error"] = "Zły login lub hasło. Proszę spróbować ponownie.";
            return View(loginVM);
        }
        [AllowAnonymous]
        public IActionResult Register() => View(new RegisterVM());
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAdress);
            if (user != null)
            {
                TempData["Error"] = "Ten adres email jest już w użyciu";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAdress,
                UserName = registerVM.EmailAdress
            };

            var newUserRespone = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserRespone.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("RegisterCompleted");
            }

            return View(registerVM);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout(Product product, ShoppingCartItem shoppingCartItem)
        {
            await _signInManager.SignOutAsync();
            var items = _shoppingCart.GetShoppingCartItems();
            if (items != null)
            {
                product.Quantity += shoppingCartItem.Amount;
                await _shoppingCart.ClearShoppingCartAsync();                
            }           
            return RedirectToAction("Index", "Home");
        }
    }
}
