using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Projet
{
    class Program
    {
        static void Main(string[] args)
        {
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
            foreach(User user in userList)
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
                            Console.WriteLine("Joseph Harwood is blocking the way, you can do nothing");
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
                                        Console.WriteLine("3)Back");
                                        choose = Console.ReadLine();
                                        switch (choose)
                                        {
                                            case "1":
                                                Course course = ListAdmins[index].Create_Course();
                                                foreach (Faculty faculty in ListFaculties)
                                                {
                                                    if (course.CourseTeacher == faculty.name)
                                                    {
                                                        faculty.coursesTaught.Add(course);
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "2":
                                                break;
                                            case "3":
                                                ExitCourse = true;
                                                break;
                                            default:
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
                                        Console.WriteLine("4)Back");
                                        choose = Console.ReadLine();
                                        switch (choose)
                                        {
                                            case "1":
                                                break;
                                            case "2":
                                                break;
                                            case "3":
                                                break;
                                            case "4":
                                                ExitUser = true;
                                                break;
                                        }
                                    }
                                    
                                    
                                    break;
                                case "4":
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


            }
            
            Console.ReadKey();
        }
    }
}
