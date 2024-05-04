namespace Ex23_StudentsGrades
{
    internal class Student
    {
        string name;
        int studentId;
        Student? next;

        public Student(string name, int studentId)
        {
            this.name = name;
            this.studentId = studentId;
        }
        public Student? GetNext() { return this.next; }

        public void SetNext(Student? student) { this.next = student; }

        public string GetName() { return name; }

        public int GetStudentId() {  return studentId; }

        public override string ToString() { return $"Student: {name}"; }
    }
}
