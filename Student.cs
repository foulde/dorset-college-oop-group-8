using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Project
{
    class Student
    {
        private string studentName;
        private string studentAdress;
        private string studentMail;

        public Student(string Name, string Adress, string Mail)
        {
            this.studentName = Name;
            this.studentAdress = Adress;
            this.studentMail = Mail;
        }

        public string StudentName
        {
            get { return this.studentName; }
            set { studentName = value; }
        }
        public string StudentAdress
        {
            get { return this.studentAdress; }
            set { studentAdress = value; }
        }
        public string StudentMail
        {
            get { return this.studentMail; }
            set { studentMail = value; }
        }
    }
}
