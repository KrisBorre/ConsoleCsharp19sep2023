using LibraryIntegration13nov2023;
using LibraryFunctionExamples13nov2023;

Console.WriteLine("Welkom bij Integralen en ToString.");

const int AANTAL = 7;
IntegrationAbstractClass7oct2023[] problems = new IntegrationAbstractClass7oct2023[AANTAL];
int j = 0;
problems[j++] = new IntegrationTrapezoidal7oct2023(new Square7oct2023(), 0.0, 1.0);
problems[j++] = new IntegrationTrapezoidal7oct2023(new ConstantTimesPower7oct2023(4.0, 0.5), 0.0, 1.0);
problems[j++] = new IntegrationMidpoint7oct2023(new Square7oct2023(), 0.0, 1.0);
problems[j++] = new IntegrationMidpoint7oct2023(new ConstantTimesPower7oct2023(4.0, 0.5), 0.0, 1.0);
problems[j++] = new IntegrationTrapezoidal7oct2023(new Sinus7oct2023(), 0.0, Math.PI);
problems[j++] = new IntegrationMidpoint7oct2023(new Integrand1_7oct2023(0.5), 0.0, 1);
problems[j++] = new IntegrationTrapezoidal7oct2023(new Integrand2_7oct2023(power1: 0.5, power2: 4), 0.0, 1.0);

foreach (IntegrationAbstractClass7oct2023 problem in problems)
{
    for (int i = 0; i < 15; i++)
    {
        problem.Next();
    }
}

foreach (IntegrationAbstractClass7oct2023 problem in problems)
{
    Console.WriteLine(problem);
}

/*
Integral solution of x^2 using the extended trapezoidal rule is 0,33333333395421505
Integral solution of 4 x^0,50 using the extended trapezoidal rule is 2,666666270776042
Integral solution of x^2 using the extended midpoint rule is 0,33333333332454246
Integral solution of 4 x^0,50 using the extended midpoint rule is 2,666666666680703
Integral solution of sin(x) using the extended trapezoidal rule is 1,9999999938721755
Integral solution of x * Math.Pow(1+x,0,5) using the extended midpoint rule is 0,6437902832913122
Integral solution of Math.Pow(Math.Pow(x, 4) + 1, 0,5) using the extended trapezoidal rule is 1,089429413663853
*/

Console.WriteLine("Kris Borremans");
Console.Read();