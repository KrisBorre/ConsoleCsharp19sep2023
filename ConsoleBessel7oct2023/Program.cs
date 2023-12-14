using ConsoleBessel7oct2023;

internal class Program
{
    // From C++ to C#
    public static double sqrt(double x)
    {
        return Math.Sqrt(x);
    }

    public static double abs(double x)
    {
        return Math.Abs(x);
    }

    public static double cos(double x)
    {
        return Math.Cos(x);
    }

    public static double sin(double x)
    {
        return Math.Sin(x);
    }

    public static double log(double x)
    {
        return Math.Log(x);
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Hello Bessel functions!");

        Bessel7oct2023_jy bessjy = new Bessel7oct2023_jy();

        Console.WriteLine("x        bessj0(x)");
        for (int i = -5; i <= 14; i++)
        {
            double x = (double)i;
            Console.WriteLine($"{i}      {bessjy.j0(x)}");
        }

        Console.ReadLine();

        // Bessel function J0 dmv C#
        // x    bessj0(x)
        // -5   -0,1775967713143385
        // -4   -0,39714980986384724
        // -3   -0,26005195490193356
        // -2      0,22389077914123565
        // -1      0,765197686557967
        // 0      0,9999999999999998
        // 1      0,765197686557967
        // 2      0,22389077914123565
        // 3    -0,26005195490193356
        // 4    -0,39714980986384724
        // 5    -0,1775967713143385
        // 6      0,1506452572509968
        // 7      0,30007927051955546
        // 8      0,17165080713755396
        // 9    -0,0903336111828759
        // 10   -0,2459357644513483
        // 11   -0,17119030040719624
        // 12      0,04768931079683335
        // 13      0,2069261023770677
        // 14      0,17107347611045876


        /*
        Bessel Function J0 dmv C++
        x       actual       bessj0(x)

        -5 -1.775968e-001 -1.775968e-001
        -4 -3.971498e-001 -3.971498e-001
        -3 -2.600520e-001 -2.600520e-001
        -2  2.238908e-001  2.238908e-001
        -1  7.651976e-001  7.651977e-001
        0  1.000000e+000  1.000000e+000
        1  7.651977e-001  7.651977e-001
        2  2.238908e-001  2.238908e-001
        3 -2.600520e-001 -2.600520e-001
        4 -3.971498e-001 -3.971498e-001
        5 -1.775968e-001 -1.775968e-001
        6  1.506453e-001  1.506453e-001
        7  3.000793e-001  3.000793e-001
        8  1.716508e-001  1.716508e-001
        9 -9.033360e-002 -9.033361e-002
        10 -2.459358e-001 -2.459358e-001
        11 -1.711903e-001 -1.711903e-001
        12  4.768930e-002  4.768931e-002
        13  2.069261e-001  2.069261e-001
        14  1.710735e-001  1.710735e-001
        */

    }
}

