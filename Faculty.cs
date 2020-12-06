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
        public List<Course> coursesTaught { get; set; }

        public Faculty(string Username, string UserPassword, string name, int age, string status, int ID)
            : base(Username, UserPassword, name, age, status, ID)
        {
            coursesTaught = new List<Course>();
            StreamReader LectCourse = new StreamReader("COURSE_DATABASE.csv");
            LectCourse.ReadLine();
            while (LectCourse.Peek() > 0)
            {
                string[] datas = LectCourse.ReadLine().Split(';');
                if (name == datas[2])
                {
                    coursesTaught.Add(new Course(datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], datas[6]));
                }
            }
            LectCourse.Close();

        }

        public void ShowGrade(string GradeName)
        {
            StreamReader LectGrade = new StreamReader("GRADES_DATABASE.csv");
            string[] datas;
            int placeNote = 0;
            bool verif = false;
            datas = LectGrade.ReadLine().Split(';');
            for (int i = 0; i < datas.Length; i++)//we search the column of the grade
            {
                if (datas[i] == GradeName)
                {
                    verif = true;
                    placeNote = i;
                    break;
                }
            }
            if (verif)//if the grade is found we show the grades
            {
                while (LectGrade.Peek() > 0)
                {
                    datas = LectGrade.ReadLine().Split(';');
                    Console.WriteLine(datas[0] + "   " + datas[placeNote]);
                }
            }
            else Console.WriteLine("This Grade doesn't exist");
            LectGrade.Close();
        }
        public void ChangeGrade(string student, string gradeName, string grade)
        {
            string finalText = null;
            StreamReader LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string line = null;
            string[] datas2;
            int nbline = 0;

            while (LectureGrade.Peek() > 0)//we check the number of line
            {
                line = LectureGrade.ReadLine();
                nbline++;
            }
            LectureGrade.Close();
            LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string[][] datas = new string[nbline][];
            int i = 0;
            while (LectureGrade.Peek() > 0)//we write the database in chart
            {
                line = LectureGrade.ReadLine();
                datas2 = line.Split(';');
                datas[i] = datas2;
                i++;
            }
            int column = 0;
            for (int j = 0; j < datas[0].Length; j++)//then we search the column of the grade
            {
                if (datas[0][j] == gradeName)
                {
                    column = j;
                    break;
                }
            }
            int lineGrade = 0;
            for (int k = 0; k < datas.Length; k++)//and the line of the student
            {
                if (datas[k][0] == student)
                {
                    lineGrade = k;
                    break;
                }
            }
            LectureGrade.Close();
            if (lineGrade != 0 && column != 0)//if found we change the grade
            {
                datas[lineGrade][column] = grade;
            }
            else Console.WriteLine("The student or the name of the grade doesn't exist");
            for (int j = 0; j < datas.Length; j++)//we rewrite all the chart in the database
            {
                for (int k = 0; k < datas[j].Length; k++)
                {
                    finalText = finalText + datas[j][k] + ";";
                }
                if (j != datas.Length - 1) finalText = finalText + "\r\n";
            }
            StreamWriter WriteGrades = new StreamWriter("GRADES_DATABASE.csv");
            WriteGrades.Write(finalText);
            WriteGrades.Close();
        }
        public void CreateGrade(string gradeName, string classroom)
        {
            string finalText = null;
            StreamReader LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string line = null;
            string[] datas2;
            int nbline = 0;

            while (LectureGrade.Peek() > 0)//we check the number of line
            {
                line = LectureGrade.ReadLine();
                nbline++;
            }
            LectureGrade.Close();
            LectureGrade = new StreamReader("GRADES_DATABASE.csv");
            string[][] datas = new string[nbline][];
            int i = 0;
            while (LectureGrade.Peek() > 0)//we write the database in a chart but we add a column for the new grade
            {
                line = LectureGrade.ReadLine();
                datas2 = line.Split(';');
                datas[i] = new string[datas2.Length + 1];
                if (i == 0) datas[0][datas[0].Length - 1] = gradeName;
                else if (classroom == datas2[1])
                {
                    int grade;
                    do Console.Write("What is the grade for " + datas2[0] + "=>");//in the new column we add the grade
                    while (!int.TryParse(Console.ReadLine(), out grade));
                    datas[i][datas[i].Length - 1] = Convert.ToString(grade);
                }
                else datas[i][datas[i].Length - 1] = "";
                for (int j = 0; j < datas2.Length; j++)
                {
                    datas[i][j] = datas2[j];
                }
                i++;
            }
            LectureGrade.Close();
            for (int j = 0; j < datas.Length; j++)//then we rewrite the chart in the database
            {
                for (int k = 0; k < datas[j].Length; k++)
                {
                    finalText = finalText + datas[j][k] + ";";
                }
                if (j != datas.Length - 1) finalText = finalText + "\r\n";
            }
            StreamWriter WriteGrades = new StreamWriter("GRADES_DATABASE.csv");
            WriteGrades.Write(finalText);
            WriteGrades.Close();
        }
        public void DeleteGrade(string gradeName)
        {
            int nbline = 0;
            StreamReader LectGrade = new StreamReader("GRADES_DATABASE.csv");
            while (LectGrade.Peek() > 0)//we check the number of line
            {
                LectGrade.ReadLine();
                nbline++;
            }
            LectGrade.Close();
            LectGrade = new StreamReader("GRADES_DATABASE.csv");
            string[][] saveGrades=new string[nbline][];
            int i = 0;
            while (LectGrade.Peek() > 0)//we write the database in a chart
            {
                saveGrades[i] = LectGrade.ReadLine().Split(';');
                i++;
            }
            LectGrade.Close();
            int column=-1;
            for(int j = 0; j < saveGrades[0].Length; j++)
            {
                if (saveGrades[0][j] == gradeName)//we search the column of the grade that we want to delete
                {
                    column = j;
                    break;
                }
            }
            if (column == -1) Console.WriteLine("The grade doesn't exist");
            Console.ReadKey();
            string rewriteGrade = "";
            for(int j = 0; j < saveGrades.Length; j++)//then we rewrite the database but without the grade
            {
                for (int k = 0; k < saveGrades[j].Length; k++)
                {
                    if (k != column) rewriteGrade = rewriteGrade + saveGrades[j][k] + ";";
                }
                if (j != saveGrades.Length - 1) rewriteGrade = rewriteGrade + "\n";
            }
            StreamWriter WriteGrades = new StreamWriter("GRADES_DATABASE.csv");
            WriteGrades.Write(rewriteGrade);
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
        public Course ModifyCourse(int index)
        {
            Course changeFaculty = null;
            bool ExitCourse = false;
            while (!ExitCourse)
            {
                Console.Clear();
                Console.WriteLine("1)Change course name");
                Console.WriteLine("2)Change content");
                Console.WriteLine("3)Change faculty");
                Console.WriteLine("4)Change day");
                Console.WriteLine("5)Change starting hour");
                Console.WriteLine("6)Change ending hour");
                Console.WriteLine("7)Change classroom");
                Console.WriteLine("8)Back");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("New course name => ");
                        coursesTaught[index].CourseName = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("New content => ");
                        coursesTaught[index].Content = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("New faculty => ");
                        coursesTaught[index].CourseTeacher = Console.ReadLine();
                        changeFaculty = coursesTaught[index];
                        break;
                    case "4":
                        Console.Write("New day => ");
                        string newDay = Console.ReadLine();
                        if (newDay != "monday" && newDay != "tuesday" && newDay != "wednesday" && newDay != "thursday" && newDay != "friday") coursesTaught[index].CourseDay = newDay;
                        else
                        {
                            Console.WriteLine("Wrong Input");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        Console.Write("New starting hour (HH:MM) => ");
                        string newStartingHour = Console.ReadLine();
                        if (newStartingHour.Length == 4)
                        {
                            newStartingHour = "0" + newStartingHour;
                        }
                        coursesTaught[index].StartingHour = newStartingHour;
                        break;
                    case "6":
                        Console.Write("New ending hour (HH:MM) => ");
                        string newEndingHour = Console.ReadLine();
                        
                        if (newEndingHour.Length == 4)
                        {
                            newEndingHour = "0" + newEndingHour;
                        }
                        coursesTaught[index].EndingHour = newEndingHour;
                        break;
                    case "7":
                        Console.Write("New classroom => ");
                        coursesTaught[index].classroom = Console.ReadLine();
                        break;
                    case "8":
                        ExitCourse = true;
                        break;
                    default:
                        Console.WriteLine("Wrong value");
                        Console.ReadKey();
                        break;
                }

            }
            return changeFaculty;
        }
    }
}
