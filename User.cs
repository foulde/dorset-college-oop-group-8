using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Project
{
    class User
    {
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }

        public SortedList<string, User> FacultyUsers;
        public SortedList<string, User> Administrators;
        public SortedList<string, User> Students;
        public SortedList<string, User> Users;
        public bool Login1(SortedList<string, User> Students, SortedList<string, User> Administrators, SortedList<string, User> FacultyUsers, string username, string password, string usertype)
        {
            bool login = false;
            if(usertype=="Faculty")
            {
                if (FacultyUsers.ContainsKey(username) != true) { }

                else if(password==FacultyUsers[FacultyUsers.GetIndexOfKey(username)].UserPassword)
                {   login = true;   }
            }

            else if (usertype == "Administrator")
            {
                if (Administrators.ContainsKey(username) != true) { }

                else if (password == Administrators[Administrators.GetIndexOfKey(username)].UserPassword)
                { login = true; }
            }

            else if (usertype == "Student")
            {
                if (Students.ContainsKey(username) != true) { }

                else if (password == Students[Students.GetIndexOfKey(username)].UserPassword)
                { login = true; }
            }

            return login;
        }

        public bool Login2(SortedList<string, User> Users, string username, string password)
        {
            bool login = false;
            if (Users.ContainsKey(username) != true) { }

            else if (password == Students[Users.GetIndexOfKey(username)].UserPassword)
            { login = true; }

            return login;
        }


    }
}
