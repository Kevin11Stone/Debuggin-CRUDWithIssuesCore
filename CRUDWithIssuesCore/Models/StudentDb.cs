using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public static class StudentDb
    {
        public static async Task<Student> Add(Student p, SchoolContext db)
        {
            //Add student to context
            await db.AddAsync(p);
            await db.SaveChangesAsync();
            return p;
        }

        public static async Task<List<Student>> GetStudents(SchoolContext context)
        {
            List<Student> students = await (from s in context.Students
                    select s).ToListAsync();
            return students;
        }

        public static Student GetStudent(SchoolContext context, int id)
        {
            Student p2 = context
                            .Students
                            .Where(s => s.StudentId == id)
                            .Single();
            return p2;
        }

        public static void Delete(SchoolContext context, Student p)
        {
            context.Students.Update(p);
        }

        public static void Update(SchoolContext context, Student p)
        {
            //Mark the object as deleted
            context.Students.Remove(p);

            //Send delete query to database
            context.SaveChanges();
        }
    }
}
