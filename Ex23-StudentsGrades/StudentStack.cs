namespace Ex23_StudentsGrades
{
    internal class StudentStack
    {
        Student? head;
        int size;

        public StudentStack()
        {
            head = null;
            size = 0;
        }

        public void Push(Student student)
        {
            size++;
            student.SetNext(head);
            this.head = student;
        }

        public Student Pop()
        {
            Student aux = head;

            if (!IsEmpty())
            {
                size--;
                head = head.GetNext();
            }

            return aux;
        }

        public int GetSize() { return size; }

        public bool IsEmpty() { return head == null; }
        public StudentStack GetCopy()
        {
            StudentStack copy = new StudentStack();
            Student walker = head;

            if (!IsEmpty())
            {
                do
                {
                    copy.Push(new Student(walker.GetName(), walker.GetStudentId()));
                    walker = walker.GetNext();
                } while (walker != null);
            }

            return copy;
        }
    }
}