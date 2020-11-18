using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Project_team8
{
    class User
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }

        private bool access_autorisation = false;

        public User (string _username, string _password )
        {
            Username = _username;
            Password = _password;
           
        }

        public bool Login(List<User> UserList, string username, string password, string usertype)
        {
            bool login = false;
           

            foreach (User anuser in UserList)
            {
                if( anuser.Username==username && anuser.Password==password)
                {
                    this.UserType = anuser.UserType;
                    login = true;
                    access_autorisation = true;
                }
            }

            return login;
        }

    }
}
