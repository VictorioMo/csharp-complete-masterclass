using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        LinqToSQLDataClassesDataContext DataContext;

        public MainWindow()
        {
            InitializeComponent();

            SqlConnInit();
            DataContext = new LinqToSQLDataClassesDataContext(sqlConnection);

            //InsertUniversities();
            //InsertStudent();
            //InsertLectures();
            //InsertStudentLectureAssociation();
            //GetAllStudentsFromYale();
            //GetAllUniversitiesWithMales();
            //GetAllBeijingTechLectures();
            UpdateStudentName( name: "Tony", newName: "Antonio");
        }

        private void SqlConnInit()
        {
            string baseConnectionString = ConfigurationManager.ConnectionStrings["LinqToSql.Properties.Settings.CSharpMasterClassConnectionString"].ConnectionString;
            string connectionPassword = Environment.GetEnvironmentVariable("TEST_LOGIN_APP_PASSWORD");

            var connectionStringBuilder = new SqlConnectionStringBuilder(baseConnectionString)
            {
                Password = connectionPassword
            };

            string fullConnectionString = connectionStringBuilder.ToString();

            sqlConnection = new SqlConnection(fullConnectionString);
        }

        public void InsertUniversities()
        {
            DataContext.ExecuteCommand("DELETE FROM University");

            University yale = new University();
            yale.Name = "Yale";
            DataContext.Universities.InsertOnSubmit(yale);

            University beijingTech = new University();
            beijingTech.Name = "Beijing Tech";
            DataContext.Universities.InsertOnSubmit(beijingTech);

            DataContext.SubmitChanges();

            MainDataGrid.ItemsSource = DataContext.Universities;
        }

        public void InsertStudent()
        {
            DataContext.ExecuteCommand("DELETE FROM Student");

            University yale = DataContext.Universities.First(un => un.Name.Equals("Yale"));
            University beijingTech = DataContext.Universities.First(un => un.Name.Equals("Beijing Tech"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "Carla", Gender = "female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Tony" , Gender = "male"  , University = yale });
            students.Add(new Student { Name = "Leyla", Gender = "female", University = beijingTech });
            students.Add(new Student { Name = "James", Gender = "male"  , University = beijingTech });

            DataContext.Students.InsertAllOnSubmit(students);
            DataContext.SubmitChanges();

            MainDataGrid.ItemsSource = DataContext.Students;

        }

        public void InsertLectures()
        {
            DataContext.ExecuteCommand("DELETE FROM Lecture");

            DataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Math"    });
            DataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Physics" });

            DataContext.SubmitChanges();

            MainDataGrid.ItemsSource= DataContext.Lectures;
        }

        public void InsertStudentLectureAssociation()
        {
            DataContext.ExecuteCommand("DELETE FROM StudentLecture");

            // Input:
            List<Student> students = new List<Student>(DataContext.Students);
            List<Lecture> lectures = new List<Lecture>(DataContext.Lectures);

            // Output:
            List<StudentLecture> studentLectures = new List<StudentLecture>();

            foreach (Student student in students)
            {
                foreach (Lecture lecture in lectures)
                {
                    if (student.Name == "Carla" && lecture.Name == "Math")
                        studentLectures.Add(new StudentLecture { Student = student, Lecture = lecture });

                    if (student.Name == "Tony"  && lecture.Name == "Math")
                        studentLectures.Add(new StudentLecture { Student = student, Lecture = lecture });

                    if (student.Name == "Leyla" && lecture.Name == "Physics")
                        studentLectures.Add(new StudentLecture { Student = student, Lecture = lecture });

                    if (student.Name == "James" && lecture.Name == "Physics")
                        studentLectures.Add(new StudentLecture { Student = student, Lecture = lecture });

                }
            }

            DataContext.StudentLectures.InsertAllOnSubmit(studentLectures);
            DataContext.SubmitChanges();

            MainDataGrid.ItemsSource = DataContext.StudentLectures;
        }

        public void GetAllStudentsFromYale()
        {
            var studentsFromYale = from student in DataContext.Students
                                   where student.University.Name == "Yale"
                                   select student;

            MainDataGrid.ItemsSource = studentsFromYale;
        }

        public void GetAllUniversitiesWithMales()
        {
            var allUnisMale = from student in DataContext.Students
                              join university in DataContext.Universities
                              on student.University equals university
                              where student.Gender == "male"
                              select university;

            MainDataGrid.ItemsSource = allUnisMale;
        }

        public void GetAllBeijingTechLectures()
        {
            var allLecturesAtBeijingTech = from sl in DataContext.StudentLectures
                                           join student in DataContext.Students
                                           on sl.StudentId equals student.Id
                                           where student.University.Name.Equals("Beijing Tech")
                                           select sl.Lecture;

            MainDataGrid.ItemsSource = allLecturesAtBeijingTech;
        }

        public void UpdateStudentName(string name, string newName)
        {
            Student s = DataContext.Students.FirstOrDefault(st => st.Name == name);

            s.Name = newName;

            DataContext.SubmitChanges();

            MainDataGrid.ItemsSource = DataContext.Students;
        }
    }
}
