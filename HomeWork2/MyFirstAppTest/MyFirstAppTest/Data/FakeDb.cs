using MyFirstAppTest.Models;

namespace MyFirstAppTest.Data
{
    public static class FakeDb
    {
        public static List<Student> Students = new List<Student>
        {
            new Student { Id = 1, FullName = "Bobur Mengliyev", Age = 23, Course = "C#"  },
            new Student { Id = 2, FullName = "Jasur Mengliyev", Age = 19, Course = "C++"}
        };
    }
}
