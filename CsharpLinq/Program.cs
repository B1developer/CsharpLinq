class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

class Program
{
    static void Main()
    {
        #region BASIC LINQ QUERIES

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> evenNumbers = new List<int>();

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }

        Console.WriteLine("Even numbers:");
        foreach (int number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        ///////////////////////////////////////////////////////////////////////////////////

        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // LINQ query to find even numbers
        var evenNumbers1 = numbers1.Where(n => n % 2 == 0);

        Console.WriteLine("Even numbers:");
        foreach (int number1 in evenNumbers1)
        {
            Console.WriteLine(number1);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////

        #region ADVANCED LINQ QUERIES: SELECT, ORDERBY, AND GROUPBY

        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Dave" };

        var upperCaseNames = names.Select(name => name.ToUpper());

        Console.WriteLine("Names in uppercase:");
        foreach (string name in upperCaseNames)
        {
            Console.WriteLine(name);
        }

        ///////////////////////////////////////////////////////////////////////////////////

        List<int> numbers2 = new List<int> { 5, 3, 9, 1, 4, 7 };

        var sortedNumbers = numbers2.OrderByDescending(n => n);

        Console.WriteLine("Numbers in descending order:");
        foreach (int number2 in sortedNumbers)
        {
            Console.WriteLine(number2);
        }

        ///////////////////////////////////////////////////////////////////////////////////

        List<string> words = new List<string> { "apple", "apricot", "banana", "blueberry", "cherry" };

        var groupedWords = words.GroupBy(word => word[0]);

        foreach (var group in groupedWords)
        {
            Console.WriteLine($"Words that start with '{group.Key}':");
            foreach (string word in group)
            {
                Console.WriteLine(word);
            }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////

        #region COMBINING LINQ METHODS

        List<int> numbers3 = new List<int> { 10, 15, 20, 25, 30, 35, 40, 45, 50 };

        var processedNumbers = numbers3
            .Where(n => n % 10 == 0) // Filter: numbers divisible by 10
            .Select(n => n * 2)      // Transform: multiply each by 2
            .OrderBy(n => n);        // Sort: in ascending order

        Console.WriteLine("Processed numbers:");
        foreach (int number3 in processedNumbers)
        {
            Console.WriteLine(number3);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////

        #region QUERY SYNTAX VS. METHOD SYNTAX

        List<int> numbers4 = new List<int> { 10, 15, 20, 25, 30, 35, 40, 45, 50 };

        var processedNumbers1 = from n in numbers4
                                where n % 10 == 0
                                select n * 2;

        processedNumbers1 = processedNumbers1.OrderBy(n => n);

        Console.WriteLine("Processed numbers:");
        foreach (int number4 in processedNumbers1)
        {
            Console.WriteLine(number4);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////

        #region CHALLENGE: STUDENT GRADE PROCESSING WITH LINQ

        // Step 1: Create a list of students with their names and grades
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Grade= 85},
            new Student { Name = "Bob", Grade= 76},
            new Student { Name = "Charlie", Grade= 90},
            new Student { Name = "Dave", Grade= 60},
            new Student { Name = "Eve", Grade= 88},
        };

        // Step 2: Calculate and display the average grade
        var averageGrade = students.Average(student => student.Grade);
        Console.WriteLine($"Average Grade: {averageGrade:F2}");

        // Step 3: Display students who have grades above a certain threshold
        int threshold = 80;
        var aboveThreshold = students.Where(student => student.Grade > threshold);

        Console.WriteLine($"\nStudents with grades above {threshold}:");
        foreach (var student in aboveThreshold)
        {
            Console.WriteLine($"{student.Name} - {student.Grade}");
        }

        // Step 4: Sort and display students by their grades (ascending)
        var sortedStudents = students.OrderBy(student => student.Grade);

        Console.WriteLine("\nStudents sorted by grades:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name} - {student.Grade}");
        }
        #endregion
    }
}