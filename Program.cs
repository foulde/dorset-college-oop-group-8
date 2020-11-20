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

            Console.ReadLine();
            Console.WriteLine("enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("enter your password ");
            // call the method identification 
            //with those two information the method inspect the data base searching for the associeted user 
            //it find it in the list of predefined user and get the most important information which is :
            // Which type of user he is ? Student , Faculty or Administrator 
            //Then it display the user website (personnal board ) 
            // there is three type of screen display : student , faculty , administrator


            //CASE STUDENT :
            // ask which info he want to access between : TimeTable , Grades , Courses      " maybe the user should be able to go back to the basic screen "

            // CASE 1: the user choose TIMETABLE
            // the user will have a display of all the course in his week a table containing for each day the program of the day 
            // so course will stay the same through out the year no need to udapte the timetable of a student
            // the timetable is composed of a table and each days is represented as a column of courses sorted by their horary 
            // a course displayed must shows the name of the course and it starting and ending hours 


            //     ////EXAMPLE/////

            ////Tuesday, Wednesday, Thursday, Friday, and Saturday.
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////      MONDAY       ///     TUESDAY        ///       WEDNESDAY      ///      THURSDAY       ///      FRIDAY       ///      SATURDAY       ////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////DATA STRUCUTRE     ///                    ///                      ///                     ///                   ///                     ////
            ////8:00 AM to 10:30 AM///                    ///                      ///                     ///                   ///                     ////
            /////////////////////////////////////////////////                      ///                     ///                   ///                     ////
            ////                   ///   POO ALGORITHM    ///                      ///                     ///                   ///                     ////
            ////                   ///10:30 AM to 12:30 AM///                      ///                     ///                   ///                     ////
            ////                   //////////////////////////                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            ////                   ///                    ///                      ///                     ///                   ///                     ////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////







            //CASE 2: the user choose grades 



            /// this method call the following data : current list of grades , list of courses followed by the student 
            /// grades are interfaces that are common to student and professor 
            /// grades contain the score at the exams the title of the grades and the coefficient and the name of the student  and the name of the course 

            /// the list of the grades are stored in the databased they are accessed and uploaded in a list created for each courses 
            /// grades are comon to student and faculty 
            /// the student grade page acces the student's grades with a method that search all the grades wearing the student name as a tag 
            /// a program is then called to display the grades sharing the same course name 
            /// 



            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                             SEMESTER 1                                                                  ////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                                                                                                         //// 
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////            
            /////////////ALGOO POO ///////  15/20 ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                                                                                                         ////
            ////    ***title*** ,***date***,coefficient: ***coefficient*** :  *** grade***                                                               ////
            ////                                                                                                                                         ////
            ////                                                                                                                                         ////
            ////   exam 1, 20/11/2020 ,coefficient:3         :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz 1, 25/11/2020 ,coefficient:1        :           6/20                                                                            ////
            ////   exam 2 , 1/12/2020 ,coefficient:.2.5:                 17/20                                                                           ////
            ////                                                                                                                                         ////
            ////   group project , 2/12/2020 ,coefficient:3  :           6/20                                                                            ////
            ////   final exam , 10/12/2020 ,coefficient:4    :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz, 14/12/2020 ,coefficient:1          :           6/20                                                                            ////
            ////   exam , 20/11/2020 ,coefficient:3          :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz, 14/12/2020 ,coefficient:1          :           6/20                                                                            ////
            ////                                                                                                                                         ////            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////FLUID MECHANICS ///////  14/20 /////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                                                                                                         ////
            ////   exam 1, 20/11/2020 ,coefficient:3         :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz 1, 25/11/2020 ,coefficient:1        :           6/20                                                                            ////
            ////   exam 2 , 1/12/2020 ,coefficient:.2.5:                 17/20                                                                           ////
            ////                                                                                                                                         ////
            ////   group project , 2/12/2020 ,coefficient:3  :           6/20                                                                            ////
            ////   final exam , 10/12/2020 ,coefficient:4    :           15/20                                                                           ////
            ////                                                                                                                                         ////                                                                                                                                        ////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                                                                                                         ////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                             SEMESTER 2                                                                  ////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                                                                                                         //// 
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////ALGOO POO ///////  15/20 ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                                                                                                         ////
            ////    ***title*** ,***date***,coefficient: ***coefficient*** :  *** grade***                                                               ////
            ////                                                                                                                                         ////
            ////                                                                                                                                         ////
            ////   exam 1, 20/11/2020 ,coefficient:3         :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz 1, 25/11/2020 ,coefficient:1        :           6/20                                                                            ////
            ////   exam 2 , 1/12/2020 ,coefficient:.2.5:                 17/20                                                                           ////
            ////                                                                                                                                         ////
            ////   group project , 2/12/2020 ,coefficient:3  :           6/20                                                                            ////
            ////   final exam , 10/12/2020 ,coefficient:4    :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz, 14/12/2020 ,coefficient:1          :           6/20                                                                            ////
            ////   exam , 20/11/2020 ,coefficient:3          :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz, 14/12/2020 ,coefficient:1          :           6/20                                                                            ////
            ////                                                                                                                                         ////            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////FLUID MECHANICS ///////  14/20 /////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////                                                                                                                                         ////
            ////   exam 1, 20/11/2020 ,coefficient:3         :           15/20                                                                           ////
            ////                                                                                                                                         ////
            ////   quizz 1, 25/11/2020 ,coefficient:1        :           6/20                                                                            ////
            ////   exam 2 , 1/12/2020 ,coefficient:.2.5:                 17/20                                                                           ////
            ////                                                                                                                                         ////
            ////   group project , 2/12/2020 ,coefficient:3  :           6/20                                                                            ////
            ////   final exam , 10/12/2020 ,coefficient:4    :           15/20                                                                           ////
            ////                                                                                                                                         ////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
           
















            // the user see first :
            // the 1st semester grades 
            // in which there is every courses 
            // under which there is a column of every grades he has received the newest grades appear at the bottom of the columns 
            // the grade display 

            //     ////EXAMPLE/////







        }
    }
}
