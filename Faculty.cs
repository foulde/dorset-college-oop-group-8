using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_POO
{
    class Faculty : User
    {
        public string adress { get; set; }
        public List<Course> coursesTaught { get; set; }

        public Faculty(string Username, string UserPassword, string name, int age, string status, int ID)
            : base(Username, UserPassword, name, age, status, ID)
        {

            StreamReader LectCourse = new StreamReader("COURSE_DATABASE.csv");
            LectCourse.ReadLine();
            while (LectCourse.Peek() > 0)
            {
                string[] datas = LectCourse.ReadLine().Split(';');
                if (Username == datas[2])
                {
                    coursesTaught.Add(new Course(datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], datas[6]));
                }
            }
            LectCourse.Close();

        }

        public void Show_Grade(string GradeName)
        {
            StreamReader LectGrade = new StreamReader("GRADES_DATABASE.csv");


            char sep = ';';
            string line = "";
            string[] datas;



            int placeNote = 0;
            bool verif = false;
            datas = LectGrade.ReadLine().Split(';');
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] == GradeName)
                {
                    verif = true;
                    placeNote = i;
                    break;
                }
            }
            if (verif)
            {
                while (LectGrade.Peek() > 0)
                {
                    line = LectGrade.ReadLine();
                    datas = line.Split(sep);
                    Console.WriteLine(datas[0] + "   " + datas[placeNote]);
                }
            }
            else Console.WriteLine("This Grade doesn't exist");
            LectGrade.Close();
        }
        public void Change_Grade(string student, string gradeName, string grade)
        {
            string finalText = null;
            StreamReader LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string line = null;
            string[] datas2;
            int nbline = 0;

            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                nbline++;
            }
            LectureGrade.Close();
            LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string[][] datas = new string[nbline][];
            int i = 0;
            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                datas2 = line.Split(';');
                datas[i] = datas2;
                i++;
            }
            int column = 0;
            for (int j = 0; j < datas[0].Length; j++)
            {
                if (datas[0][j] == gradeName)
                {
                    column = j;
                    break;
                }
            }
            int lineGrade = 0;
            for (int k = 0; k < datas.Length; k++)
            {
                if (datas[k][0] == student)
                {
                    lineGrade = k;
                    break;
                }
            }
            LectureGrade.Close();
            if (lineGrade != 0 && column != 0)
            {
                datas[lineGrade][column] = grade;
            }
            else Console.WriteLine("The student or the name of the grade doesn't exist");
            for (int j = 0; j < datas.Length; j++)
            {
                for (int k = 0; k < datas[j].Length; k++)
                {
                    finalText = finalText + datas[j][k] + ";";
                }
                finalText = finalText + "\r\n";
            }
            StreamWriter WriteGrades = new StreamWriter("GRADES_DATABASE.csv");
            WriteGrades.Write(finalText);
            WriteGrades.Close();
        }
        public void Create_Grade(string gradeName)
        {
            string finalText = null;
            StreamReader LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string line = null;
            string[] datas2;
            int nbline = 0;

            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                nbline++;
            }
            LectureGrade.Close();
            LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string[][] datas = new string[nbline][];
            int i = 0;
            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                datas2 = line.Split(';');
                datas[i] = new string[datas2.Length + 1];
                if (i == 0) datas[0][datas[0].Length - 1] = gradeName;
                else
                {
                    Console.Write("What is the grade for " + datas2[0] + "=>");
                    datas[i][datas[i].Length - 1] = Console.ReadLine();
                }
                for (int j = 0; j < datas2.Length; j++)
                {
                    datas[i][j] = datas2[j];
                }
                i++;
            }
            LectureGrade.Close();
            for (int j = 0; j < datas.Length; j++)
            {
                for (int k = 0; k < datas[j].Length; k++)
                {
                    finalText = finalText + datas[j][k] + ";";
                }
                finalText = finalText + "\r\n";
            }
            StreamWriter WriteGrades = new StreamWriter("GRADES_DATABASE.csv");
            WriteGrades.Write(finalText);
            WriteGrades.Close();
        }
        public void DisplayTimetable()
        {
            SortedList<string, Course> MondayList = new SortedList<string, Course>();
            SortedList<string, Course> TuesdayList = new SortedList<string, Course>();
            SortedList<string, Course> WednesdayList = new SortedList<string, Course>();
            SortedList<string, Course> ThursdayList = new SortedList<string, Course>();
            SortedList<string, Course> FridayList = new SortedList<string, Course>();

            StreamReader LectCourse = new StreamReader("COURSE_DATABASE.csv");

            while (LectCourse.Peek() > 0)
            {
                bool success = false;
                string[] datas = LectCourse.ReadLine().Split(';');
                Course course = new Course(datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], datas[6]);
                if (name == course.CourseTeacher)
                {
                    switch (course.CourseDay)       //according to the day
                    {
                        case "monday":
                            success = AddCourseToDay(course, MondayList);
                            break;
                        case "tuesday":
                            success = AddCourseToDay(course, TuesdayList);
                            break;
                        case "wednesday":
                            success = AddCourseToDay(course, WednesdayList);
                            break;
                        case "thursday":
                            success = AddCourseToDay(course, ThursdayList);
                            break;
                        case "friday":
                            success = AddCourseToDay(course, FridayList);
                            break;
                        default:
                            success = false;
                            Console.WriteLine(course.CourseDay + " " + course.classroom);
                            Console.WriteLine("Wrong day input");       //if the input is neither of the 5 days, the program returns false.
                            break;
                    }
                }
            }
            LectCourse.Close();

            Console.WriteLine("Monday");
            Console.WriteLine();
            for (int n = 0; n < MondayList.Count; n++)
            {
                Console.WriteLine(MondayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Tuesday");
            Console.WriteLine();
            for (int n = 0; n < TuesdayList.Count; n++)
            {
                Console.WriteLine(TuesdayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Wednesday");
            Console.WriteLine();
            for (int n = 0; n < WednesdayList.Count; n++)
            {
                Console.WriteLine(WednesdayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Thursday");
            Console.WriteLine();
            for (int n = 0; n < ThursdayList.Count; n++)
            {
                Console.WriteLine(ThursdayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Friday");
            Console.WriteLine();
            for (int n = 0; n < FridayList.Count; n++)
            {
                Console.WriteLine(FridayList.Values[n].ToStringTimetable());
            }
        }
        private bool AddCourseToDay(Course course, SortedList<string, Course> DayList)
        {
            bool success2 = true;
            try
            {
                DayList.Add(course.StartingHour, course);       //starting hours are used as the key of the sorted list, thus the courses are sorted by their starting hour
                if (DayList.Count > 1)  //if there are more than one course a day, we must check if they are not overlapping
                {
                    for (int n = 1; n < DayList.Count; n++)
                    {
                        if (CompareHours(DayList.Values[n - 1].EndingHour, DayList.Values[n].StartingHour) == false)
                        {
                            success2 = false;
                        }
                    }
                    if (success2 == false)
                    {
                        DayList.Remove(course.StartingHour);        //if the addition of the course cause overlapping courses, we remove it.
                        Console.WriteLine("There are overlapping courses.");
                    }
                }
            }
            catch (ArgumentException)       //2 courses cannot have the same starting hour, and 2 elements in a sorted list cannot have the same key
            {
                Console.WriteLine("The starting hour " + course.StartingHour + " is already taken.");
                success2 = false;
            }
            return success2;
        }
        public bool CompareHours(string end1, string start2)
        {
            return (string.Compare(end1, start2) <= 0);
        }
    }
}
