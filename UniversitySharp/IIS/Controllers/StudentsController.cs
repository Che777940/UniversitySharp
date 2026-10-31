using IIS.Application.DTO_s.Student;
using IIS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound(); 

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            try
            {
                var newId = await _studentService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
