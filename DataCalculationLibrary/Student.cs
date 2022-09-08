using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Unique class library
namespace DataCalculationLibrary
{
    public class Student 
    {
        //Data fields that are going to be loaded in the List
        public string? MName { get; set; }
        public string? MCode { get; set; }
        public int MCredits { get; set; }
        public int ClassHPW { get; set; }
        public int WeeksInS { get; set; }
        public DateOnly StartDate { get; set; }
        public int SelfS { get; set; }
    }
}