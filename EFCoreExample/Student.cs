namespace EFCoreExample
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public int SchoolId { get; set; }
        public School? School { get; set; }
    }
}
