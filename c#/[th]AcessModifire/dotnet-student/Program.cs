using System;

namespace Student
{
    class Program
    {
        public static void Main(string[] args)
        {
            Student student1 = new Student(1, "M. Công", "Hà Nội", 30);

            Student student2 = new Student();
            student2.SetId(2);
            student2.SetName("Ph. Quang Khánh");
            student2.SetAddress("Lạng Sơn");
            student2.SetAge(25);

            Console.WriteLine(student1.ToString());
            Console.WriteLine(student2.ToString());
            Console.Read();
        }
    }
}
