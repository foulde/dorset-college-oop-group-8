using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_poo_faculty_admin
{
    
    class Admin
    {
        private string name;
        private string email;
        public Admin(string email, string name)
        {
            this.name = name;
            this.email = email;
        }
        public void Modify_Timetable(Timetable timetable)
        {
            int a = 0;
            while (a == 0)
            {
                Console.WriteLine("What change would you want to do? \r\n 1)Add course \r\n 2)Remove course \r\n 3)Back");
                int choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Which course would you want to add?");
                        string courseAddName = Console.ReadLine();
                        //trouver le cours avec ce nom en fonction de ou ils sont stockés;
                        Course course = new Course();
                        timetable.AddCourse(course);
                        break;
                    case 2:
                        Console.WriteLine("Which course would you want to remove?");
                        string courseRemoveName = Console.ReadLine();
                        //trouver le cours avec ce nom en fonction de ou ils sont stockés;
                        Course courseRemove = new Course();
                        timetable.RemoveCourse(courseRemove);
                        break;
                    case 3:
                        a = 1;
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
                Console.Clear();
            }
        }
        public void Modify_Courses(Course course)
        {
            int a = 0;
            while (a == 0)
            {
                Console.WriteLine("What change would you want to do? \r\n 1)Name of the course \r\n 2)The Faculty \r\n 3)The content \r\n 4)The day \r\n 5)The starting hour \r\n 6)The ending hour \r\n 7)Back");
                int choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choose)
                {
                    case 1:
                        Console.Write("Choose the new name =>");
                        course.courseName = name = Console.ReadLine();
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.Write("Choose the new content =>");
                        course.content = name = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Choose the new day =>");
                        course.courseDay = name = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Choose the new starting hour =>");
                        course.startingHour = name = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Choose the new ending hour =>");
                        course.endingHour = name = Console.ReadLine();
                        break;
                    case 7:
                        a = 1;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.Clear();
            }
        }
        public void Create_Timetable()//creer un timetable vide
        {
            Console.Write("choisir un TD =>");
            //tableau de TD on choisit le td puis on crée l'emplois du temps dedans
            List<Course> ListCourses = new List<Course>();
            Timetable bidule = new Timetable();
        }
        public void Create_Course()
        {
            Console.Write("choose the name of the course =>");
            string courseName = Console.ReadLine();
            Console.Write("choose the Faculty =>");
            //Faculty courseFaculty = Console.ReadLine();
            Console.Write("choose the content =>");
            string courseContent = Console.ReadLine();
            Console.Write("choose the day =>");
            string courseDay = Console.ReadLine();
            Console.Write("choose the start hour =>");
            string courseStartingHour = Console.ReadLine();
            Console.Write("choose the ending hour =>");
            string courseEndingHours = Console.ReadLine();
            Course newCourse = new Course();
        }

    }
    
}
