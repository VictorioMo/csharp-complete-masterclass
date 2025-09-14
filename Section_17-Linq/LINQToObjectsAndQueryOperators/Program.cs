namespace LINQToObjectsAndQueryOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();

            um.MaleStudents();
            um.FemaleStudents();
            um.SortStudentsByAge();
            um.AllStudentsFromBeijingTech();

            Console.WriteLine("Input an university id:");
            string? input = Console.ReadLine();
            int input_int = 0;
            bool op_ok = false;
            if (input != null)
            {
                op_ok = int.TryParse(input, out input_int);
            }

            if (op_ok)
            {
                um.AllStudentsFromUniversity(input_int);
            }

            Console.WriteLine();
            um.StudentAndUniversityNameCollection();

            Console.ReadKey();
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 19, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Toni" , Gender = "male"  , Age = 21, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "James", Gender = "male"  , Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;

            Console.WriteLine("Male students");

            foreach(Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;

            Console.WriteLine("Female students");

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }

        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;

            Console.WriteLine("Students sorted by Age:");

            foreach (var student in sortedStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromBeijingTech()
        {
            IEnumerable<Student> bijStudents = from student in students
                                               join university in universities on student.UniversityId equals university.Id
                                               where university.Name == "Beijing Tech"
                                               select student;

            Console.WriteLine("Studnets from Beijing Tech:");
            foreach (Student s in bijStudents)
            {
                s.Print();
            }
        }

        public void AllStudentsFromUniversity(int uniId)
        {
            IEnumerable<Student> uniIdStudents = from student in students
                                                 join university in universities on student.UniversityId equals university.Id
                                                 where university.Id == uniId
                                                 select student;

            Console.WriteLine("Students from University {0}", uniId);
            foreach (Student s in uniIdStudents)
            {
                s.Print();
            }
        }

        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join university in universities on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection:");

            foreach (var ele in newCollection)
            {
                Console.WriteLine("Student {0} from university {1}", ele.StudentName, ele.UniversityName);
            }
        }
    }

    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("University {0} with id {1}", Name, Id);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student {Name} with ID {Id}, a {Gender} aged {Age}, studies in university {UniversityId}");
        }
    }
}
