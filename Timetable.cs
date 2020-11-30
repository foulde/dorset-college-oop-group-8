using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace POO_Projet
{
    class Timetable
    {
        private SortedList<string, Course> MondayList = new SortedList<string, Course>();     //We create a sorted list of courses for each day
        private SortedList<string, Course> TuesdayList = new SortedList<string, Course>();
        private SortedList<string, Course> WednesdayList = new SortedList<string, Course>();
        private SortedList<string, Course> ThursdayList = new SortedList<string, Course>();
        private SortedList<string, Course> FridayList = new SortedList<string, Course>();
        /// <summary>
        /// Adds a course to a the timetable.
        /// </summary>
        /// <param name="course"></param>
        /// <returns>true if the course was added successfully, false if it wasn't added</returns>
        public bool AddCourse(Course course)
        {
            bool success = false;
            switch (course.CourseDay)       //according to the day
            {
                case "monday":
                    success = AddCourseToDay(course, MondayList);
                    break;
                case "tuesday":
                    success = AddCourseToDay(course, TuesdayList);
                    break;
                case "wednesday":
                    success = AddCourseToDay(course, WednesdayList);
                    break;
                case "thursday":
                    success = AddCourseToDay(course, ThursdayList);
                    break;
                case "friday":
                    success = AddCourseToDay(course, FridayList);
                    break;
                default:
                    success = false;
                    Console.WriteLine("Wrong day input");       //if the input is neither of the 5 days, the program returns false.
                    break;
            }
            return success;
        }
        /// <summary>
        /// Adds a course to a specifical day.
        /// </summary>
        /// <param name="course"></param>
        /// <param name="DayList"></param>
        /// <returns>true if the course was added successfully, false if it wasn't added</returns>
        private bool AddCourseToDay(Course course, SortedList<string, Course> DayList)
        {
            bool success2 = true;
            try
            {
                DayList.Add(course.StartingHour, course);       //starting hours are used as the key of the sorted list, thus the courses are sorted by their starting hour
                if (DayList.Count > 1)  //if there are more than one course a day, we must check if they are not overlapping
                {
                    for (int n = 1; n < DayList.Count; n++)
                    {
                        if (CompareHours(DayList.Values[n - 1].EndingHour, DayList.Values[n].StartingHour) == false)
                        {
                            success2 = false;
                        }
                    }
                    if (success2 == false)
                    {
                        DayList.Remove(course.StartingHour);        //if the addition of the course cause overlapping courses, we remove it.
                        Console.WriteLine("There are overlapping courses.");
                    }
                }
            }
            catch (ArgumentException)       //2 courses cannot have the same starting hour, and 2 elements in a sorted list cannot have the same key
            {
                Console.WriteLine("The starting hour " + course.StartingHour + " is already taken.");
                success2 = false;
            }
            return success2;
        }
        /// <summary>
        /// Remove a course to a the timetable.
        /// </summary>
        /// <param name="course"></param>
        /// <returns>true if the course was removed successfully, false if it wasn't removed</returns>
        public bool RemoveCourse(Course course)
        {
            bool success = false;
            switch (course.CourseDay)
            {
                case "monday":
                    success = RemoveCourseToDay(course.StartingHour, MondayList);
                    break;
                case "tuesday":
                    success = RemoveCourseToDay(course.StartingHour, TuesdayList);
                    break;
                case "wednesday":
                    success = RemoveCourseToDay(course.StartingHour, WednesdayList);
                    break;
                case "thursday":
                    success = RemoveCourseToDay(course.StartingHour, ThursdayList);
                    break;
                case "friday":
                    success = RemoveCourseToDay(course.StartingHour, FridayList);
                    break;
                default:
                    success = false;
                    Console.WriteLine("Wrong day input");
                    break;
            }
            return success;
        }
        public bool RemoveCourse(string hourKey, string dayName)
        {
            bool success = false;
            switch (dayName)
            {
                case "monday":
                    success = RemoveCourseToDay(hourKey, MondayList);
                    break;
                case "tuesday":
                    success = RemoveCourseToDay(hourKey, TuesdayList);
                    break;
                case "wednesday":
                    success = RemoveCourseToDay(hourKey, WednesdayList);
                    break;
                case "thursday":
                    success = RemoveCourseToDay(hourKey, ThursdayList);
                    break;
                case "friday":
                    success = RemoveCourseToDay(hourKey, FridayList);
                    break;
                default:
                    success = false;
                    Console.WriteLine("Wrong day input");
                    break;
            }
            return success;
        }
        /// <summary>
        /// Remove a course to a specifical day and starting hour.
        /// </summary>
        /// <param name="hourKey"></param>
        /// <param name="DayList"></param>
        /// <returns>true if the course was removed successfully, false if it wasn't removed</returns>
        public bool RemoveCourseToDay(string hourKey, SortedList<string, Course> DayList)
        {
            bool success2 = false;
            try
            {
                DayList.Remove(hourKey);
                success2 = true;
            }
            catch (ArgumentException)
            {
                success2 = false;
            }
            return success2;
        }
        /// <summary>
        /// Compares 2 strings containing hour information
        /// </summary>
        /// <param name="end1"></param>
        /// <param name="start2"></param>
        /// <returns></returns>
        public bool CompareHours(string end1, string start2)
        {
            return (string.Compare(end1, start2) <= 0);
        }
        public void Affiche()
        {
            Console.WriteLine("Monday");
            Console.WriteLine();
            for (int n = 0; n < MondayList.Count; n++)
            {
                Console.WriteLine(MondayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Tuesday");
            Console.WriteLine();
            for (int n = 0; n < TuesdayList.Count; n++)
            {
                Console.WriteLine(TuesdayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Wednesday");
            Console.WriteLine();
            for (int n = 0; n < WednesdayList.Count; n++)
            {
                Console.WriteLine(WednesdayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Thursday");
            Console.WriteLine();
            for (int n = 0; n < ThursdayList.Count; n++)
            {
                Console.WriteLine(ThursdayList.Values[n].ToStringTimetable());
            }
            Console.WriteLine("Friday");
            Console.WriteLine();
            for (int n = 0; n < FridayList.Count; n++)
            {
                Console.WriteLine(FridayList.Values[n].ToStringTimetable());
            }
        }
    }
}
