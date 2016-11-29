using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_7
{
    class Program
    {        
        class Student
        {
            public static int StudentCount = 0;

            public Student(string firstName, string lastName, DateTime dob)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Dob = dob;
                this.grades = new Stack<double>();
            }

            public Stack<double> grades;
            public DateTime Dob { get; private set; }
            public string LastName { get; private set; }
            public string FirstName { get; private set; }

            public void ViewGrades()
            {
                string grades = "";
                foreach (double grade in this.grades)
                {
                    grades += grade.ToString() + " ";
                }
                Console.WriteLine("Grades: {0}", grades);
            }


        }

        class Teacher
        {
            public Teacher(string firstName, string lastName, DateTime dob)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Dob = dob;
            }
            public DateTime Dob { get; private set; }
            public string LastName { get; private set; }
            public string FirstName { get; private set; }
        }

        class UProgram
        {
            public UProgram(string programName, Degree degree)
            {
                this.Degree = degree;
                this.ProgramName = programName;

            }
            public Degree Degree { get; private set; }
            public string ProgramName { get; private set; }
            public string DepartmentHead { get; private set; }
        }

        class Degree
        {
            public Degree(string degreeName, Course course)
            {
                this.course = course;
                this.DegreeName = degreeName;

            }
            public Course course { get; private set; }
            public string DegreeName { get; private set; }
            public int CreditsRequired { get; private set; }
        }

        class Course
        {
            public Course(string courseName, int credits, int durationInWeeks)
            {
                this.DurationInWeeks = durationInWeeks;
                this.Credits = credits;
                this.CourseName = courseName;
                this.studentArray = new ArrayList();
                this.teachers = new ArrayList();
            }

            public void ListStudents()
            {                
                foreach (Student student in this.studentArray)
                {
                    Console.Write("Student: ");
                    Console.Write("{0} {1} ", student.FirstName.ToString(), student.LastName.ToString());
                    student.ViewGrades();


                }
            }

            public ArrayList studentArray { get; private set; }
            public ArrayList teachers { get; private set; }
            public string CourseName { get; private set; }
            public int Credits { get; private set; }
            public int DurationInWeeks { get; private set; }
        }

        static void Main(string[] args)
        {
            //Create students
            Student student1 = new Student("Jamel", "Winchester", new DateTime(1976, 04, 19));
            Student student2 = new Student("Milford", "Bruch", new DateTime(1984, 12, 05));
            Student student3 = new Student("Damon", "McCurry", new DateTime(1986, 07, 14));

            //Create course
            Course course = new Course("Programming with C#", 4, 12);

            //Add students to ArrayList
            course.studentArray.Add(student1);
            course.studentArray.Add(student2);
            course.studentArray.Add(student3);


            //Not doing random numbers, will add manually.  Teachers don't add random grades..
            //student1 grades
            student1.grades.Push(98);
            student1.grades.Push(85);
            student1.grades.Push(79);
            student1.grades.Push(90);
            student1.grades.Push(78);

            //student2 grades
            student2.grades.Push(79);
            student2.grades.Push(90);
            student2.grades.Push(94);
            student2.grades.Push(95);
            student2.grades.Push(83);

            //student3 grades
            student3.grades.Push(67);
            student3.grades.Push(98);
            student3.grades.Push(93);
            student3.grades.Push(89);
            student3.grades.Push(86);


            //Student count
            int studentCount = Student.StudentCount;
            foreach (var student in course.studentArray)
            {
                studentCount += 1;
            }

            //Old
            Teacher teacher1 = new Teacher("Travis", "Victorino", new DateTime(1968, 11, 22));
            Teacher[] teachers = new Teacher[] { teacher1 };
            Degree degree = new Degree("Bachelor of Science", course);
            UProgram uprogram = new UProgram("Information Technology", degree);

            //Class info
            Console.WriteLine("The {0} program contains the {1} degree.", uprogram.ProgramName, degree.DegreeName);
            Console.WriteLine("The {0} degree contains the course {1}.", degree.DegreeName, course.CourseName);
            Console.WriteLine("The {0} course contains {1} students.", course.CourseName, studentCount);
            Console.WriteLine("----------------------------------------------------------------------");

            //Display students and grades
            Console.WriteLine("Currently enrolled students and their grades:");
            course.ListStudents();
            Console.ReadKey();

            
        }
    }
}
