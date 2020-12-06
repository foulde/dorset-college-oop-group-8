using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_POO
{
    class Admin : User
    {
        public Admin(string Username, string UserPassword, string name, int age, string status, int ID)
            : base(Username, UserPassword, name, age, status, ID) { }

        public Course Create_Course()
        {
            Console.Write("choose the name of the course =>");
            string courseName = Console.ReadLine();
            Console.Write("choose the Faculty =>");
            string courseFaculty = Console.ReadLine();
            Console.Write("choose the content =>");
            string courseContent = Console.ReadLine();
            Console.Write("choose the day =>");
            string courseDay = Console.ReadLine();
            Console.Write("choose the start hour =>");
            string courseStartingHour = Console.ReadLine();
            Console.Write("choose the ending hour =>");
            string courseEndingHours = Console.ReadLine();
            Console.Write("choose the classroom =>");
            string courseclassroom = Console.ReadLine();
            return new Course(courseName, courseContent, courseFaculty, courseDay, courseStartingHour, courseEndingHours, courseclassroom);
        }

    }
}
