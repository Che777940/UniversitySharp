using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace IIS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IGroupRepository _groupRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public AccountController(IAuthService authService, IGroupRepository groupRepository, IDepartmentRepository departmentRepository)
        {
            _authService = authService;
            _groupRepository = groupRepository;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _authService.LoginAsync(dto);
            if (user == null)
            {
                ModelState.AddModelError("", "Неверный Email или пароль");
                return View(dto);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            if (user.Role == IIS.Domain.Enums.UserRole.Admin) return RedirectToAction("Index", "Home");
            if (user.Role == IIS.Domain.Enums.UserRole.Teacher) return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> RegisterStudent()
        {
            var groups = await _groupRepository.GetAllAsync();
            ViewBag.Groups = new SelectList(groups, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterStudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                var groups = await _groupRepository.GetAllAsync();
                ViewBag.Groups = new SelectList(groups, "Id", "Name", dto.GroupId);
                return View(dto);
            }

            try
            {
                await _authService.RegisterStudentAsync(dto);
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ошибка при регистрации. Возможно, Email уже занят.");
                var groups = await _groupRepository.GetAllAsync();
                ViewBag.Groups = new SelectList(groups, "Id", "Name", dto.GroupId);
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> RegisterTeacher()
        {
            var departments = await _departmentRepository.GetAllAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterTeacherDto dto)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentRepository.GetAllAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name", dto.DepartmentId);
                return View(dto);
            }

            try
            {
                await _authService.RegisterTeacherAsync(dto);
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ошибка при регистрации. Возможно, Email уже занят.");
                var departments = await _departmentRepository.GetAllAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name", dto.DepartmentId);
                return View(dto);
            }
        }
    }
}
