namespace Ex23_StudentsGrades
{
    internal class Grade
    {
        float grade;
        int studentId;
        Grade? next;
        public Grade(float grade, int studentId)
        {
            this.grade = grade;
            this.studentId = studentId;
        }

        public Grade? GetNext() { return this.next; }

        public void SetNext(Grade? value) { this.next = value; }

        public int GetId() { return studentId; }

        public float GetGrade() { return grade; }

        public override string ToString() { return $"Grade: {grade:0.0}"; }
    }
}