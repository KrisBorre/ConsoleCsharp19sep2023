using LibraryInterpolation13nov2023;

namespace ConsoleInterpolatie6dec2023
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij numerieke interpolatie!");

            #region Interpolation
            {
                #region example 1
                {
                    int n2 = 6;
                    Console.WriteLine("Example 1");
                    double[] xx = new double[n2];
                    double[] yy = new double[n2];

                    for (int i = 0; i < n2; i++)
                    {
                        xx[i] = i;
                        yy[i] = Math.Sin(xx[i] / 6.0) + xx[i] / 4.0;
                        Console.WriteLine("xx[" + i + "] = " + xx[i] + "   yy[" + i + "] = " + yy[i]); ;
                    }
                    Console.WriteLine("Interpolation Linear");
                    NumericalInterpolator6dec2023 interpolator1 = new NumericalInterpolator6dec2023(xx, yy);

                    for (int i = 0; i < n2 - 1; i++)
                    {
                        double x_interp = i + 0.5;
                        double y_interp = interpolator1.Interpolate(x_interp);
                        Console.WriteLine("x_interp = " + x_interp + "   y_interp = " + y_interp);
                    }
                    Console.WriteLine();
                    /*
xx[0] = 0   yy[0] = 0
xx[1] = 1   yy[1] = 0,415896132693415
xx[2] = 2   yy[2] = 0,8271946967961522
xx[3] = 3   yy[3] = 1,229425538604203
xx[4] = 4   yy[4] = 1,6183698030697369
xx[5] = 5   yy[5] = 1,990176853196037
Interpolation Linear
x_interp = 0,5   y_interp = 0,2079480663467075
x_interp = 1,5   y_interp = 0,6215454147447836
x_interp = 2,5   y_interp = 1,0283101177001777
x_interp = 3,5   y_interp = 1,42389767083697
x_interp = 4,5   y_interp = 1,8042733281328869
                    */
                }
                #endregion

                #region example 2
                {
                    int n2 = 6;
                    Console.WriteLine("Example 2");
                    double[] xx3 = new double[n2];
                    double[] yy3 = new double[n2];

                    for (int i = 0; i < n2; i++)
                    {
                        xx3[i] = i;
                        yy3[i] = Math.Sin(xx3[i] / 8.0) + xx3[i] / 6.0;
                        Console.WriteLine("xx3[" + i + "] = " + xx3[i] + "   yy3[" + i + "] = " + yy3[i]);
                    }
                    Console.WriteLine("Interpolation Linear");
                    NumericalInterpolator6dec2023 interpolator2 = new NumericalInterpolator6dec2023(xx3, yy3, Method.Linear);
                    for (int i = 0; i < n2 - 1; i++)
                    {
                        double x_interp3 = i + 0.5;
                        double y_interp3 = interpolator2.Interpolate(x_interp3);
                        Console.WriteLine("x_interp3 = " + x_interp3 + "   y_interp3 = " + y_interp3);
                    }
                    Console.WriteLine();
                    /*
xx3[0] = 0   yy3[0] = 0
xx3[1] = 1   yy3[1] = 0,29134140005189435
xx3[2] = 2   yy3[2] = 0,5807372925878562
xx3[3] = 3   yy3[3] = 0,8662725290860476
xx3[4] = 4   yy3[4] = 1,1460922052708695
xx3[5] = 5   yy3[5] = 1,4184306062737955
Interpolation Linear
x_interp3 = 0,5   y_interp3 = 0,14567070002594718
x_interp3 = 1,5   y_interp3 = 0,4360393463198753
x_interp3 = 2,5   y_interp3 = 0,7235049108369519
x_interp3 = 3,5   y_interp3 = 1,0061823671784587
x_interp3 = 4,5   y_interp3 = 1,2822614057723325
                    */
                }
                #endregion


                #region example 3
                {
                    int n4 = 10;
                    Console.WriteLine("Example 3");
                    double[] xx = new double[n4];
                    double[] yy = new double[n4];

                    for (int i = 0; i < n4; i++)
                    {
                        xx[i] = i;
                        yy[i] = Math.Sin(xx[i] / 6.0) + xx[i] / 4.0;
                        Console.WriteLine("xx[" + i + "] = " + xx[i] + "   yy[" + i + "] = " + yy[i]);
                    }
                    Console.WriteLine("Interpolation Linear");
                    NumericalInterpolator6dec2023 interpolator3 = new NumericalInterpolator6dec2023(xx, yy, Method.Linear);

                    for (int i = 0; i < n4 - 1; i++)
                    {
                        double x_interp = i + 0.5;
                        double y_interp = interpolator3.Interpolate(x_interp);
                        Console.WriteLine("x_interp = " + x_interp + "   y_interp = " + y_interp);
                    }
                    Console.WriteLine();
                    /*
xx[0] = 0   yy[0] = 0
xx[1] = 1   yy[1] = 0,415896132693415
xx[2] = 2   yy[2] = 0,8271946967961522
xx[3] = 3   yy[3] = 1,229425538604203
xx[4] = 4   yy[4] = 1,6183698030697369
xx[5] = 5   yy[5] = 1,990176853196037
xx[6] = 6   yy[6] = 2,3414709848078967
xx[7] = 7   yy[7] = 2,669444979253755
xx[8] = 8   yy[8] = 2,9719379013633125
xx[9] = 9   yy[9] = 3,2474949866040546
Interpolation Linear
x_interp = 0,5   y_interp = 0,2079480663467075
x_interp = 1,5   y_interp = 0,6215454147447836
x_interp = 2,5   y_interp = 1,0283101177001777
x_interp = 3,5   y_interp = 1,42389767083697
x_interp = 4,5   y_interp = 1,8042733281328869
x_interp = 5,5   y_interp = 2,165823919001967
x_interp = 6,5   y_interp = 2,505457982030826
x_interp = 7,5   y_interp = 2,8206914403085337
x_interp = 8,5   y_interp = 3,1097164439836833
                    */
                }
                #endregion


                #region example 4
                {
                    int n5 = 5;
                    Console.WriteLine("Example 4");
                    double[] xx5 = new double[n5];
                    double[] yy5 = new double[n5];

                    for (int i = 0; i < n5; i++)
                    {
                        xx5[i] = i + 1.0;
                        yy5[i] = Math.Sin(xx5[i] / 9.0) + xx5[i] / 3.0;
                        Console.WriteLine("xx5[" + i + "] = " + xx5[i] + "   yy5[" + i + "] = " + yy5[i]);
                    }

                    Console.WriteLine("Interpolation Linear");
                    NumericalInterpolator6dec2023 interpolator4 = new NumericalInterpolator6dec2023(xx5, yy5, Method.Linear);

                    for (int i = 0; i < n5 - 1; i++)
                    {
                        double x_interp5 = i + 1.5;
                        double y_interp5 = interpolator4.Interpolate(x_interp5);
                        Console.WriteLine("x_interp5 = " + x_interp5 + "   y_interp5 = " + y_interp5);
                    }
                    Console.WriteLine();
                    /*
xx5[0] = 1   yy5[0] = 0,44421596184328627
xx5[1] = 2   yy5[1] = 0,8870644101227889
xx5[2] = 3   yy5[2] = 1,3271946967961523
xx5[3] = 4   yy5[3] = 1,7632896968616887
xx5[4] = 5   yy5[4] = 2,1940820524385325
Interpolation Linear
x_interp5 = 1,5   y_interp5 = 0,6656401859830376
x_interp5 = 2,5   y_interp5 = 1,1071295534594707
x_interp5 = 3,5   y_interp5 = 1,5452421968289205
x_interp5 = 4,5   y_interp5 = 1,9786858746501106
                    */
                }
                #endregion


                #region example 5
                {
                    int n5 = 5;
                    Console.WriteLine("Example 5");
                    double[] xx5 = new double[n5];
                    double[] yy5 = new double[n5];

                    for (int i = 0; i < n5; i++)
                    {
                        xx5[i] = i + 1.0;
                        yy5[i] = Math.Sin(xx5[i] / 9.0) + xx5[i] / 3.0;
                        Console.WriteLine("xx5[" + i + "] = " + xx5[i] + "   yy5[" + i + "] = " + yy5[i]);
                    }

                    Console.WriteLine("Interpolation Poly");
                    NumericalInterpolator6dec2023 interpolator5 = new NumericalInterpolator6dec2023(xx5, yy5, Method.Poly, 4);

                    for (int i = 0; i < n5 - 1; i++)
                    {
                        double x_interp5 = i + 1.5;
                        double y_interp5 = interpolator5.Interpolate(x_interp5);
                        double? err = interpolator5.dy;
                        Console.WriteLine("x_interp5 = " + x_interp5 + "   y_interp5 = " + y_interp5 + "   err = " + err);
                    }
                    Console.WriteLine();
                    /*
xx5[0] = 1   yy5[0] = 0,44421596184328627
xx5[1] = 2   yy5[1] = 0,8870644101227889
xx5[2] = 3   yy5[2] = 1,3271946967961523
xx5[3] = 4   yy5[3] = 1,7632896968616887
xx5[4] = 5   yy5[4] = 2,1940820524385325
Interpolation Poly
x_interp5 = 1,5   y_interp5 = 0,6658976358711995   err = -8,232031260548694E-05
x_interp5 = 2,5   y_interp5 = 1,1075516439728437   err = 8,232031260548694E-05
x_interp5 = 3,5   y_interp5 = 1,545825817522453   err = 7,920986755409476E-05
x_interp5 = 4,5   y_interp5 = 1,9794279150787513   err = -0,0003960493377704738
                    */

                }
                #endregion


                #region example 6
                {
                    int n4 = 10;
                    Console.WriteLine("Example 6");
                    double[] xx = new double[n4];
                    double[] yy = new double[n4];

                    for (int i = 0; i < n4; i++)
                    {
                        xx[i] = i;
                        yy[i] = Math.Sin(xx[i] / 6.0) + xx[i] / 4.0;
                        Console.WriteLine("xx[" + i + "] = " + xx[i] + "   yy[" + i + "] = " + yy[i]);
                    }
                    Console.WriteLine("Interpolation Poly");
                    NumericalInterpolator6dec2023 interpolator6 = new NumericalInterpolator6dec2023(xx, yy, Method.Poly, 4);

                    for (int i = 0; i < n4 - 1; i++)
                    {
                        double x_interp = i + 0.5;
                        double y_interp = interpolator6.Interpolate(x_interp);
                        double? err = interpolator6.dy;
                        Console.WriteLine("x_interp = " + x_interp + "   y_interp = " + y_interp + "   err = " + err);
                    }
                    Console.WriteLine();
                    /*
xx[0] = 0   yy[0] = 0
xx[1] = 1   yy[1] = 0,415896132693415
xx[2] = 2   yy[2] = 0,8271946967961522
xx[3] = 3   yy[3] = 1,229425538604203
xx[4] = 4   yy[4] = 1,6183698030697369
xx[5] = 5   yy[5] = 1,990176853196037
xx[6] = 6   yy[6] = 2,3414709848078967
xx[7] = 7   yy[7] = 2,669444979253755
xx[8] = 8   yy[8] = 2,9719379013633125
xx[9] = 9   yy[9] = 3,2474949866040546
Interpolation Poly
x_interp = 0,5   y_interp = 0,2082433778140417   err = -0,00027938460650053326
x_interp = 1,5   y_interp = 0,622399495425119   err = 0,0002793846065005344
x_interp = 2,5   y_interp = 1,029707261427503   err = 0,00026367844048940867
x_interp = 3,5   y_interp = 1,4257991578170794   err = 0,00024066481229479547
x_interp = 4,5   y_interp = 1,8066264614362415   err = 0,00021098151095043371
x_interp = 5,5   y_interp = 2,168563484981995   err = 0,00017545116572255381
x_interp = 6,5   y_interp = 2,50850805762472   err = 0,00013505844814369616
x_interp = 7,5   y_interp = 2,8239674971338538   err = 9,09227832821824E-05
x_interp = 8,5   y_interp = 3,1131743463755677   err = -0,000454613916410912
                    */
                }
                #endregion

                #region example 7
                {
                    int n4 = 10;
                    Console.WriteLine("Example 7");
                    double[] xx = new double[n4];
                    double[] yy = new double[n4];

                    for (int i = 0; i < n4; i++)
                    {
                        xx[i] = i;
                        yy[i] = Math.Sin(xx[i] / 6.0) + xx[i] / 4.0;
                        Console.WriteLine("xx[" + i + "] = " + xx[i] + "   yy[" + i + "] = " + yy[i]);
                    }
                    Console.WriteLine("Interpolation Rat");
                    NumericalInterpolator6dec2023 interpolator7 = new NumericalInterpolator6dec2023(xx, yy, Method.Rat, 4);

                    for (int i = 0; i < n4 - 1; i++)
                    {
                        double x_interp = i + 0.5;
                        double y_interp = interpolator7.Interpolate(x_interp);
                        double? err = interpolator7.dy;
                        Console.WriteLine("x_interp = " + x_interp + "   y_interp = " + y_interp + "   err = " + err);
                    }
                    Console.WriteLine();
                    /*
xx[0] = 0   yy[0] = 0
xx[1] = 1   yy[1] = 0,415896132693415
xx[2] = 2   yy[2] = 0,8271946967961522
xx[3] = 3   yy[3] = 1,229425538604203
xx[4] = 4   yy[4] = 1,6183698030697369
xx[5] = 5   yy[5] = 1,990176853196037
xx[6] = 6   yy[6] = 2,3414709848078967
xx[7] = 7   yy[7] = 2,669444979253755
xx[8] = 8   yy[8] = 2,9719379013633125
xx[9] = 9   yy[9] = 3,2474949866040546
Interpolation Rat
x_interp = 0,5   y_interp = 0,20823480239748818   err = -0,0002927646376331125
x_interp = 1,5   y_interp = 0,622405403343097   err = 0,0002900705088966489
x_interp = 2,5   y_interp = 1,02971680962172   err = 0,00029207227085531375
x_interp = 3,5   y_interp = 1,425811899133178   err = 0,0002948942207804223
x_interp = 4,5   y_interp = 1,8066417720915322   err = 0,0002978693736713923
x_interp = 5,5   y_interp = 2,1685805702617107   err = 0,00030011863039320757
x_interp = 6,5   y_interp = 2,5085259637210804   err = 0,00030054558159483885
x_interp = 7,5   y_interp = 2,8239851314473583   err = 0,00029782876314199847
x_interp = 8,5   y_interp = 3,113145320936315   err = -0,0013939357180694132
                    */
                }
                #endregion

                #region example 8
                {
                    Console.WriteLine("Example 8");

                    int n6 = 7;
                    double[] xx12 = new double[n6];
                    double[] yy12 = new double[n6];

                    for (int i = 0; i < n6; i++)
                    {
                        xx12[i] = i;
                        yy12[i] = Math.Sin(xx12[i] / 7.0) + xx12[i] / 6.0;
                        Console.WriteLine("xx12[" + i + "] = " + xx12[i] + "   yy12[" + i + "] = " + yy12[i]);
                    }

                    Console.WriteLine("Interpolation Rat");
                    NumericalInterpolator6dec2023 interpolator8 = new NumericalInterpolator6dec2023(xx12, yy12, Method.Rat, 4);

                    for (int i = 0; i < n6 - 1; i++)
                    {
                        double x_interp = i + 0.5;
                        double y_interp = interpolator8.Interpolate(x_interp);
                        double? err = interpolator8.dy;
                        Console.WriteLine("x_interp = " + x_interp + "   y_interp = " + y_interp + "   err = " + err);
                    }

                    Console.WriteLine();
                    /*
xx12[0] = 0   yy12[0] = 0
xx12[1] = 1   yy12[1] = 0,3090383964589303
xx12[2] = 2   yy12[2] = 0,6151761854555433
xx12[3] = 3   yy12[3] = 0,915571854993052
xx12[4] = 4   yy12[4] = 1,2075008800254983
xx12[5] = 5   yy12[5] = 1,488411230511852
xx12[6] = 6   yy12[6] = 1,7559753651467322
Interpolation Rat
x_interp = 0,5   y_interp = 0,15469956790848582   err = -0,0001847766776853003
x_interp = 1,5   y_interp = 0,46265064222611507   err = 0,00018333366874559616
x_interp = 2,5   y_interp = 0,7662672742767231   err = 0,00018563383966562863
x_interp = 3,5   y_interp = 1,062761287711083   err = 0,00018912015975000316
x_interp = 4,5   y_interp = 1,349487626060757   err = 0,00019359784419698575
x_interp = 5,5   y_interp = 1,6239920562155732   err = -0,0009354739817765753
                    */
                }
                #endregion


                #region example 9
                {
                    int n4 = 10;
                    Console.WriteLine("Example 9 Spline");
                    // https://en.wikipedia.org/wiki/Spline_interpolation
                    double[] xx = new double[n4];
                    double[] yy = new double[n4];

                    for (int i = 0; i < n4; i++)
                    {
                        xx[i] = i;
                        yy[i] = Math.Sin(xx[i] / 6.0) + xx[i] / 4.0;
                        Console.WriteLine("xx[" + i + "] = " + xx[i] + "   yy[" + i + "] = " + yy[i]);
                    }
                    Console.WriteLine("Interpolation Spline");
                    NumericalInterpolator6dec2023 interpolator9 = new NumericalInterpolator6dec2023(xx, yy, Method.Spline);

                    for (int i = 0; i < n4 - 1; i++)
                    {
                        double x_interp = i + 0.5;
                        double y_interp = interpolator9.Interpolate(x_interp);
                        Console.WriteLine("x_interp = " + x_interp + "   y_interp = " + y_interp);
                    }
                    Console.WriteLine();
                    /*
xx[0] = 0   yy[0] = 0
xx[1] = 1   yy[1] = 0,415896132693415
xx[2] = 2   yy[2] = 0,8271946967961522
xx[3] = 3   yy[3] = 1,229425538604203
xx[4] = 4   yy[4] = 1,6183698030697369
xx[5] = 5   yy[5] = 1,990176853196037
xx[6] = 6   yy[6] = 2,3414709848078967
xx[7] = 7   yy[7] = 2,669444979253755
xx[8] = 8   yy[8] = 2,9719379013633125
xx[9] = 9   yy[9] = 3,2474949866040546
Interpolation Spline
x_interp = 0,5   y_interp = 0,20823670496982397
x_interp = 1,5   y_interp = 0,6224035870969384
x_interp = 2,5   y_interp = 1,0297132737504535
x_interp = 3,5   y_interp = 1,4258097366476634
x_interp = 4,5   y_interp = 1,8066308307204941
x_interp = 5,5   y_interp = 2,1686006426609725
x_interp = 6,5   y_interp = 2,508430980687362
x_interp = 7,5   y_interp = 2,8243231755867466
x_interp = 8,5   y_interp = 3,1118728451662143
                    */
                }
                #endregion


                #region example 10
                {
                    Console.WriteLine("Example 10 Spline");

                    int n6 = 7;
                    double[] xx12 = new double[n6];
                    double[] yy12 = new double[n6];

                    for (int i = 0; i < n6; i++)
                    {
                        xx12[i] = i;
                        yy12[i] = Math.Sin(xx12[i] / 7.0) + xx12[i] / 6.0;
                        Console.WriteLine("xx12[" + i + "] = " + xx12[i] + "   yy12[" + i + "] = " + yy12[i]);
                    }

                    Console.WriteLine("Interpolation Spline");
                    NumericalInterpolator6dec2023 interpolator10 = new NumericalInterpolator6dec2023(xx12, yy12, Method.Spline);

                    for (int i = 0; i < n6 - 1; i++)
                    {
                        double x_interp = i + 0.5;
                        double y_interp = interpolator10.Interpolate(x_interp);
                        Console.WriteLine("x_interp = " + x_interp + "   y_interp = " + y_interp);
                    }

                    Console.WriteLine();
                    /*
xx12[0] = 0   yy12[0] = 0
xx12[1] = 1   yy12[1] = 0,3090383964589303
xx12[2] = 2   yy12[2] = 0,6151761854555433
xx12[3] = 3   yy12[3] = 0,915571854993052
xx12[4] = 4   yy12[4] = 1,2075008800254983
xx12[5] = 5   yy12[5] = 1,488411230511852
xx12[6] = 6   yy12[6] = 1,7559753651467322
Interpolation Spline
x_interp = 0,5   y_interp = 0,15470234219829085
x_interp = 1,5   y_interp = 0,4626455868491286
x_interp = 2,5   y_interp = 0,7662787152834378
x_interp = 3,5   y_interp = 1,0627075778673853
x_interp = 4,5   y_interp = 1,3496735134212778
x_interp = 5,5   y_interp = 1,6232890887598588
                    */
                }
                #endregion


                Console.WriteLine("Kris Borremans");
                Console.ReadLine();
            }
            #endregion

        }
    }
}