using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Projet
{
    class Faculty:User
    {
        public string adress { get; set; }
        public List<Course> coursesTaught { get; set; }

        public Faculty(string Username, string UserPassword, string name, int age, string status, int ID)
            : base (Username, UserPassword, name, age, status, ID)
        {
            
            StreamReader LectCourse = new StreamReader("Courses.csv");
            while (LectCourse.Peek() > 0)
            {
                string[] datas = LectCourse.ReadLine().Split(';');
                if (Username == datas[2])
                {
                    coursesTaught.Add(new Course(datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], datas[6]));
                }
            }
            LectCourse.Close();
            
        }
        
        public void Show_Grade(string GradeName)
        {
            StreamReader LectGrade = new StreamReader("Grades.csv");


            char sep = ';';
            string line = "";
            string[] datas;



            int placeNote = 0;
            bool verif = false;
            datas = LectGrade.ReadLine().Split(';');
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] == GradeName)
                {
                    verif = true;
                    placeNote = i;
                    break;
                }
            }
            if (verif)
            {
                while (LectGrade.Peek() > 0)
                {
                    line = LectGrade.ReadLine();
                    datas = line.Split(sep);
                    Console.WriteLine(datas[0] + "   " + datas[placeNote]);
                }
            }
            else Console.WriteLine("This Grade doesn't existe");
            LectGrade.Close();
        }
        public void Change_Grade(string student, string gradeName, string grade)
        {
            string finalText = null;
            StreamReader LectureGrade = new StreamReader("Grades.csv");
            string line = null;
            string[] datas2;
            int nbline = 0;

            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                nbline++;
            }
            LectureGrade.Close();
            LectureGrade = new StreamReader("Grades.csv");
            string[][] datas = new string[nbline][];
            int i = 0;
            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                datas2 = line.Split(';');
                datas[i] = datas2;
                i++;
            }
            int column = 0;
            for (int j = 0; j < datas[0].Length; j++)
            {
                if (datas[0][j] == gradeName)
                {
                    column = j;
                    break;
                }
            }
            int lineGrade = 0;
            for (int k = 0; k < datas.Length; k++)
            {
                if (datas[k][0] == student)
                {
                    lineGrade = k;
                    break;
                }
            }
            LectureGrade.Close();
            if (lineGrade != 0 && column != 0)
            {
                datas[lineGrade][column] = grade;
            }
            else Console.WriteLine("The student or the name of the grade doesn't exist");
            for (int j = 0; j < datas.Length; j++)
            {
                for (int k = 0; k < datas[j].Length; k++)
                {
                    finalText = finalText + datas[j][k] + ";";
                }
                finalText = finalText + "\r\n";
            }
            StreamWriter WriteGrades = new StreamWriter("Grades.csv");
            WriteGrades.WriteLine(finalText);
            WriteGrades.Close();
        }
        public void Course_Attendance()
        {

        }
        public void Create_Grade(string gradeName)
        {
            string finalText = null;
            StreamReader LectureGrade = new StreamReader("Grades.csv");
            string line = null;
            string[] datas2;
            int nbline = 0;

            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                nbline++;
            }
            LectureGrade.Close();
            LectureGrade = new StreamReader("Grades.csv");
            string[][] datas = new string[nbline][];
            int i = 0;
            while (LectureGrade.Peek() > 0)
            {
                line = LectureGrade.ReadLine();
                datas2 = line.Split(';');
                datas[i] = new string[datas2.Length + 1];
                if (i == 0) datas[0][datas[0].Length - 1] = gradeName;
                else
                {
                    Console.Write("What is the grade for " + datas2[0] + "=>");
                    datas[i][datas[i].Length - 1] = Console.ReadLine();
                }
                for (int j = 0; j < datas2.Length; j++)
                {
                    datas[i][j] = datas2[j];
                }
                i++;
            }
            LectureGrade.Close();
            for (int j = 0; j < datas.Length; j++)
            {
                for (int k = 0; k < datas[j].Length; k++)
                {
                    finalText = finalText + datas[j][k] + ";";
                }
                finalText = finalText + "\r\n";
            }
            StreamWriter WriteGrades = new StreamWriter("Grades.csv");
            WriteGrades.WriteLine(finalText);
            WriteGrades.Close();
        }
    }
}