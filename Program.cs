using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Project_team8
{
    class Program
    {
        //static void 
        static void Main(string[] args)
        {

            User togekiss = new User("toge","flinch ");
            User stalin = new User("leader", "spread the red ");
            User anakin = new User("darkvador", "your daddy");
            User latoupie = new User("toupie", "ta daronne");
            User titi = new User("poussin", "jaune");


            togekiss.UserType = UserTypes.Student;
            stalin.UserType = UserTypes.Administrator;
            anakin.UserType = UserTypes.Faculty;
            latoupie.UserType = UserTypes.Faculty;
            titi.UserType = UserTypes.Student;


            List<User> leskassos = new List<User>();
            leskassos.Add(togekiss);
            leskassos.Add(stalin);
            leskassos.Add(anakin);
            leskassos.Add(latoupie);
            leskassos.Add(titi);

        }
    }
}
