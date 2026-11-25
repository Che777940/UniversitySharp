using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using IIS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

        private readonly IStudentRepository _studentRepository;

        private readonly ITeacherRepository _teacherRepository;

        public AccountController(IAuthService authService,
                                 IGroupRepository groupRepository, 
                                 IDepartmentRepository departmentRepository, 
                                 IStudentRepository studentRepository, 
                                 ITeacherRepository teacherRepository)
        {
            _authService = authService;
            _groupRepository = groupRepository;
            _departmentRepository = departmentRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
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

        [HttpGet] 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
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

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(userIdStr!);
            var role = User.FindFirstValue(ClaimTypes.Role);

            var profile = new ProfileDto
            {
                Email = User.FindFirstValue(ClaimTypes.Email)!,
                Role = role!
            };

            if (role == "Student")
            {
                var student = (await _studentRepository.GetAllAsync()).FirstOrDefault(s => s.UserId == userId);
                if (student != null)
                {
                    profile.FirstName = student.FirstName;
                    profile.LastName = student.LastName;
                    profile.GroupName = student.Group?.Name;
                    profile.RecordBookNumber = student.RecordBookNumber;
                }
            }
            else if (role == "Teacher")
            {
                var teacher = (await _teacherRepository.GetAllAsync()).FirstOrDefault(t => t.UserId == userId);
                if (teacher != null)
                {
                    profile.FirstName = teacher.FirstName;
                    profile.LastName = teacher.LastName;
                    profile.Degree = teacher.Degree;
                    profile.DepartmentName = teacher.Department?.Name;
                }
            }

            return View(profile);
        }
    }
}
