using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
//Calling my custom library
using DataCalculationLibrary;

namespace TimeManagement
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //Enter() Method captures values entered by user.
        public void enter()
        {
            //Convert string values to their assigned data types.
            int credit = Int32.Parse(ModuleCredits.Text);
            int mHPW = Int32.Parse(ModuleHoursPerWeek.Text);
            int nWS = Int32.Parse(NumberWeeksSemester.Text);
            DateOnly sDate = DateOnly.Parse(StartDateFWeek.Text);

            //List in Semester class is being populated.
            Semester.ModuleName = ModuleName.Text;
            Semester.ModuleCode = ModuleCode.Text;
            Semester.ModuleCredits = credit;
            Semester.ModuleHoursPerWeek = mHPW;
            Semester.NumberWeeksSemester = nWS;
            Semester.StartDateFWeek = sDate;
        }

        //This button when clicked adds the prompted information into thee List.
        private void AddM_Click(object sender, RoutedEventArgs e)
        {
            //Calls the enter() Method
            enter(); 

            //Invoking both Methods in Semester class.
            Semester.SelfStudyHoursPW();
            Semester.StoreData();
        }
        
        //When button is clicked it displays the List.
        private void ALL_Click(object sender, RoutedEventArgs e)
        {
            //Calling the List.
            List<Student> modules = Semester.StoreData();

            //Fetch all data inside List.
            foreach (var student in modules)
            {
                //Message Box pops up
                MessageBox.Show($"|Name|   {student.MName} \n|CODE|   {student.MCode} \n|CREDIT| {student.MCredits} \n|HOURS| {student.ClassHPW}" +
                                $" \n|WEEKS|   {student.WeeksInS} \n|SDATE|  {student.StartDate} \n|STUDYH| {student.SelfS}", 
                                "MODULE LIST", MessageBoxButton.OK);
            }
        }

        //Button if clicked displays how many hours of self‐study remain for each module.
        private void HoursRemaining_Click(object sender, RoutedEventArgs e)
        {
            //Convert string values to their assigned data types.
            DateOnly enterDate = DateOnly.Parse(Date.Text);
            int study = Int32.Parse(SelftStudyHours.Text);

            //Student List is pulled.
            List<Student> modules = Semester.StoreData();

            //LINQ statement that calculates how hours of Sel-Study Remains.
            var fetch = modules.Where(x => x.StartDate == enterDate).Sum(x => x.ClassHPW - study);

            MessageBox.Show($"|Remaining Hours|   \t{fetch}", "SELF STUDY HOURS REMAINING");
                        
        }
    }
}
