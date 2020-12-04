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
            #region ESPACE DETENTE
            /*
            int noteDo = 262;
            int noteRe = 294;
            int noteRe2 = 587;
            int noteMi = 330;
            int noteFa = 349;
            int noteFa2 = 698;
            int noteSol = 392;
            int noteLa = 440;
            int noteSi = 494;
            int noir = 400;
            int blanche = 800;
            int croche = 200;
            int doubleCroche = 100;
            //OBJECTION
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteRe2, croche);
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteRe2, croche);
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteRe2, croche);
            Thread.Sleep(croche + noir + blanche);
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteRe2, croche);
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteRe2, croche);
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteRe2, croche);
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteRe2, croche);
            Console.Beep(noteRe, croche);
            Console.Beep(noteSol, croche);
            Console.Beep(noteFa2, croche);
            */
            #endregion

            #region LECTURE DATABASE
            StreamReader LectureDataBase = new StreamReader("USERS_DATABASE.csv");

            List<User> userList = new List<User>();
            string[] datas;
            LectureDataBase.ReadLine();
            while (LectureDataBase.Peek() > 0)
            {
                datas = LectureDataBase.ReadLine().Split(';');
                userList.Add(new User(datas[0], datas[1], datas[2], Convert.ToInt32(datas[3]), datas[4], Convert.ToInt32(datas[5])));
            }
            LectureDataBase.Close();

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
                while (User.Login(userList, username) == false)
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
                    if (user.Username == username)
                    {
                        indexUser = userList.IndexOf(user);
                        break;
                    }
                }
                string choose;

                bool LogOut = false;
                while (!LogOut)
                {
                    int index;
                    switch (userList[indexUser].status)
                    {
                        case "STUDENT":
                            #region STUDENT
                            index = 0;
                            foreach (User student in ListStudents)
                            {
                                if (student.Username == username) break;
                                index++;
                            }
                            Console.Clear();
                            Console.WriteLine("1)Check grades");
                            Console.WriteLine("2)Check Timetable");
                            Console.WriteLine("3)Fees information");
                            Console.WriteLine("4)Check attendance");
                            Console.WriteLine("5)Modify password");
                            Console.WriteLine("6)Log out");
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
                                    Console.WriteLine("Current password");
                                    if (Console.ReadLine() == ListStudents[index].UserPassword)
                                    {
                                        Console.WriteLine("New password");
                                        ListStudents[index].UserPassword = Console.ReadLine();
                                    }
                                    else Console.WriteLine("Wrong password");
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
                            index = 0;
                            foreach (User faculty in ListFaculties)
                            {
                                if (faculty.Username == username) break;
                                index++;
                            }
                            Console.Clear();
                            Console.WriteLine("1)Manage grades");
                            Console.WriteLine("2)Modify attendance");
                            Console.WriteLine("3)Change password");
                            Console.WriteLine("4)Check Timetable");
                            Console.WriteLine("5)Log out");
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
                                        //delete grade
                                        Console.WriteLine("4)Back");
                                        choose = Console.ReadLine();
                                        switch (choose)
                                        {
                                            case "1":
                                                Console.Clear();
                                                Console.WriteLine("What grade? => ");
                                                ListFaculties[index].Show_Grade(Console.ReadLine());
                                                Console.ReadKey();
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.WriteLine("What is the name of the grade? => ");
                                                ListFaculties[index].Create_Grade(Console.ReadLine());
                                                break;
                                            case "3":
                                                Console.Clear();
                                                Console.WriteLine("What grade would you want to modify? => ");
                                                string nameGrade = Console.ReadLine();
                                                Console.WriteLine("Which student =>");
                                                string student = Console.ReadLine();
                                                Console.WriteLine("Value of the grade =>");
                                                string grade = Console.ReadLine();
                                                ListFaculties[index].Change_Grade(student, nameGrade, grade);
                                                break;
                                            case "4":
                                                ExitGrade = true;
                                                break;
                                            default:
                                                Console.WriteLine("Wrong Value");
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
                                                Console.Write("Which student (mail) =>");
                                                string studentMailAdd = Console.ReadLine();
                                                Console.Write("Which course =>");
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
                                                Console.Write("Which student (mail) =>");
                                                string studentMailDelete = Console.ReadLine();
                                                Console.Write("Which course =>");
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
                                    Console.WriteLine("Current password");
                                    if (Console.ReadLine() == ListFaculties[index].UserPassword)
                                    {
                                        Console.WriteLine("New password");
                                        ListFaculties[index].UserPassword = Console.ReadLine();
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
                            index = 0;
                            foreach (User admin in ListAdmins)
                            {
                                if (admin.Username == username) break;
                                index++;
                            }
                            Console.Clear();
                            Console.WriteLine("1)Manage courses");
                            Console.WriteLine("2)Modify Password");
                            Console.WriteLine("3)Add user");
                            Console.WriteLine("4)Manage Fees");
                            Console.WriteLine("5)Log out");
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
                                        //delete a course
                                        Console.WriteLine("3)Back");
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
                                                Console.WriteLine("Which course =>");
                                                string courseName = Console.ReadLine();
                                                foreach(Faculty faculty in ListFaculties)
                                                {
                                                    int indexCourse = 0;
                                                    foreach (Course course in faculty.coursesTaught)
                                                    {
                                                        if (courseName == course.CourseName)
                                                        {
                                                            Course changeFaculty = faculty.ModifyCourse(indexCourse);
                                                            if (changeFaculty != null)
                                                            {
                                                                foreach (Faculty faculty2 in ListFaculties)
                                                                {
                                                                    if(changeFaculty.CourseTeacher == faculty2.name)
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
                                    Console.WriteLine("Current password");
                                    if (Console.ReadLine() == ListAdmins[index].UserPassword)
                                    {
                                        Console.WriteLine("New password");
                                        ListAdmins[index].UserPassword = Console.ReadLine();
                                    }
                                    else Console.WriteLine("Wrong password");
                                    break;
                                case "3":
                                    bool ExitUser = false;
                                    while (!ExitUser)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1)Add student");
                                        Console.WriteLine("2)Add faculty");
                                        Console.WriteLine("3)Add Admin");
                                        //delete user
                                        Console.WriteLine("4)Back");
                                        choose = Console.ReadLine();
                                        string newUsername;
                                        string newPassword;
                                        string newName;
                                        int newAge;
                                        int newID;
                                        switch (choose)
                                        {
                                            case "1":
                                                Console.Clear();
                                                Console.Write("new username (mail) =>");
                                                newUsername = Console.ReadLine();
                                                Console.Write("new password =>");
                                                newPassword = Console.ReadLine();
                                                Console.Write("new name =>");
                                                newName = Console.ReadLine();
                                                Console.Write("new age");
                                                newAge = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("new ID");//ne doit pas etre le meme qu'un autre
                                                newID = Convert.ToInt32(Console.ReadLine());
                                                ListStudents.Add(new Student(newUsername, newPassword, newName, newAge, "STUDENT", newID));
                                                //le rajouter dans les note
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.Write("new username (mail) =>");
                                                newUsername = Console.ReadLine();
                                                Console.Write("new password =>");
                                                newPassword = Console.ReadLine();
                                                Console.Write("new name =>");
                                                newName = Console.ReadLine();
                                                Console.Write("new age");
                                                newAge = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("new ID");//ne doit pas etre le meme qu'un autre
                                                newID = Convert.ToInt32(Console.ReadLine());
                                                ListStudents.Add(new Student(newUsername, newPassword, newName, newAge, "FACULTY", newID));
                                                break;
                                            case "3":
                                                Console.Clear();
                                                Console.Write("new username (mail) =>");
                                                newUsername = Console.ReadLine();
                                                Console.Write("new password =>");
                                                newPassword = Console.ReadLine();
                                                Console.Write("new name =>");
                                                newName = Console.ReadLine();
                                                Console.Write("new age");
                                                newAge = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("new ID");//ne doit pas etre le meme qu'un autre
                                                newID = Convert.ToInt32(Console.ReadLine());
                                                ListStudents.Add(new Student(newUsername, newPassword, newName, newAge, "ADMIN", newID));
                                                break;
                                            case "4":
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
                                                Console.Write("Which student (mail)=>");
                                                studentName = Console.ReadLine();
                                                foreach(Student student in ListStudents)
                                                {
                                                    if (studentName == student.Username)
                                                    {
                                                        Console.Write("New limit date (year,month,day)=>");//bien vérifier que l'entrer respect
                                                        string[] datasLimitDate = Console.ReadLine().Split(',');
                                                        student.feesDetails.LimitDate = new DateTime(Convert.ToInt32(datasLimitDate[0]), Convert.ToInt32(datasLimitDate[1]), Convert.ToInt32(datasLimitDate[2]));
                                                        break;
                                                    }
                                                    else if (student.Equals(ListStudents.Last())) Console.WriteLine("This student doesn't exist");
                                                }
                                                Console.ReadKey();
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.Write("Which student (mail)=>");
                                                studentName = Console.ReadLine();
                                                foreach (Student student in ListStudents)
                                                {
                                                    if (studentName == student.Username)
                                                    {
                                                        Console.Write("new payment due =>");
                                                        int newPaymentDue=Convert.ToInt32(Console.ReadLine());
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
                //string rewriteGrade = "";
                foreach(Student student in ListStudents)
                {
                    rewriteStudent = rewriteStudent + student.Username + ";" + student.year + ";" + student.classroom + ";" + student.feesDetails.AccountBalance + ";" + student.feesDetails.PaymentStatus + ";" + student.feesDetails.PaymentDue;
                    if (student.studentMissing != null)
                    {
                        foreach (string course in student.studentMissing)
                        {
                            rewriteStudent = rewriteStudent + course + ",";
                        }
                    }
                    else rewriteStudent = rewriteStudent + ";";
                    rewriteUser = rewriteUser + student.Username + ";" + student.UserPassword + ";" + student.name + ";" + student.age + ";" + student.status + ";" + student.ID + "\n";
                    if (!student.Equals(ListStudents.Last())) rewriteStudent = rewriteStudent + "\n";
                }
                foreach(Faculty faculty in ListFaculties)
                {
                    rewriteUser = rewriteUser + faculty.Username + ";" + faculty.UserPassword + ";" + faculty.name + ";" + faculty.age + ";" + faculty.status + ";" + faculty.ID + "\n";
                    if (faculty.coursesTaught != null)
                    {
                        foreach (Course course in faculty.coursesTaught)
                        {
                            rewriteCourse = rewriteCourse + course.CourseName + ";" + course.Content + ";" + course.CourseTeacher + ";" + course.CourseDay + ";" + course.StartingHour + ";" + course.EndingHour + ";" + course.classroom + "\n";
                            if (!course.Equals(faculty.coursesTaught.Last())) rewriteCourse = rewriteCourse + "\n";
                        }
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
