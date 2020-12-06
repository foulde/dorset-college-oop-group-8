using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_POO
{
    class User
    {
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string status { get; set; }
        public int ID { get; set; }

        public User(string Username, string UserPassword, string name, int age, string status, int ID)
        {
            this.Username = Username;
            this.UserPassword = UserPassword;
            this.name = name;
            this.age = age;
            this.status = status;
            this.ID = ID;
        }

        public List<User> Users;

        static public bool Login(List<User> UsersList, string username)
        {

            bool login = false;
            foreach (User user in UsersList)
            {
                if (user.Username == username)
                {
                    Console.Write("Enter password => ");
                    string password = Console.ReadLine();
                    if (password == user.UserPassword) { login = true; break; }
                }
            }
            return login;
        }


    }
}
