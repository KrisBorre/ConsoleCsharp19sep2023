internal class Student
{
    private string name;
    private int rank;

    public Student(Student s)
    {
        name = s.name;
        rank = s.rank;
    }

    public Student(string name, int rank)
    {
        this.name = name;
        this.rank = rank;
    }

    public string Display
    {
        get
        {
            return " Student " + name + " got Rank " + rank.ToString();
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello Copy Constructor!");

        Student s1 = new Student("Jack", 2);

        // copy constructor
        Student s2 = new Student(s1);

        // display
        Console.WriteLine(s2.Display);
        Console.ReadLine();
    }
}