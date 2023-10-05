using System.Diagnostics;
using System.Text;

namespace ConsoleStringBuilder5oct2023
{
    class Program
    {
        #region C# program that benchmarks StringBuilder constructor
        const int _max = 1000000;
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hello StringBuilder!");

            //https://www.tutorialsteacher.com/csharp/csharp-stringbuilder

            #region example 1
            {
                System.Text.StringBuilder sb1 = new StringBuilder(); //string will be appended later
                                                                     //or
                StringBuilder sb2 = new StringBuilder("Hello World!");
            }
            #endregion


            #region the maximum capacity
            {
                Console.WriteLine("C# allocates a maximum of 50 spaces sequentially on the memory heap.");
                Console.WriteLine("This capacity will automatically be doubled once it reaches the specified capacity.");
                StringBuilder sb1 = new StringBuilder(50); //string will be appended later
                                                           //or
                StringBuilder sb2 = new StringBuilder("Hello World!", 50);
            }
            #endregion

            #region Retrieve String from StringBuilder
            {
                Console.WriteLine("The StringBuilder is not the string. Use the ToString() method to retrieve a string from the StringBuilder object.");
                StringBuilder sb = new StringBuilder("Hello World!");

                var greet = sb.ToString(); //returns "Hello World!"
            }
            #endregion

            #region AppendLine
            {
                Console.WriteLine("The AppendLine() method append a string with the newline character at the end.");
                StringBuilder sb = new StringBuilder();
                sb.Append("Hello ");
                sb.AppendLine("World!");
                sb.AppendLine("Hello C#");
                Console.WriteLine(sb);
            }
            #endregion

            #region AppendFormat
            {
                Console.WriteLine("Use the AppendFormat() method to format an input string into the specified format and append it.");
                StringBuilder sbAmount = new StringBuilder("Your total amount is ");
                sbAmount.AppendFormat("{0:C} ", 25);

                Console.WriteLine(sbAmount);//output: Your total amount is $ 25.00
            }
            #endregion

            #region Insert
            {
                Console.WriteLine("Use the Insert() method inserts a string at the specified index in the StringBuilder object.");
                StringBuilder sb = new StringBuilder("Hello World!");
                sb.Insert(5, " C#");

                Console.WriteLine(sb); //output: Hello C# World!
            }
            #endregion

            #region Remove 
            {
                Console.WriteLine("Use the Remove() method to remove a string from the specified index and up to the specified length.");

                StringBuilder sb = new StringBuilder("Hello World!", 50);
                sb.Remove(5, 7);
                //sb.Remove(6, 7); // 'Index was out of range. Must be non-negative and less than the size of the collection. 

                Console.WriteLine(sb); //output: Hello
            }
            #endregion

            #region Replace 
            {
                Console.WriteLine("Use the Replace() method to replace all the specified string occurrences with the specified replacement string.");
                StringBuilder sb = new StringBuilder("Hello World!");
                sb.Replace("World", "C#");

                Console.WriteLine(sb);//output: Hello C#!
            }
            #endregion

            #region 
            {
                Console.WriteLine(@"Points to Remember :
    1) StringBuilder is mutable.
    2) StringBuilder performs faster than string when appending multiple string values.
    3) Use StringBuilder when you need to append more than three or four strings.
    4) Use the Append() method to add or append strings to the StringBuilder object.
    5) Use the ToString() method to retrieve a string from the StringBuilder object.");
            }
            #endregion

            // https://www.dotnetperls.com/stringbuilder

            #region  Append
            {
                // Part 1: create new StringBuilder and loop.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    // Part 2: append to StringBuilder.
                    builder.Append(i).Append(" ");
                }
                Console.WriteLine(builder); // 0 1 2 3 4 5 6 7 8 9
            }
            #endregion

            #region AppendLine
            {
                // Part 1: declare a new StringBuilder.
                StringBuilder builder = new StringBuilder();

                // Part 2: call Append and AppendLine.
                builder.Append("The list starts here:");
                builder.AppendLine();
                builder.Append("1 cat").AppendLine();

                // Part 3: call ToString and display.
                string innerString = builder.ToString();
                Console.WriteLine(innerString);
            }
            #endregion

            #region Replace
            {
                StringBuilder builder = new StringBuilder("This is an example string that is an example.");
                builder.Replace("an", "the"); // Replaces 'an' with 'the'.
                Console.WriteLine(builder.ToString()); // This is the example string that is the example.
                //Console.ReadLine();
            }
            #endregion

            #region AppendFormat
            {
                var builder = new StringBuilder();
                // Append a format string directly.
                builder.AppendFormat("Hello {0}. It is {1}.",
                    "Ankit",
                    "Thursday");
                Console.WriteLine(builder);
            }
            #endregion

            #region foreach
            {
                string[] items = { "Cat", "Dog", "Celebrity" };

                StringBuilder builder2 = new StringBuilder("These items are required:").AppendLine();

                foreach (string item in items)
                {
                    builder2.Append(item).AppendLine();
                }
                Console.WriteLine(builder2.ToString());
                //Console.ReadLine();
            }
            #endregion


            #region argument
            {
                StringBuilder b = new StringBuilder();
                A2(b);
            }
            #endregion


            #region indexer
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("cat");

                // Write second letter.
                Console.WriteLine(builder[1]); // a

                // Change first letter.
                builder[0] = 'r';
                Console.WriteLine(builder.ToString()); // rat
            }
            #endregion

            #region Remove
            {
                StringBuilder builder = new StringBuilder("Dot Net Perls");
                builder.Remove(4, 3);
                Console.WriteLine(builder); // Dot  Perls
            }
            #endregion


            #region Append
            {
                Console.WriteLine("We try to find the index of the space in the string. The char after the space is the start of the substring we want.");

                var builder = new StringBuilder();
                string value = "bird frog";
                Console.WriteLine(value);

                // Get the index of the char after the space.
                int afterSpace = value.IndexOf(' ') + 1;

                Console.WriteLine("We pass the string, the start index, and then the computed length (which continues until the end of the string).");
                // Append a substring, computing the length of the target range.
                builder.Append(value: value, startIndex: afterSpace, count: value.Length - afterSpace);

                Console.WriteLine("APPEND SUBSTRING: {0}", builder); // APPEND SUBSTRING: frog
            }
            #endregion

            #region ToString(3, 3)
            {
                var builder = new StringBuilder("abcdef");

                // Use ToString with no arguments.
                string result = builder.ToString();
                Console.WriteLine("TOSTRING:       {0}", result);

                // Use a start and length.
                string resultRange = builder.ToString(startIndex: 3, length: 3);
                Console.WriteLine("TOSTRING RANGE: {0}", resultRange); // TOSTRING RANGE: def
            }
            #endregion


            #region AppendJoin
            {
                Console.WriteLine("In .NET Core in 2020, we can invoke AppendJoin on the StringBuilder. This eliminates a loop: we can append many elements (joined together) in a single statement.");
                // Part A: use AppendJoin with string array.
                var builder = new StringBuilder();
                string[] elements = { "bird", "frog", "dog" };
                builder.AppendJoin(separator: ",", values: elements);
                Console.WriteLine(builder); // bird,frog,dog

                // Part B: use AppendJoin with int array.
                builder.Clear();
                int[] values = { 10, 20, 30 };
                builder.AppendJoin(separator: ".", values: values);
                Console.WriteLine(builder); // 10.20.30
            }
            #endregion

            #region Trim 
            {
                Console.WriteLine(" StringBuilder has no Trim, TrimStart or TrimEnd methods. But we can implement similar methods. Here we add a TrimEnd method that removes a final character.");
                StringBuilder builder = new StringBuilder();
                builder.Append("This has an end period.");
                Console.WriteLine(builder);

                TrimEnd(builder, '.');
                Console.WriteLine(builder);
            }
            #endregion

            #region C# program that benchmarks StringBuilder constructor
            {
                // Version 1: create StringBuilder then Append a string.
                var s1 = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < _max; i++)
                {
                    var builder = new StringBuilder(10);
                    builder.Append("Cat");
                    if (builder.Length == 0)
                    {
                        return;
                    }
                }
                s1.Stop();
                // Version 2: create a StringBuilder with a string argument.
                var s2 = Stopwatch.StartNew();
                for (int i = 0; i < _max; i++)
                {
                    var builder = new StringBuilder("Cat", 10);
                    if (builder.Length == 0)
                    {
                        return;
                    }
                }
                s2.Stop();
                Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
                Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
                // 75,13 ns // 51 ns
                // 83,46 ns // 18 ns
                // Volgens website: 
                /*23.73 ns    new StringBuilder, Append
                19.42 ns    new StringBuilder(string)*/
            }
            #endregion

            #region C# program that improves StringBuilder performance
            {
                var builder1 = new StringBuilder();
                var builder2 = new StringBuilder();
                var tempString = 100.ToString();

                // Version 1: concat strings then Append.
                var s1 = Stopwatch.StartNew();
                for (int i = 0; i < _max; i++)
                {
                    builder1.Append(tempString + ",");
                }
                s1.Stop();
                // Version 2: append individual strings.
                var s2 = Stopwatch.StartNew();
                for (int i = 0; i < _max; i++)
                {
                    builder2.Append(tempString).Append(",");
                }
                s2.Stop();
                Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
                Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
                // 64,37 ns
                // 37,61 ns
                //Volgens website: 
                // 38.92 ns Concat strings, then Append
                // 15.42 ns Append twice
            }
            #endregion

            #region C# program that uses StringBuilder overload
            {
                const int m = 1000000;
                var builder = new StringBuilder();
                var s1 = Stopwatch.StartNew();
                // Version 1: take Substring.
                for (int i = 0; i < m; i++)
                {
                    Method1("perls", builder);
                }
                s1.Stop();
                var s2 = Stopwatch.StartNew();
                // Version 2: append range with Append.
                for (int i = 0; i < m; i++)
                {
                    Method2("perls", builder);
                }
                s2.Stop();
                Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / m).ToString("0.00 ns"));
                Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / m).ToString("0.00 ns"));
                //Console.Read();
            }
            #endregion

            // https://www.tutlane.com/tutorial/csharp/csharp-stringbuilder

            #region Mutability 
            {
                Console.WriteLine("In c#, both string and StringBuilder will represent a sequence of characters and perform the same kind of operations but the only difference is strings are immutable and StringBuilder is mutable.");
                Console.WriteLine("Generally, in c# the string object cannot be modified once it created. " +
                    "If any changes made to the string object like add or modify an existing value, then it will simply discard the old instance in memory and create a new instance to hold the new value. " +
                    "In case, if we are doing repeated modifications on the string object, then it will affect the performance of application.");

                Console.WriteLine("For example, we created a StringBuilder by specifying the capacity of 25 characters and appending a string whose length is greater than the capacity of 25 characters. " +
                    "In this case, the new space will be allocated automatically and the capacity of StringBuilder will be doubled.");
            }
            #endregion

            #region Append
            {
                Console.WriteLine("StringBuilder.Append");
                Console.WriteLine("This method will append the given string value to the end of the current StringBuilder.");
                StringBuilder sb = new StringBuilder("Suresh");
                sb.Append(", Rohini");
                sb.Append(", Trishika");
                Console.WriteLine(sb);
                // Output: Suresh, Rohini, Trishika
            }
            #endregion

            #region AppendFormat
            {
                int amount = 146;
                StringBuilder sb = new StringBuilder("Total");
                sb.AppendFormat(": {0:c}", amount);
                Console.WriteLine(sb);
                // Output is Total: $146.00
            }
            #endregion


            #region Insert
            {
                Console.WriteLine("The Insert method is used to insert a string at the specified index position of current StringBuilder object.");
                StringBuilder sb = new StringBuilder("Welcome Tutlane");
                sb.Insert(8, "to ");
                Console.WriteLine(sb);
                // Output: Welcome to Tutlane
            }
            #endregion


            #region Remove
            {
                Console.WriteLine("The Remove method is used to remove a specified number of characters from the current StringBuilder object, starting from the specified index position.");
                Console.WriteLine("Following is the example of removing a specified number of characters from the StringBuilder object, starting from the specified index position.");
                StringBuilder sb = new StringBuilder("Welcome to Tutlane");
                sb.Remove(8, 3);
                Console.WriteLine(sb);
                // Output: Welcome Tutlane
            }
            #endregion


            #region Replace
            {
                Console.WriteLine("StringBuilder.Replace");
                Console.WriteLine("It replaces a specified character at a specified index.");
                Console.WriteLine("Kris: Is dat zo?");
                Console.WriteLine("The Replace method is used to replace all occurrences of specified string characters in current StringBuilder object with a specified replacement string characters.");
                Console.WriteLine("Following is the example of replacing a specified number of characters from the StringBuilder object, with specified replace characters.");
                StringBuilder sb = new StringBuilder("Welcome to Tutlane");
                sb.Replace("Tutlane", "C#");
                Console.WriteLine(sb);
                // Output: Welcome to C#
            }
            #endregion


            #region StringBuilder 
            {
                Console.WriteLine("If you observe above code, to use StringBuilder in our application we imported a System.Text namespace and used a different methods of StringBuilder to make required modifications based on our requirements.");
                StringBuilder sb = new StringBuilder("Suresh");
                sb.Append(", Rohini");
                sb.Append(", Trishika");
                sb.AppendLine();
                sb.Append("Welcome to Tutlane");
                Console.WriteLine(sb);

                StringBuilder sb1 = new StringBuilder("Welcome World");
                sb1.Insert(8, "to Tutlane ");
                Console.WriteLine("Insert String: " + sb1);

                StringBuilder sb2 = new StringBuilder("Welcome to Tutlane");
                sb2.Remove(8, 3);
                Console.WriteLine(sb2);

                StringBuilder sb3 = new StringBuilder("Welcome to Tutlane World");
                sb3.Replace("Tutlane", "C#");
                Console.WriteLine(sb3);
                //Console.ReadLine();
            }
            #endregion

            #region ToString
            {
                StringBuilder sb = new StringBuilder("Suresh");
                sb.Append(", Rohini");
                sb.Append(", Trishika");
                sb.AppendLine();
                sb.Append("Welcome to Tutlane");
                Console.WriteLine(sb.ToString());
                //Console.ReadLine();
            }
            #endregion

            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/stringbuilder

            #region Replace
            {
                Console.WriteLine("The following example uses the Replace method to search a StringBuilder object for all instances of the exclamation point character (!) and replace them with the question mark character (?).");
                StringBuilder myStringBuilder = new StringBuilder("Hello World!");
                myStringBuilder.Replace('!', '?');
                Console.WriteLine(myStringBuilder);
                // The example displays the following output:
                //       Hello World?                
            }
            #endregion


            #region AppendLine
            {
                Console.WriteLine("You must convert the StringBuilder object to a String object before you can pass the string represented by the StringBuilder object to a method that has a String parameter or display it in the user interface. " +
                    "You do this conversion by calling the StringBuilder.ToString method. " +
                    "The following example calls a number of StringBuilder methods and then calls the StringBuilder.ToString() method to display the string.");
                StringBuilder sb = new StringBuilder();
                bool flag = true;
                string[] spellings = { "recieve", "receeve", "receive" };
                sb.AppendFormat("Which of the following spellings is {0}:", flag);
                sb.AppendLine();
                for (int ctr = 0; ctr <= spellings.GetUpperBound(0); ctr++)
                {
                    sb.AppendFormat("   {0}. {1}", ctr, spellings[ctr]);
                    sb.AppendLine();
                }
                sb.AppendLine();
                Console.WriteLine(sb.ToString());
                // The example displays the following output:
                //       Which of the following spellings is True:
                //          0. recieve
                //          1. receeve
                //          2. receive
            }
            #endregion


            Console.ReadLine();
        }

        #region C# program that uses StringBuilder overload

        static void Method1(string input, StringBuilder buffer)
        {
            buffer.Clear();
            string temp = input.Substring(3, 2);
            buffer.Append(temp);
        }

        static void Method2(string input, StringBuilder buffer)
        {
            buffer.Clear();
            buffer.Append(input, 3, 2);
        }

        #endregion


        #region Trim
        static void TrimEnd(StringBuilder builder, char letter)
        {
            Console.WriteLine("If last char matches argument, reduce length by 1.");
            // ... If last char matches argument, reduce length by 1.
            if (builder[builder.Length - 1] == letter)
            {
                builder.Length -= 1;
            }
        }

        #endregion

        #region argument
        static string[] _items = new string[]
   {
        "cat",
        "dog",
        "giraffe"
   };

        /// <summary>
        /// Append to the StringBuilder param, void method.
        /// </summary>
        static void A2(StringBuilder b)
        {
            foreach (string item in _items)
            {
                b.AppendLine(item);
            }
        }
        #endregion
    }
}
