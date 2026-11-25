Pet-проект для изучения языка C#. Это проект веб-приложения электронной системы университета.
IIS.sln
├── docker-compose.yml
│
├── IIS                                      
│   ├── Connected Services
│   ├── Dependencies
│   ├── Properties
│   ├── wwwroot
│   ├── Controllers
│   │   ├── AccountController.cs
│   │   ├── AttendanceController.cs
│   │   ├── ClassroomsController.cs
│   │   ├── CoursesController.cs
│   │   ├── DepartmentsController.cs
│   │   ├── FacultiesController.cs
│   │   ├── GradesController.cs
│   │   ├── GroupsController.cs
│   │   ├── HomeController.cs
│   │   ├── ScheduleController.cs
│   │   ├── StudentsController.cs
│   │   ├── SubjectsController.cs
│   │   └── TeachersController.cs
│   ├── Models
│   │   └── ErrorViewModel.cs
│   ├── Views
│   │   ├── Account
│   │   │   ├── Login.cshtml
│   │   │   ├── Profile.cshtml
│   │   │   ├── RegisterStudent.cshtml
│   │   │   └── RegisterTeacher.cshtml
│   │   ├── Attendance
│   │   │   ├── Mark.cshtml
│   │   │   └── MyAttendance.cshtml
│   │   ├── Classrooms
│   │   │   ├── Create.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Courses
│   │   │   ├── Create.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Departments
│   │   │   ├── Create.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Faculties
│   │   │   ├── Create.cshtml
│   │   │   ├── Details.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Grades
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Groups
│   │   │   ├── Create.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Home
│   │   │   ├── Index.cshtml
│   │   │   └── Privacy.cshtml
│   │   ├── Schedule
│   │   │   ├── Create.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Shared
│   │   │   ├── _Layout.cshtml
│   │   │   ├── _ValidationScriptsPartial.cshtml
│   │   │   └── Error.cshtml
│   │   ├── Students
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   ├── Grades.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Subjects
│   │   │   ├── Create.cshtml
│   │   │   └── Index.cshtml
│   │   ├── Teachers
│   │   ├── _ViewImports.cshtml
│   │   └── _ViewStart.cshtml
│   ├── appsettings.json
│   ├── Dockerfile
│   └── Program.cs
│
├── IIS.Application                         
│   ├── Dependencies
│   ├── DTOs
│   │   ├── AttendanceDto.cs
│   │   ├── CreateClassroomDto.cs
│   │   ├── CreateCourseDto.cs
│   │   ├── CreateDepartmentDto.cs
│   │   ├── CreateFacultyDto.cs
│   │   ├── CreateGradeDto.cs
│   │   ├── CreateGroupDto.cs
│   │   ├── CreateScheduleDto.cs
│   │   ├── CreateStudentDto.cs
│   │   ├── CreateSubjectDto.cs
│   │   ├── CreateTeacherDto.cs
│   │   ├── FacultyDetailsDto.cs
│   │   ├── GradeDto.cs
│   │   ├── LoginDto.cs
│   │   ├── ProfileDto.cs
│   │   ├── RegisterStudentDto.cs
│   │   ├── RegisterTeacherDto.cs
│   │   ├── ScheduleDto.cs
│   │   ├── StudentAttendanceDto.cs
│   │   ├── StudentDto.cs
│   │   ├── UpdateGradeDto.cs
│   │   ├── UpdateStudentDto.cs
│   │   └── UpdateTeacherDto.cs
│   ├── Interfaces
│   │   ├── IAttendanceRepository.cs
│   │   ├── IClassroomRepository.cs
│   │   ├── ICourseRepository.cs
│   │   ├── IDepartmentRepository.cs
│   │   ├── IFacultyRepository.cs
│   │   ├── IGradeRepository.cs
│   │   ├── IGroupRepository.cs
│   │   ├── IScheduleRepository.cs
│   │   ├── IStudentRepository.cs
│   │   ├── ISubjectRepository.cs
│   │   ├── ITeacherRepository.cs
│   │   └── IUserRepository.cs
│   └── Services
│       ├── AuthService.cs
│       ├── ClassroomService.cs
│       ├── CourseService.cs
│       ├── DepartmentService.cs
│       ├── FacultyService.cs
│       ├── GradeService.cs
│       ├── GroupService.cs
│       ├── IAuthService.cs
│       ├── IClassroomService.cs
│       ├── ICourseService.cs
│       ├── IDepartmentService.cs
│       ├── IFacultyService.cs
│       ├── IGradeService.cs
│       ├── IGroupService.cs
│       ├── IScheduleService.cs
│       ├── IStudentService.cs
│       ├── ISubjectService.cs
│       ├── ITeacherService.cs
│       ├── ScheduleService.cs
│       ├── StudentService.cs
│       ├── SubjectService.cs
│       └── TeacherService.cs
│
├── IIS.Domain                               
│   ├── Dependencies
│   ├── Common
│   │   └── BaseEntity.cs
│   ├── Entities
│   │   ├── Academics
│   │   │   ├── Course.cs
│   │   │   └── Subject.cs
│   │   ├── Grading
│   │   │   ├── Attendance.cs
│   │   │   └── Grade.cs
│   │   ├── Identity
│   │   │   ├── Student.cs
│   │   │   ├── Teacher.cs
│   │   │   └── User.cs
│   │   ├── Scheduling
│   │   │   ├── Classroom.cs
│   │   │   └── Schedule.cs
│   │   └── Structure
│   │       ├── Department.cs
│   │       ├── Faculty.cs
│   │       └── Group.cs
│   └── Enums
│       ├── LessonType.cs
│       ├── Semester.cs
│       └── UserRole.cs
│
├── IIS.Infrastructure                       
│   ├── Dependencies
│   ├── Configurations
│   │   ├── CourseConfiguration.cs
│   │   ├── StudentConfiguration.cs
│   │   └── UserConfiguration.cs
│   ├── Data
│   │   └── ApplicationDbContext.cs
│   ├── Migrations
│   │   ├── 20261030210909_InitialCreate.cs
│   │   ├── 20261125120522_GradeSoftDelete.cs
│   │   └── ApplicationDbContextModelSnapshot.cs
│   ├── Repositories
│   │   ├── AttendanceRepository.cs
│   │   ├── ClassroomRepository.cs
│   │   ├── CourseRepository.cs
│   │   ├── DepartmentRepository.cs
│   │   ├── FacultyRepository.cs
│   │   ├── GradeRepository.cs
│   │   ├── GroupRepository.cs
│   │   ├── ScheduleRepository.cs
│   │   ├── StudentRepository.cs
│   │   ├── SubjectRepository.cs
│   │   ├── TeacherRepository.cs
│   │   └── UserRepository.cs
│   └── DependencyInjection.cs
│
├── IIS.Tests.Unit                           
└── IIS.Tests.Integration                    
