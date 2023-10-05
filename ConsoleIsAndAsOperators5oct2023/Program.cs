namespace ConsoleIsAndAsOperators5oct2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region is-and-as-in-csharp
            {
                // https://codewithshadman.com/is-and-as-in-csharp/
                Console.WriteLine("Hello Is and As operators in C#!");
                Console.WriteLine("Hello Is and As operators in C#!" is string); // True
                Console.WriteLine("There is an inherent problem with is operator that many developers are not aware of:");
                Console.WriteLine("Under the covers, the is operator uses a cast to make its determination.");
                Console.WriteLine("Why is this a problem ? ");
                Console.WriteLine("Because the next step most developers take is to cast the instance to the type. " +
                    "The is operator viewed as a sort of “safe cast” since you know that the instance is of that type. " +
                    "Here is an example of this practice:");
                {
                    Object obj = new Dog();

                    if (obj is Dog)
                        ((Dog)obj).Speak();  // Bark!
                }
                Console.WriteLine("In this example there are actually two separate casts, the is and the explicit cast below it (inside the conditional statement). " +
                    "You shouldn’t cast more then once if you don’t need to do so. Also, the is check does not consider user-defined conversions (such as implicit and explicit cast operators) so is may return false for an instance that could have successfully been casted.");

                Console.WriteLine("So what should we do instead?");
                Console.WriteLine("One method would be to use is operator with a variable name. Like this,");
                {
                    Object obj = new Dog();

                    if (obj is Dog dog)
                        dog.Speak();  // Bark!
                }
                Console.WriteLine("Or use C#’s true safe casting operator: as.");
                Console.WriteLine("The as operator allows you to do an explicit cast on a type while avoiding any InvalidCastExceptions that may occur by assigning null to the variable if the cast fails.");
                {
                    Object obj = new Dog();

                    Dog dog = obj as Dog;

                    if (dog != null)
                        dog.Speak();
                }
                Console.WriteLine("So, the important thing to remember is that if you feel like you need to use is, most likely you ought to use as.");

                Console.WriteLine("Be careful that you are not using casting to solve a problem that would be better solved with polymorphism. " +
                    "If you find that you are doing multiple checks for different types, casting, and then calling methods on those types, you should reevaluate your approach to see if a polymorphic solution would be better. " +
                    "Casting is a powerful tool but it can be misapplied.");

                Console.WriteLine("With the as method, it can result in null, which can be checked for, and avoid an exception being thrown.");

                {
                    Object obj = new object();
                    Dog dog = (obj as Dog) ?? new Dog();
                    dog.Speak();
                }
                Console.WriteLine("Note: you can only use as with reference types, so if you are typecasting to a value type, you must still use the “classic” method of casting with (Dog)");

            }
            #endregion


            #region c-sharpcorner
            {
                // https://www.c-sharpcorner.com/uploadfile/abhikumarvatsa/the-is-and-as-operators-in-C-Sharp/
                object[] myObjects = new object[6];
                myObjects[0] = new Class1();
                myObjects[1] = new Class2();
                myObjects[2] = "string";
                myObjects[3] = 32;
                myObjects[4] = null;
                for (int i = 0; i < myObjects.Length; ++i)
                {
                    string s = myObjects[i] as string;
                    Console.Write("{0}:", i);
                    if (s != null)
                        Console.WriteLine("'" + s + "'");
                    else
                        Console.WriteLine("not a string");
                }
                /*0:not a string
                1:not a string
                2:'string'
                3:not a string
                4:not a string
                5:not a string*/

            }
            #endregion


            #region geeksforgeeks
            {
                //https://www.geeksforgeeks.org/c-sharp-is-operator-keyword/

                Console.WriteLine("If the expression is not null and the object results from evaluating the expression can be converted to the specified type then is operator will return true otherwise it will return false.");

                // Creating objects of  
                // Author and Work class 
                Author a = new Author();

                a.details("Ankita", 5);

                Work w = new Work();

                w.totalno(80, 50);

                bool result;

                // Check 'a' is of Author  
                // type or not 
                // Using is operator 
                result = a is Author;
                Console.WriteLine("Is a is Author? : {0}", result);

                // Check w is of Author type 
                // using is operator 
                result = w is Author;
                Console.WriteLine("Is w is Author? : {0}", result);

                // Take the value of a is null 
                a = null;

                // Check null object 
                // Using is operator 
                result = a is Author;
                Console.WriteLine("Is a is Author? : {0}", result);

                //Is a is Author? : True
                //Is w is Author? : False
                //Is a is Author? : False

                Console.WriteLine("In the below program, we are checking whether the derived type is of the expression type on the left-hand side of the is operator. " +
                    "If is derived then it will return true otherwise it returns false.");

                // creating an instance  
                // of class G1 
                G1 obj1 = new G1();

                // creating an instance  
                // of class G2 
                G2 obj2 = new G2();

                // checking whether 'obj1' 
                // is of type 'G1' 
                Console.WriteLine(obj1 is G1);

                // checking whether 'obj1' is 
                // of type Object class 
                // (Base class for all classes) 
                Console.WriteLine(obj1 is Object);

                // checking whether 'obj2' 
                // is of type 'G2' 
                Console.WriteLine(obj2 is G2);

                // checking whether 'obj2' is 
                // of type Object class 
                // (Base class for all classes) 
                Console.WriteLine(obj2 is Object);

                // checking whether 'obj2' 
                // is of type 'G1' 
                // it will return true as G2 
                // is derived from G1 
                Console.WriteLine(obj2 is G2);

                // checking whether obj1  
                // is of type G3 
                // it will return false 
                Console.WriteLine(obj1 is G3);

                // checking whether obj2  
                // is of type G3 
                // it will return false 
                Console.WriteLine(obj2 is G3);

                //True
                //True
                //True
                //True
                //True
                //False
                //False

                Console.WriteLine("Only reference, boxing, and unboxing conversions are considered by the is operator keyword.");
                Console.WriteLine("User-defined conversions or the conversion which are defined using the implicit and explicit are not considered consider by is operator. " +
                    "For the conversions which are known at the compile-time or handled by an implicit operator, is operator will give warnings for that.");

            }
            #endregion

            Console.ReadLine();
        }
    }

    #region geeksforgeeks

    // taking a class 
    public class G1
    {
    }

    // taking a class  
    // derived from G1 
    public class G2 : G1
    {
    }

    // taking a class 
    public class G3
    {
    }

    class Author
    {
        // data members 
        public string name;
        public int rank;

        // method of Author class 
        public void details(string n, int r)
        {
            name = n;
            rank = r;
        }
    }

    class Work
    {
        // data members 
        public int articl_no;
        public int improv_no;

        // method of Work class 
        public void totalno(int a, int i)
        {
            articl_no = a;
            improv_no = i;
        }
    }

    #endregion

    #region is-and-as-in-csharp
    class Dog
    {
        public void Speak() { Console.WriteLine("Bark!"); }
    }
    #endregion

    #region c-sharpcorner
    class Class1
    {
    }

    class Class2
    {
    }
    #endregion
}
