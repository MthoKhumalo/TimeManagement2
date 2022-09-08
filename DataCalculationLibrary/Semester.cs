using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCalculationLibrary
{
    public class Semester
    {
        public static string? ModuleName;
        public static string? ModuleCode;
        public static int ModuleCredits;
        public static int ModuleHoursPerWeek;
        public static int NumberWeeksSemester;
        public static DateOnly StartDateFWeek;
        public static int SelfStudy;

        //StoreData() Method has one function to capture data, and return the list.
        public static List<Student> StoreData()
        {
            //Student List stores the data entered by user into the below list.
            List<Student> capture = new List<Student>();

            capture.Add(new Student { MName = ModuleName, MCode = ModuleCode, MCredits = ModuleCredits,
                                      ClassHPW = ModuleHoursPerWeek, WeeksInS = NumberWeeksSemester, StartDate = StartDateFWeek,
                                      SelfS = SelfStudy});

            return capture;
        }

        //SelfStudyHoursPW() Metohd calculates Self study hours per week.
        public static int SelfStudyHoursPW()
        {
            SelfStudy = ((ModuleCredits * 10) / NumberWeeksSemester) - ModuleHoursPerWeek;

            return SelfStudy;
        }
    }
}
