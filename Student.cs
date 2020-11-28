using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Team_8
{
    class Student
    {
        private string first_name { get; set; }
        private string last_name { get; set; }
        private long ID { get; set; }
        private string email { get; set; }
        public List<Courses> studentMissing { get; set; }
        private string adress { get; set; }
        private Fees feesDetails { get; set; }
        private string classroom { get; set; }

        public Student(string first_name, string last_name, long ID, string email, List<Courses> studentMissing, string adress, Fees feesDetails, string classroom)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.ID = ID;
            this.email = email;
            this.studentMissing = studentMissing;
            this.adress = adress;
            this.feesDetails = feesDetails;
            this.classroom = classroom;
        }

        public string studentDetails()
        {
            string s = $"{this.first_name} {this.last_name}, Group {this.classroom}\n Student ID : {this.ID}\n {this.email}\n Adress : {this.adress}\n Payment status : {this.feesDetails.PaymentStatus}";
            return s;
        }

    }
}
