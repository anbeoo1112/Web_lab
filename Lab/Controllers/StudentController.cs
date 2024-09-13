using Lab.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lab.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private readonly List<Student> listStudents;

        public StudentController()
        {
            listStudents = new List<Student>
            {
                new Student
                {
                    Id = 101,
                    Name = "Hải Nam",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2018",
                    Email = "nam@g.com"
                },
                new Student
                {
                    Id = 102,
                    Name = "Minh Tú",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2019",
                    Email = "tu@g.com"
                },
                new Student
                {
                    Id = 103,
                    Name = "Hoàng Phong",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "A1-2020",
                    Email = "phong@g.com"
                },
                new Student
                {
                    Id = 104,
                    Name = "Xuân Mai",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "A1-2021",
                    Email = "mai@g.com"
                },
            };
        }

        [Route("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT", Value = Branch.IT.ToString() },
                new SelectListItem { Text = "BE", Value = Branch.BE.ToString() },
                new SelectListItem { Text = "CE", Value = Branch.CE.ToString() },
                new SelectListItem { Text = "EE", Value = Branch.EE.ToString() }
            };
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(Student s, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    ProfilePicture.CopyTo(ms);
                    s.ProfilePicture = ms.ToArray();
                }
            }

            s.Id = listStudents.Last().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
