using EFCoreTutorial.Data.Context;
using EFCoreTutorial.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        public StudentController(ApplicationDbContext _applicationDbContext)
        { 
            applicationDbContext =_applicationDbContext;
        }
        private async Task eagerLoadings()
        {
            var student = await applicationDbContext.Students
                .Include(i => i.Books)
                .FirstOrDefaultAsync(i => i.Id == 5);
        }
        private async Task lazyLoadings()
        {
            var students = await applicationDbContext.Students.ToListAsync();
            //var book = students.Books;
            foreach(var student in students)
            {
                foreach(var book in student.Books)
                {
                    Console.WriteLine(book.Name);
                }

            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await lazyLoadings();
            return null;
            StudentFilter filter = new StudentFilter()
            {
                FirstName = "Salih"
            };
            var students = applicationDbContext.Students.AsQueryable();

            if(!String.IsNullOrEmpty(filter.FirstName))
            {
                students = students.Where(i => i.FirstName == filter.FirstName);
            }
            if (!String.IsNullOrEmpty(filter.LastName))
            {
                students = students.Where(i => i.LastName == filter.LastName);
            }
            if (filter.Number.HasValue)
            {
                students = students.Where(i => i.Number == filter.Number);
            }

            var list =await students.ToListAsync();



            var student = await applicationDbContext.Students.ToListAsync();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            //StudentAdress adress = new StudentAdress()
            //{
            //    City="İstanbul",
            //    Country="Türkiye",
            //    District="Kadıköy",
            //    FullAdress="X sokak,No:y"
            //};
            //await applicationDbContext.StudentAdresses.AddAsync(adress);
            //await applicationDbContext.SaveChangesAsync();

            Student student = new Student()
            {
                FirstName = "Salih",
                LastName = "Cantekin",
                Number = 1,
                Adress= new StudentAdress()
                {
                    City = "İstanbul",
                    Country="Türkiye",
                    District = "Kadıköy",
                    FullAdress = "X sokak,No:y"

                }
            };

            await applicationDbContext.Students.AddAsync(student);
            await applicationDbContext.SaveChangesAsync();
            return Ok(student);

         
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await applicationDbContext.Students.FindAsync(id);
            applicationDbContext.Students.Remove(student);
            await applicationDbContext.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync();
            
            student.FirstName="Dilara",
            student.LastName="Karaduman",
            await applicationDbContext.SaveChangesAsync();
            return Ok(student);
        }

    }
}
