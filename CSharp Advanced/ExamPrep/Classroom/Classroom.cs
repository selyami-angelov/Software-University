using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get { return this.capacity; } private set { this.capacity = value; } }
        public int Count { get { return this.students.Count(); } }

        public string RegisterStudent(Student student)
        {
            if (this.Count < capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var stud = this.students.Find(x => x.FirstName == firstName && x.LastName == lastName);

            if (stud != null)
            {
                this.students.Remove(stud);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder result = new StringBuilder();
            bool subjectInfo = false;

            result.AppendLine($"Subject: {subject}");
            result.AppendLine("Students:");

            foreach (var item in this.students)
            {
                if (item.Subject == subject)
                {
                    subjectInfo = true;
                    result.AppendLine($"{item.FirstName} {item.LastName}");
                }
            }

            if (subjectInfo == true)
            {
                return result.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.Find(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
