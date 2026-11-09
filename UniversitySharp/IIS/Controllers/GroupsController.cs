using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using IIS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IIS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IDepartmentRepository _departmentRepository;
        public GroupsController(IGroupService groupService, IDepartmentRepository departmentRepository)
        {
            _groupService = groupService;
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _groupService.GetAllAsync();
            return View(groups);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentRepository.GetAllAsync();
            ViewBag.Departments = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGroupDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _groupService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
