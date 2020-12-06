using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Final_Project_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            //first we will read the database
            #region LECTURE DATABASE
            StreamReader LectureDataBase = new StreamReader("USERS_DATABASE.csv");
            List<User> userList = new List<User>();//all the users go to a list of user
            string[] datas;
            LectureDataBase.ReadLine();
            while (LectureDataBase.Peek() > 0)
            {
                datas = LectureDataBase.ReadLine().Split(';');
                userList.Add(new User(datas[0], datas[1], datas[2], Convert.ToInt32(datas[3]), datas[4], Convert.ToInt32(datas[5])));
            }
            LectureDataBase.Close();
            //then we separate the users if they are admin, student or faculty
            List<Admin> ListAdmins = new List<Admin>();
            List<Student> ListStudents = new List<Student>();
            List<Faculty> ListFaculties = new List<Faculty>();
            foreach (User user in userList)
            {
                switch (user.status)
                {
                    case "STUDENT":
                        ListStudents.Add(new Student(user.Username, user.UserPassword, user.name, user.age, user.status, user.ID));
                        break;
                    case "ADMIN":
                        ListAdmins.Add(new Admin(user.Username, user.UserPassword, user.name, user.age, user.status, user.ID));
                        break;
                    case "FACULTY":
                        ListFaculties.Add(new Faculty(user.Username, user.UserPassword, user.name, user.age, user.status, user.ID));
                        break;
                    default:
                        break;
                }
            }
            #endregion
            bool infinite = true;
            while (infinite)
            {
                #region LOGIN
                Console.Clear();
                Console.Write("Enter username => ");
                string username = Console.ReadLine();
                while (!User.Login(userList, username))//verify if the user can log in
                {
                    Console.WriteLine("Username or password is wrong");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Enter username again => ");
                    username = Console.ReadLine();
                }
                #endregion
                int indexUser = 0;
                foreach (User user in userList)
                {
                    if (user.Username == username)//we search the index of the user in the userlist
                    {
                        indexUser = userList.IndexOf(user);
                        break;
                    }
                }
                string choose;
                bool LogOut = false;
                while (!LogOut)
                {
                    int index = 0;
                    switch (userList[indexUser].status)
                    {
                        case "STUDENT"://if the user is a student
                            #region STUDENT
                            foreach (Student student in ListStudents)//we search the index of the student in the student list
                            {
                                if (student.Username == username) 
                                { 
                                    index = ListStudents.IndexOf(student);
                                    break; 
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("1)Check grades");
                            Console.WriteLine("2)Check Timetable");
                            Console.WriteLine("3)Fees");
                            Console.WriteLine("4)Check attendance");
                            Console.WriteLine("5)Modify password");
                            Console.WriteLine("6)Log out");
                            Console.WriteLine("DO NOT FORGET TO LOG OUT TO SAVE THE DATAS");
                            choose = Console.ReadLine();
                            switch (choose)
                            {
                                case "1":
                                    Console.Clear();
                                    ListStudents[index].CheckGrades();
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    ListStudents[index].DisplayTimetable();
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("1)Make payment");
                                    Console.WriteLine("2)Check fees details");
                                    Console.WriteLine("3)Check payment delay");
                                    Console.WriteLine("4)Back");
                                    choose = Console.ReadLine();
                                    switch (choose)
                                    {
                                        case "1":
                                            break;
                                        case "2":
                                            ListStudents[index].feesDetails.FeesInfo();
                                            break;
                                        case "3":
                                            ListStudents[index].feesDetails.PaymentDelay();
                                            break;
                                        case "4":
                                            Console.Clear();
                                            double payment;
                                            do Console.Write("How many do you want to pay => ");
                                            while (!double.TryParse(Console.ReadLine(), out payment));
                                            if (ListStudents[index].feesDetails.MakePayment(payment)) Console.WriteLine("The payment has been made");
                                            else Console.WriteLine("There was an error during the payment");
                                            Console.ReadKey();
                                            break;
                                        default:
                                            break;
                                    }

                                    ListStudents[index].feesDetails.FeesInfo();
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    if (ListStudents[index].studentMissing.Count() != 0)
                                    {
                                        Console.WriteLine("list of course missing :");
                                        foreach (string element in ListStudents[index].studentMissing)
                                        {
                                            Console.WriteLine(element);
                                        }
                                    }
                                    else Console.WriteLine("no course missed");
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    Console.Clear();
                                    Console.Write("Current password => ");
                                    if (Console.ReadLine() == ListStudents[index].UserPassword)
                                    {
                                        Console.Write("New password =>");
                                        ListStudents[index].UserPassword = Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong password");
                                        Console.ReadKey();
                                    }
                                    break;
                                case "6":
                                    LogOut = true;
                                    break;
                                default:
                                    Console.WriteLine("Wrong value");
                                    Console.ReadKey();
                                    break;
                            }
                            break;
                        #endregion
                        case "FACULTY":
                            #region FACULTY
                            foreach (Faculty faculty in ListFaculties)//we search the index of the faculty in the faculty list
                            {
                                if (faculty.Username == username)
                                {
                                    index = ListFaculties.IndexOf(faculty);
                                    break;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("1)Manage grades");
                            Console.WriteLine("2)Modify attendance");
                            Console.WriteLine("3)Change password");
                            Console.WriteLine("4)Check Timetable");
                            Console.WriteLine("5)Log out");
                            Console.WriteLine("DO NOT FORGET TO LOG OUT TO SAVE THE DATAS");
                            choose = Console.ReadLine();
                            switch (choose)
                            {
                                case "1":
                                    bool ExitGrade = false;
                                    while (!ExitGrade)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1)Show grades");
                                        Console.WriteLine("2)Create grades");
                                        Console.WriteLine("3)Modify a grade");
                                        Console.WriteLine("4)Delete grades");
                                        Console.WriteLine("5)Back");
                                        choose = Console.ReadLine();
                                        switch (choose)
                                        {
                                            case "1":
                                                Console.Clear();
                                                Console.Write("What grade? => ");
                                                ListFaculties[index].ShowGrade(Console.ReadLine());
                                                Console.ReadKey();
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.Write("What is the name of the grade? => ");
                                                string gradeName = Console.ReadLine();
                                                Console.Write("Which classroom => ");
                                                ListFaculties[index].CreateGrade(gradeName, Console.ReadLine());
                                                break;
                                            case "3":
                                                Console.Clear();
                                                Console.Write("What grade would you want to modify? => ");
                                                string nameGrade = Console.ReadLine();
                                                Console.Write("Which student => ");
                                                string student = Console.ReadLine();
                                                int grade;
                                                do Console.Write("Value of the grade => ");
                                                while (!int.TryParse(Console.ReadLine(), out grade));
                                                ListFaculties[index].ChangeGrade(student, nameGrade, Convert.ToString(grade));
                                                break;
                                            case "4":
                                                Console.Clear();
                                                Console.Write("What grade would you want to delete => ");
                                                ListFaculties[index].DeleteGrade(Console.ReadLine());
                                                break;
                                            case "5":
                                                ExitGrade = true;
                                                break;
                                            default:
                                                Console.WriteLine("Wrong Value");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;
                                case "2":
                                    bool ExitAttendance = false;
                                    while (!ExitAttendance)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1)Add a missing course to a student");
                                        Console.WriteLine("2)Delete a missing course to a student");
                                        Console.WriteLine("3)Back");
                                        choose = Console.ReadLine();
                                        switch (choose)
                                        {
                                            case "1":
                                                Console.Clear();
                                                Console.Write("Which student (mail) => ");
                                                string studentMailAdd = Console.ReadLine();
                                                Console.Write("Which course => ");
                                                string courseNameAdd = Console.ReadLine();
                                                foreach (Student student in ListStudents)
                                                {
                                                    if (studentMailAdd == student.Username)
                                                    {
                                                        student.AddCourseMissing(courseNameAdd);
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.Write("Which student (mail) => ");
                                                string studentMailDelete = Console.ReadLine();
                                                Console.Write("Which course => ");
                                                string courseNameDelete = Console.ReadLine();
                                                foreach (Student student in ListStudents)
                                                {
                                                    if (studentMailDelete == student.Username)
                                                    {
                                                        student.DeleteCourseMissing(courseNameDelete);
                                                    }
                                                }
                                                break;
                                            case "3":
                                                ExitAttendance = true;
                                                break;
                                            default:
                                                Console.WriteLine("Wrong value");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.Write("Current password => ");
                                    if (Console.ReadLine() == ListFaculties[index].UserPassword)
                                    {
                                        Console.Write("New password => ");
                                        ListFaculties[index].UserPassword = Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong password");
                                        Console.ReadKey();
                                    }
                                    break;
                                case "4":
                                    Console.Clear();
                                    ListFaculties[index].DisplayTimetable();
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    LogOut = true;
                                    break;
                                default:
                                    Console.WriteLine("Wrong value");
                                    Console.ReadKey();
                                    break;
                            }
                            break;
                        #endregion
                        case "ADMIN":
                            #region ADMIN
                            foreach (Admin admin in ListAdmins)
                            {
                                if (admin.Username == username)
                                {
                                    index = ListAdmins.IndexOf(admin);
                                    break;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("1)Manage courses");
                            Console.WriteLine("2)Modify Password");
                            Console.WriteLine("3)Add user");
                            Console.WriteLine("4)Manage Fees");
                            Console.WriteLine("5)Log out");
                            Console.WriteLine("DO NOT FORGET TO LOG OUT TO SAVE THE DATAS");
                            choose = Console.ReadLine();
                            switch (choose)
                            {
                                case "1":

                                    bool ExitCourse = false;
                                    while (!ExitCourse)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1)Create course");
                                        Console.WriteLine("2)Modify course");
                                        Console.WriteLine("3)Delete course");
                                        Console.WriteLine("4)Back");
                                        choose = Console.ReadLine();
                                        switch (choose)
                                        {
                                            case "1":
                                                Course newCourse = ListAdmins[index].Create_Course();
                                                foreach (Faculty faculty in ListFaculties)
                                                {
                                                    if (newCourse.CourseTeacher == faculty.name)
                                                    {
                                                        faculty.coursesTaught.Add(newCourse);
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.Write("Which course => ");
                                                string courseName = Console.ReadLine();
                                                foreach(Faculty faculty in ListFaculties)//check wich faculty has this course
                                                {
                                                    int indexCourse = 0;
                                                    foreach (Course course in faculty.coursesTaught)
                                                    {
                                                        if (courseName == course.CourseName)
                                                        {
                                                            Course changeFaculty = faculty.ModifyCourse(indexCourse);//modify
                                                            if (changeFaculty != null)//if we change the faculty
                                                            {
                                                                foreach (Faculty faculty2 in ListFaculties)//we search the new faculty
                                                                {
                                                                    if(changeFaculty.CourseTeacher == faculty2.name)//then we add and delete the course
                                                                    {
                                                                        faculty2.coursesTaught.Add(changeFaculty);
                                                                        faculty.coursesTaught.Remove(changeFaculty);
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        index++;
                                                    }
                                                }
                                                break;
                                            case "3":
                                                Console.Clear();
                                                Console.Write("Which course => ");
                                                string courseDelete = Console.ReadLine();
                                                foreach(Faculty faculty in ListFaculties)
                                                {
                                                    foreach(Course course in faculty.coursesTaught)
                                                    {
                                                        if (courseDelete == course.CourseName)
                                                        {
                                                            faculty.coursesTaught.Remove(course);
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            case "4":
                                                ExitCourse = true;
                                                break;
                                            default:
                                                Console.WriteLine("Wrong value");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.Write("Current password => ");
                                    if (Console.ReadLine() == ListAdmins[index].UserPassword)
                                    {
                                        Console.Write("New password => ");
                                        ListAdmins[index].UserPassword = Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong password");
                                        Console.ReadKey();
                                    }
                                    break;
                                case "3":
                                    bool ExitUser = false;
                                    while (!ExitUser)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1)Add student");
                                        Console.WriteLine("2)Add faculty");
                                        Console.WriteLine("3)Add Admin");
                                        Console.WriteLine("4)Delete user");
                                        Console.WriteLine("5)Back");
                                        choose = Console.ReadLine();
                                        string newUsername;
                                        string newPassword;
                                        string newName;
                                        int newAge;
                                        int newID;
                                        string[] datasName;
                                        switch (choose)
                                        {
                                            case "1":
                                                Console.Clear();
                                                Console.Write("First name ans last name => ");
                                                newName = Console.ReadLine();
                                                datasName = newName.Split(' ');
                                                newUsername = datasName[0] + "." + datasName[1] + "@gmail.com";
                                                Console.Write("Password => ");
                                                newPassword = Console.ReadLine();
                                                do Console.Write("Age => ");
                                                while (!int.TryParse(Console.ReadLine(), out newAge));
                                                do Console.Write("ID => ");
                                                while (!int.TryParse(Console.ReadLine(),out newID));
                                                ListStudents.Add(new Student(newUsername, newPassword, newName, newAge, "STUDENT", newID));
                                                //we add the student to the grades database
                                                StreamReader numberGrades = new StreamReader("GRADES_DATABASE.csv");
                                                string[] datasGrade = numberGrades.ReadLine().Split(';');
                                                int number = datasGrade.Length - 2;
                                                numberGrades.Close();
                                                StreamWriter AddStudent = new StreamWriter("GRADES_DATABASE.csv", true);
                                                AddStudent.Write("\n" + newUsername + ";" + ListStudents[ListStudents.Count - 1].classroom);
                                                for (int i = 0; i <= number; i++) AddStudent.Write(";");
                                                AddStudent.Close();

                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.Write("First name ans last name => ");
                                                newName = Console.ReadLine();
                                                datasName = newName.Split(' ');
                                                newUsername = datasName[0] + "." + datasName[1] + "@gmail.com";
                                                Console.Write("Password => ");
                                                newPassword = Console.ReadLine();
                                                do Console.Write("Age => ");
                                                while (!int.TryParse(Console.ReadLine(), out newAge));
                                                do Console.Write("ID => ");
                                                while (!int.TryParse(Console.ReadLine(), out newID));
                                                ListStudents.Add(new Student(newUsername, newPassword, newName, newAge, "FACULTY", newID));
                                                break;
                                            case "3":
                                                Console.Clear();
                                                Console.Write("First name ans last name => ");
                                                newName = Console.ReadLine();
                                                datasName = newName.Split(' ');
                                                newUsername = datasName[0] + "." + datasName[1] + "@gmail.com";
                                                Console.Write("Password => ");
                                                newPassword = Console.ReadLine();
                                                do Console.Write("Age => ");
                                                while (!int.TryParse(Console.ReadLine(), out newAge));
                                                do Console.Write("ID => ");
                                                while (!int.TryParse(Console.ReadLine(), out newID));
                                                ListStudents.Add(new Student(newUsername, newPassword, newName, newAge, "ADMIN", newID));
                                                break;
                                            case "4":
                                                Console.Clear();
                                                Console.Write("user deleted (mail)=> ");
                                                string userDelete = Console.ReadLine();
                                                foreach(User user in userList)
                                                {
                                                    Console.WriteLine("hey");
                                                    if (userDelete == user.Username)
                                                    {
                                                        switch (user.status)
                                                        {
                                                            case "STUDENT":
                                                                foreach (Student student in ListStudents)
                                                                {
                                                                    if (userDelete == student.Username)
                                                                    {
                                                                        ListStudents.Remove(student);
                                                                        break;
                                                                    }
                                                                }
                                                                break;
                                                            case "FACULTY":
                                                                foreach (Faculty faculty in ListFaculties)
                                                                {
                                                                    if (userDelete == faculty.Username)
                                                                    {
                                                                        ListFaculties.Remove(faculty);
                                                                        break;
                                                                    }
                                                                }
                                                                break;
                                                            case "ADMIN":
                                                                foreach (Admin admin in ListAdmins)
                                                                {
                                                                    if (userDelete == admin.Username)
                                                                    {
                                                                        ListAdmins.Remove(admin);
                                                                        break;
                                                                    }
                                                                }
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                }
                                                break;
                                            case "5":
                                                ExitUser = true;
                                                break;
                                            default:
                                                Console.WriteLine("Wrong value");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;
                                case "4":
                                    bool ExitFees = false;
                                    while (!ExitFees)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1)Change the limit date");
                                        Console.WriteLine("2)change the payment due");
                                        Console.WriteLine("3)Back");
                                        choose = Console.ReadLine();
                                        string studentName;
                                        switch (choose)
                                        {
                                            case "1":
                                                Console.Clear();
                                                Console.Write("Which student (mail)=> ");
                                                studentName = Console.ReadLine();
                                                foreach(Student student in ListStudents)
                                                {
                                                    if (studentName == student.Username)
                                                    {
                                                        int newYear;
                                                        do Console.Write("Limit year => ");
                                                        while (!int.TryParse(Console.ReadLine(), out newYear));
                                                        int newMonth;
                                                        do Console.Write("Limit month => ");
                                                        while (!int.TryParse(Console.ReadLine(), out newMonth));
                                                        int newDay;
                                                        do Console.Write("Limit day => ");
                                                        while (!int.TryParse(Console.ReadLine(), out newDay));
                                                        student.feesDetails.LimitDate = new DateTime(newYear, newMonth, newDay);
                                                        break;
                                                    }
                                                    else if (student.Equals(ListStudents.Last())) Console.WriteLine("This student doesn't exist");
                                                }
                                                Console.ReadKey();
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.Write("Which student (mail) => ");
                                                studentName = Console.ReadLine();
                                                foreach (Student student in ListStudents)
                                                {
                                                    if (studentName == student.Username)
                                                    {
                                                        int newPaymentDue;
                                                        do Console.Write("new payment due => ");
                                                        while (!int.TryParse(Console.ReadLine(), out newPaymentDue));
                                                        student.feesDetails.PaymentDue=newPaymentDue;
                                                        break;
                                                    }
                                                    else if (student.Equals(ListStudents.Last())) Console.WriteLine("This student doesn't exist");
                                                }
                                                Console.ReadKey();
                                                break;
                                            case "3":
                                                ExitFees = true;
                                                break;
                                            default:
                                                Console.WriteLine("Wrong value");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;
                                case "5":
                                    LogOut = true;
                                    break;
                                default:
                                    Console.WriteLine("Wrong value");
                                    Console.ReadKey();
                                    break;
                            }
                            break;
                        #endregion
                    }
                }

                #region REWRITE DATABASE
                string rewriteStudent = "USERNAME;YEAR;CLASSROOM;ACCOUNTBALANCE;PAYMENTSTATUS;PAYMENTDUE;MISSEDCLASSES\n";
                string rewriteUser = "USERNAME;PASSWORD;NAME;AGE;STATUS;ID\n";
                string rewriteCourse = "COURSENAME;CONTENT;COURSETEACHER;COURSEDAY;STARTINGHOUR;ENDINGHOUR;CLASSROOM\n";
                foreach(Student student in ListStudents)
                {
                    rewriteStudent = rewriteStudent + student.Username + ";" + student.year + ";" + student.classroom + ";" + student.feesDetails.AccountBalance + ";" + student.feesDetails.PaymentStatus + ";" + student.feesDetails.PaymentDue + ";";
                    if (student.studentMissing != null)
                    {
                        foreach (string course in student.studentMissing)
                        {
                            rewriteStudent = rewriteStudent + course + ",";
                        }
                    }
                    else rewriteStudent = rewriteStudent + ";";
                    rewriteUser = rewriteUser + student.Username + ";" + student.UserPassword + ";" + student.name + ";" + student.age + ";" + student.status + ";" + student.ID + "\n";
                    if (!student.Equals(ListStudents.Last())) rewriteStudent = rewriteStudent + "\n";//if we finish a line, we go to the next line (except the last line)
                }
                foreach(Faculty faculty in ListFaculties)
                {
                    rewriteUser = rewriteUser + faculty.Username + ";" + faculty.UserPassword + ";" + faculty.name + ";" + faculty.age + ";" + faculty.status + ";" + faculty.ID + "\n";
                    if (faculty.coursesTaught != null)
                    {
                        foreach (Course course in faculty.coursesTaught)
                        {
                            rewriteCourse = rewriteCourse + course.CourseName + ";" + course.Content + ";" + course.CourseTeacher + ";" + course.CourseDay + ";" + course.StartingHour + ";" + course.EndingHour + ";" + course.classroom;
                            if (!course.Equals(faculty.coursesTaught.Last())) rewriteCourse = rewriteCourse + "\n";
                        }
                        if (!faculty.Equals(ListFaculties.Last())) rewriteCourse = rewriteCourse + "\n";
                    }
                }
                foreach(Admin admin in ListAdmins)
                {
                    rewriteUser = rewriteUser + admin.Username + ";" + admin.UserPassword + ";" + admin.name + ";" + admin.age + ";" + admin.status + ";" + admin.ID;
                    if (!admin.Equals(ListAdmins.Last())) rewriteUser = rewriteUser + "\n";
                }
                StreamWriter rewriteData = new StreamWriter("USERS_DATABASE.csv");
                rewriteData.Write(rewriteUser);
                rewriteData.Close();
                rewriteData = new StreamWriter("STUDENT_DATABASE.csv");
                rewriteData.Write(rewriteStudent);
                rewriteData.Close();
                rewriteData = new StreamWriter("COURSE_DATABASE.csv");
                rewriteData.Write(rewriteCourse);
                rewriteData.Close();
                #endregion
            }

            Console.ReadKey();
        }
    }
}
