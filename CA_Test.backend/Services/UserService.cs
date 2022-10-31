namespace CA_Test.backend.Services;

using BCrypt.Net;
using CA_Test.backend.Authorization;
using CA_Test.backend.Data;
using CA_Test.backend.Dto;
using CA_Test.backend.Helper;
using CA_Test.backend.Models;
using Microsoft.Extensions.Options;

public interface IUserService
{
    LoginResponse Authenticate(LoginDto model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    IList<Course> GetAllCourses(int id);
}

public class UserService : IUserService
{
    private AppDbContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public UserService(
        AppDbContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }


    public LoginResponse Authenticate(LoginDto model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful so generate jwt token
        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        return new LoginResponse(user, jwtToken);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id) 
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public IList<Course> GetAllCourses(int id)
    {
        Console.WriteLine(id);
        /* var courses = _context.Enrollments.SelectMany(a => _context.Courses
                                                .Where(b => a.StudentId == id && a.CourseId == b.Id)).ToList(); */
        var courses = (from enrollment in _context.Enrollments   
                        join Course in _context.Courses
                        on  enrollment.CourseId equals Course.Id    
                        where enrollment.StudentId == id
                        select new Course()
                          {
                            Id = enrollment.StudentId,
                            CourseTitle = Course.CourseTitle,
                            CourseDescription = Course.CourseDescription,
                            InstructorId = Course.InstructorId,
                            NumberOfModules = Course.NumberOfModules,
                            CourseFee = Course.CourseFee
                          }).ToList();                          
        Console.WriteLine(courses);
        if (courses == null) throw new KeyNotFoundException("courses not found");
        return courses;
    }
}