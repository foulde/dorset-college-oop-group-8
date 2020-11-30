using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace POO_Projet
{
    class Classroom
    {
        public string classroomName { get; set; }
        public List<Student> classroom { get; set; }
        public Timetable timetable { get; set; }


        public Classroom(string _classroomName, Timetable _timetable, List<Student> _classroom)
        {

            timetable = _timetable;
            classroomName = _classroomName;
            classroom = _classroom;

        }


        public void AddStudent(Student a)
        {
            classroom.Add(a);
            //a.ClassroomName = this.classroomName;

        }
        public void RemoveStudent(Student a)
        {
            classroom.Remove(a);
            //a.ClassroomName = "none";
        }




    }
}
