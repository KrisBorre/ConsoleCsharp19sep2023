using LibraryIntegration13nov2023;
using LibraryIntegrationExamples13nov2023;

namespace ConsoleIntegration13nov2023
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Integration
            {
                Console.WriteLine("Welkom bij integralen.");
                const int MAX = 5; // 15;

                #region voorbeeld 1 trapezoidal rule
                {
                    IntegrationTrapezoidal7oct2023 integrationTrapezoidal1 = new IntegrationTrapezoidal7oct2023(new Square7oct2023(), 0.0, 1.0);
                    Console.WriteLine("Voorbeeld 1: Integraal van x^2 van 0 tot 1 is 0.33333 dmv trapezoidal rule.");
                    // De integraal van x^2 is (1/3) *x^3 + C 
                    // Integreren van 0 tot 1 is
                    // (1/3) *1^3 
                    // dit is 1/3 = 0.33333
                    for (int j = 1; j <= MAX; j++)
                    {
                        double value = integrationTrapezoidal1.Next();
                        Console.WriteLine("waarde = " + value);
                    }
                    /*
waarde = 0,5
waarde = 0,375
waarde = 0,34375
waarde = 0,3359375
waarde = 0,333984375
                    */
                    Console.WriteLine();
                }
                #endregion                

                #region voorbeeld 2 trapezoidal rule
                {
                    IntegrationTrapezoidal7oct2023 integrationTrapezoidal2 = new IntegrationTrapezoidal7oct2023(new ConstantTimesPower7oct2023(4.0, 0.5), 0.0, 1.0);
                    Console.WriteLine("Voorbeeld 2: Integraal van 4*sqrt(x) van 0 tot 1 is 2.6666666 dmv trapezoidal rule.");
                    // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
                    // 4 * (2/3) * 1^{3/2} = 8 / 3 = 2.6666666
                    for (int j = 1; j <= MAX; j++)
                    {
                        double value = integrationTrapezoidal2.Next();
                        Console.WriteLine("waarde = " + value);
                    }
                    /*
waarde = 2
waarde = 2,414213562373095
waarde = 2,5731321849709863
waarde = 2,6325208864978173
waarde = 2,6543247875089127
                    */

                    Console.WriteLine();
                }
                #endregion

                #region voorbeeld 3 midpoint rule
                {
                    IntegrationMidpoint7oct2023 integration3 = new IntegrationMidpoint7oct2023(new Square7oct2023(), 0.0, 1.0);
                    Console.WriteLine("Voorbeeld 3: Integraal van x^2 van 0 tot 1 is 0.33333 dmv midpoint rule.");
                    // De integraal van x^2 is (1/3) *x^3 + C 
                    // Integreren van 0 tot 1 is
                    // (1/3) *1^3 
                    // dit is 1/3 = 0.33333
                    for (int j = 1; j <= MAX; j++)
                    {
                        double value = integration3.Next();
                        Console.WriteLine("waarde = " + value);
                    }
                    /*
waarde = 0,25
waarde = 0,324074074074074
waarde = 0,33230452674897126
waarde = 0,3332190214906264
waarde = 0,33332063201747686
                    */
                    Console.WriteLine();
                }
                #endregion

                #region voorbeeld 4 midpoint rule
                {
                    IntegrationMidpoint7oct2023 integration4 = new IntegrationMidpoint7oct2023(new ConstantTimesPower7oct2023(4.0, 0.5), 0.0, 1.0);
                    Console.WriteLine("Voorbeeld 4: Integraal van 4*sqrt(x) van 0 tot 1 is 2.6666666 dmv midpoint rule");
                    // intergraal van 4*sqrt(x) is 4 * (2/3) * x^{3/2} + C
                    // 4 * (2/3) * 1^{3/2} = 8 / 3 = 2.6666666
                    for (int j = 1; j <= MAX; j++)
                    {
                        double value = integration4.Next();
                        Console.WriteLine("waarde = " + value);
                    }
                    /*
waarde = 2,8284271247461903
waarde = 2,7043013344342497
waarde = 2,674658650557856
waarde = 2,668288356869977
waarde = 2,6669880584827617
                    */
                    Console.WriteLine();
                }
                #endregion

                #region voorbeeld 5
                {
                    IntegrationMidpoint7oct2023 integration5 = new IntegrationMidpoint7oct2023(new Sinus7oct2023(), 0.0, Math.PI);
                    Console.WriteLine("Voorbeeld 5: Integraal van 0 tot pi van sin(x) dmv midpoint regel (is gelijk aan 2).");
                    // https://nl.wikipedia.org/wiki/Integraalrekening
                    // integraal van 0 tot pi van sin(x) is gelijk aan 2                    
                    for (int j = 1; j <= MAX; j++)
                    {
                        double value = integration5.Next();
                        Console.WriteLine("waarde = " + value);
                    }
                    /*
waarde = 3,141592653589793
waarde = 2,0943951023931957
waarde = 2,01019011595042
waarde = 2,0011286583272607
waarde = 2,0001253624631214
                    */
                    Console.WriteLine();
                }
                #endregion

                #region voorbeeld 6
                {
                    IntegrationTrapezoidal7oct2023 integration6 = new IntegrationTrapezoidal7oct2023(new Sinus7oct2023(), 0.0, Math.PI);
                    Console.WriteLine("Voorbeeld 6: Integraal van 0 tot pi van sin(x) dmv trapezoidal regel (is gelijk aan 2).");
                    // https://nl.wikipedia.org/wiki/Integraalrekening
                    // integraal van 0 tot pi van sin(x) is gelijk aan 2                    
                    for (int j = 1; j <= MAX; j++)
                    {
                        double value = integration6.Next();
                        Console.WriteLine("waarde = " + value);
                    }
                    /*
waarde = 1,9236706937217898E-16
waarde = 1,5707963267948966
waarde = 1,8961188979370398
waarde = 1,974231601945551
waarde = 1,9935703437723395
                    */
                    Console.WriteLine();
                }
                #endregion

                Console.ReadLine();
            }
            #endregion
        }
    }
}