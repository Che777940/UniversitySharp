Pet-проект для изучения языка C#. Это проект веб-приложения электронной системы университета.
<img width="1876" height="972" alt="image" src="https://github.com/user-attachments/assets/27009331-c0a7-4234-bd8b-9c7e5989d7d1" /> <img width="1863" height="400" alt="image" src="https://github.com/user-attachments/assets/83a1fd28-9a05-4894-9961-9e0781bc2be3" />
<img width="1858" height="923" alt="image" src="https://github.com/user-attachments/assets/dcdb2a08-6c9f-4925-a21f-c27db4394bdf" />

| Решение | Раздел | Папка | Файлы |
| :--- | :--- | :--- | :--- |
| IIS | Controllers | — | `AccountController.cs`, `AttendanceController.cs`, `ClassroomsController.cs`, `CoursesController.cs`, `DepartmentsController.cs`, `FacultiesController.cs`, `GradesController.cs`, `GroupsController.cs`, `HomeController.cs`, `ScheduleController.cs`, `StudentsController.cs`, `SubjectsController.cs`, `TeachersController.cs` |
| IIS | Models | — | `ErrorViewModel.cs` |
| IIS | Views | — | `_ViewImports.cshtml`, `_ViewStart.cshtml` |
| IIS | Views | Account | `Login.cshtml`, `Profile.cshtml`, `RegisterStudent.cshtml`, `RegisterTeacher.cshtml` |
| IIS | Views | Attendance | `Mark.cshtml`, `MyAttendance.cshtml` |
| IIS | Views | Classrooms | `Create.cshtml`, `Index.cshtml` |
| IIS | Views | Courses | `Create.cshtml`, `Index.cshtml` |
| IIS | Views | Departments | `Create.cshtml`, `Index.cshtml` |
| IIS | Views | Faculties | `Create.cshtml`, `Details.cshtml`, `Index.cshtml` |
| IIS | Views | Grades | `Create.cshtml`, `Edit.cshtml` |
| IIS | Views | Groups | `Create.cshtml`, `Index.cshtml` |
| IIS | Views | Home | `Index.cshtml`, `Privacy.cshtml` |
| IIS | Views | Schedule | `Create.cshtml`, `Index.cshtml` |
| IIS | Views | Shared | `_Layout.cshtml`, `_ValidationScriptsPartial.cshtml`, `Error.cshtml` |
| IIS | Views | Students | `Create.cshtml`, `Edit.cshtml`, `Grades.cshtml`, `Index.cshtml` |
| IIS | Views | Subjects | `Create.cshtml`, `Index.cshtml` |
| IIS | Views | Teachers | `Create.cshtml`, `Edit.cshtml`, `Index.cshtml` |
| IIS | Корень проекта | — | `appsettings.json`, `Dockerfile`, `Program.cs` |
| IIS.Application | DTOs | — | `AttendanceDto.cs`, `CreateClassroomDto.cs`, `CreateCourseDto.cs`, `CreateDepartmentDto.cs`, `CreateFacultyDto.cs`, `CreateGradeDto.cs`, `CreateGroupDto.cs`, `CreateScheduleDto.cs`, `CreateStudentDto.cs`, `CreateSubjectDto.cs`, `CreateTeacherDto.cs`, `FacultyDetailsDto.cs`, `GradeDto.cs`, `LoginDto.cs`, `ProfileDto.cs`, `RegisterStudentDto.cs`, `RegisterTeacherDto.cs`, `ScheduleDto.cs`, `StudentAttendanceDto.cs`, `StudentDto.cs`, `UpdateGradeDto.cs`, `UpdateStudentDto.cs`, `UpdateTeacherDto.cs` |
| IIS.Application | Interfaces | — | `IAttendanceRepository.cs`, `IClassroomRepository.cs`, `ICourseRepository.cs`, `IDepartmentRepository.cs`, `IFacultyRepository.cs`, `IGradeRepository.cs`, `IGroupRepository.cs`, `IScheduleRepository.cs`, `IStudentRepository.cs`, `ISubjectRepository.cs`, `ITeacherRepository.cs`, `IUserRepository.cs` |
| IIS.Application | Services | — | `AuthService.cs`, `ClassroomService.cs`, `CourseService.cs`, `DepartmentService.cs`, `FacultyService.cs`, `GradeService.cs`, `GroupService.cs`, `ScheduleService.cs`, `StudentService.cs`, `SubjectService.cs`, `TeacherService.cs`, `IAuthService.cs`, `IClassroomService.cs`, `ICourseService.cs`, `IDepartmentService.cs`, `IFacultyService.cs`, `IGradeService.cs`, `IGroupService.cs`, `IScheduleService.cs`, `IStudentService.cs`, `ISubjectService.cs`, `ITeacherService.cs` |
| IIS.Domain | Common | — | `BaseEntity.cs` |
| IIS.Domain | Entities | Academics | `Course.cs`, `Subject.cs` |
| IIS.Domain | Entities | Grading | `Attendance.cs`, `Grade.cs` |
| IIS.Domain | Entities | Identity | `Student.cs`, `Teacher.cs`, `User.cs` |
| IIS.Domain | Entities | Scheduling | `Classroom.cs`, `Schedule.cs` |
| IIS.Domain | Entities | Structure | `Department.cs`, `Faculty.cs`, `Group.cs` |
| IIS.Domain | Enums | — | `LessonType.cs`, `Semester.cs`, `UserRole.cs` |
| IIS.Infrastructure | Configurations | — | `CourseConfiguration.cs`, `StudentConfiguration.cs`, `UserConfiguration.cs` |
| IIS.Infrastructure | Data | — | `ApplicationDbContext.cs` |
| IIS.Infrastructure | Migrations | — | `20261030210909_InitialCreate.cs`, `20261125120522_GradeSoftDelete.cs`, `ApplicationDbContextModelSnapshot.cs` |
| IIS.Infrastructure | Repositories | — | `AttendanceRepository.cs`, `ClassroomRepository.cs`, `CourseRepository.cs`, `DepartmentRepository.cs`, `FacultyRepository.cs`, `GradeRepository.cs`, `GroupRepository.cs`, `ScheduleRepository.cs`, `StudentRepository.cs`, `SubjectRepository.cs`, `TeacherRepository.cs`, `UserRepository.cs` |
| IIS.Infrastructure | Корень проекта | — | `DependencyInjection.cs` |
| IIS.Tests.Unit | Unit-тесты | — | — |
| IIS.Tests.Integration | Integration-тесты | — | — |
| Корень решения | — | — | `IIS.sln`, `docker-compose.yml` |





