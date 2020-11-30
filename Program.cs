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
            StreamReader LectureDataBase = new StreamReader("USERS_DATABASE.csv");
            
            List<User> userList = new List<User>();
            string[] datas;
            LectureDataBase.ReadLine();
            while (LectureDataBase.Peek() > 0)
            {
                datas = LectureDataBase.ReadLine().Split(';');
                //datas[6]=feestatus pas utile
                userList.Add(new User(datas[0], datas[1], datas[2], Convert.ToInt32(datas[3]), datas[5],Convert.ToInt32(datas[7])));
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
            int index = 0;
            foreach(User user in userList)
            {
                if(user.Username==username)
                {
                    index = userList.IndexOf(user);
                    break;
                }
            }
            int choose;
            switch (userList[index].status)
            {
                case "STUDENT":
                    foreach (User student in ListStudents)
                    {
                        if (student.Username == username)
                        {
                            index = userList.IndexOf(student);
                            break;
                        }
                    }
                    Console.WriteLine("1)Check grades");
                    Console.WriteLine("2)Check Timetable");
                    Console.WriteLine("3)Fees information");
                    Console.WriteLine("4)Check attendance");
                    Console.WriteLine("5)Modify personal informations");
                    Console.WriteLine("6)Log out");
                    choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            
                            break;
                        case 2:
                            ListStudents[index].DisplayTimetable();
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            ListStudents[index].ToString();
                            break;
                        case 6:
                            break;
                        default:
                            break;
                    }
                    break;
                case "FACULTY":
                    foreach (User faculty in ListFaculties)
                    {
                        if (faculty.Username == username)
                        {
                            index = userList.IndexOf(faculty);
                            break;
                        }
                    }
                    Console.WriteLine("1)Manage grades");
                    Console.WriteLine("2)Attendance");
                    Console.WriteLine("3)Modify personal informations");
                    Console.WriteLine("4)Log out");
                    choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("1)Show grades");
                            Console.WriteLine("2)Create grades");
                            Console.WriteLine("3)Modify a grade");
                            choose = Convert.ToInt32(Console.ReadLine());
                            switch (choose)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("What grade? => ");
                                    ListFaculties[index].Show_Grade(Console.ReadLine());
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("What is the name of the grade? => ");
                                    ListFaculties[index].Create_Grade(Console.ReadLine());
                                    break;
                                case 3:
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        default:
                            break;
                    }
                    break;
                case "ADMIN":
                    foreach (User admin in ListAdmins)
                    {
                        if (admin.Username == username)
                        {
                            index = userList.IndexOf(admin);
                            break;
                        }
                    }
                    Console.WriteLine("welcome Joseph Harwood");
                    Console.WriteLine("1)Manage timetables");
                    Console.WriteLine("2)Manage courses");
                    Console.WriteLine("3)Modify personal informations");
                    Console.WriteLine("4)Add user");
                    Console.WriteLine("5)Manage Fees");
                    Console.WriteLine("6)Log out");
                    choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        default:
                            break;
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}
