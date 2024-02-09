namespace LibraryPhysicalUnits9feb2024.Test
{
    public class UnitTestLength9feb2024
    {
        [Fact]
        public void Test1()
        {
            ILength length = new LengthInMeter(5, 0);
            Assert.Equal(expected: 5, actual: length.GetInMeter());
        }

        [Fact]
        public void Test2()
        {
            LengthInCentimeter length = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length.GetInCentimeter());
        }

        [Fact]
        public void Test3()
        {
            LengthInCentimeter length = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length.GetInCentimeter());
            Assert.Equal(expected: 0.02, actual: length.GetInMeter());
        }

        [Fact]
        public void Test4()
        {
            ILength length = new LengthInMeter(5, 0);
            Assert.Equal(expected: 5, actual: length.GetInMeter());
            Assert.Equal(expected: 500, actual: length.GetInCentimeter());
        }

        [Fact]
        public void Test5()
        {
            ILength length = new LengthInMeter(5, 1);
            Assert.Equal(expected: 5, actual: length.GetInMeter(), tolerance: 1);
        }

        [Fact]
        public void Test6()
        {
            LengthInCentimeter length = new LengthInCentimeter(2, 0.1);
            Assert.Equal(expected: 2, actual: length.GetInCentimeter(), tolerance: 0.1);
        }

        [Fact]
        public void Test7()
        {
            ILength length = new LengthInMeter(5, 1);
            Assert.Equal(expected: 5, actual: length.GetInMeter(), tolerance: 1);
            Assert.Equal(expected: 500, actual: length.GetInCentimeter(), tolerance: 100);
        }

        [Fact]
        public void Test8()
        {
            ILength length1 = new LengthInMeter(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = LengthCalculation.Add(length1, length2);

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 1);
        }

        [Fact]
        public void Test9()
        {
            ILength length1 = new LengthInMeter(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = LengthCalculation.Add(length1, length2);

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test10()
        {
            ILength length1 = new LengthInCentimeter(5, 0);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            ILength length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = LengthCalculation.Add(length1, length2);

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test11()
        {
            ILength length1 = new LengthInMeter(5, 1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0.1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = LengthCalculation.Add(length1, length2);

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 150);
        }

        [Fact]
        public void Test12()
        {
            ILength length1 = new LengthInMeter(5, 0.1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = LengthCalculation.Add(length1, length2);

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.15);
        }

        [Fact]
        public void Test13()
        {
            ILength length1 = new LengthInCentimeter(5, 0.002);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            ILength length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = LengthCalculation.Add(length1, length2);

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.002);
        }

        [Fact]
        public void Test14()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 0);
            LengthInMeter result = lengthInMeter.MultiplyBy(20);
            Assert.Equal(expected: 100, actual: result.GetInMeter());
        }

        [Fact]
        public void Test15()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 0);
            LengthInMeter result = lengthInMeter * 20;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
        }

        [Fact]
        public void Test16()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 0);
            LengthInMeter result = 20 * lengthInMeter;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
        }

        [Fact]
        public void Test17()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 1);
            LengthInMeter result = lengthInMeter.MultiplyBy(20);
            Assert.Equal(expected: 100, actual: result.GetInMeter());
            Assert.Equal(expected: 20, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test18()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 1);
            LengthInMeter result = lengthInMeter * 20;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
            Assert.Equal(expected: 20, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test19()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 1);
            LengthInMeter result = 20 * lengthInMeter;
            Assert.Equal(expected: 100, actual: result.GetInMeter());
            Assert.Equal(expected: 20, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test20()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 0);
            LengthInMeter result = lengthInMeter.DivideBy(5);
            Assert.Equal(expected: 1, actual: result.GetInMeter());
        }

        [Fact]
        public void Test21()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 0);
            LengthInMeter result = lengthInMeter / 5;
            Assert.Equal(expected: 1, actual: result.GetInMeter());
        }

        [Fact]
        public void Test22()
        {
            //LengthInMeter lengthInMeter = new LengthInMeter(5, 0);
            // InvertedLengthInMeter result = 5 / lengthInMeter;
            //Assert.Equal(expected: 1, actual: result.GetInInvertedMeter());
        }

        [Fact]
        public void Test23()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 1);
            LengthInMeter result = lengthInMeter.DivideBy(5);
            Assert.Equal(expected: 1, actual: result.GetInMeter());
            Assert.Equal(expected: 0.2, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test24()
        {
            LengthInMeter lengthInMeter = new LengthInMeter(5, 1);
            LengthInMeter result = lengthInMeter / 5;
            Assert.Equal(expected: 1, actual: result.GetInMeter());
            Assert.Equal(expected: 0.2, actual: result.GetPrecisionInMeter());
        }

        [Fact]
        public void Test25()
        {
            LengthInMeter length1 = new LengthInMeter(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter totalLength = length1 + length2;

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 1);
        }

        [Fact]
        public void Test26()
        {
            LengthInMeter length1 = new LengthInMeter(5, 0);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            LengthInMeter totalLength = length1 + length2;

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test27()
        {
            LengthInCentimeter length1 = new LengthInCentimeter(5, 0);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = length1 + length2;

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.01);
        }

        [Fact]
        public void Test28()
        {
            LengthInMeter length1 = new LengthInMeter(5, 1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0.1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = length1 + length2;

            Assert.Equal(expected: 502, actual: totalLength.GetInCentimeter(), tolerance: 150);
        }


        [Fact]
        public void Test29()
        {
            LengthInMeter length1 = new LengthInMeter(5, 0.1);
            Assert.Equal(expected: 5, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 1);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = length1 + length2;

            Assert.Equal(expected: 5.02, actual: totalLength.GetInMeter(), tolerance: 0.15);
        }

        [Fact]
        public void Test30()
        {
            LengthInCentimeter length1 = new LengthInCentimeter(5, 0.002);
            Assert.Equal(expected: 0.05, actual: length1.GetInMeter());

            LengthInCentimeter length2 = new LengthInCentimeter(2, 0);
            Assert.Equal(expected: 2, actual: length2.GetInCentimeter());

            ILength totalLength = length1 + length2;

            Assert.Equal(expected: 0.07, actual: totalLength.GetInMeter(), tolerance: 0.002);
        }

        [Fact]
        public void Test31()
        {
            double x = 1;
            var lengthInMeter = new LengthInMeter(x, 0);
            var radius = HelperCircle.CalculateRadius(diameter: lengthInMeter);
            Assert.Equal(expected: 0.5, actual: radius.GetInMeter());

            var circumferenceOfCircle = HelperCircle.CalculateCircumference(diameter: lengthInMeter);
            Assert.Equal(expected: 3.141592653589793, actual: circumferenceOfCircle.GetInMeter(), tolerance: 0.00001);
        }

        [Fact]
        public void Test32()
        {
            double x = 0.35;
            var lengthInMeter = new LengthInMeter(x, 0);
            var radius = HelperCircle.CalculateRadius(diameter: lengthInMeter);
            Assert.Equal(expected: 0.175, actual: radius.GetInMeter());

            var circumferenceOfCircle = HelperCircle.CalculateCircumference(diameter: lengthInMeter);
            Assert.Equal(expected: 1.0995574287564276, actual: circumferenceOfCircle.GetInMeter(), tolerance: 0.00001);
        }
    }
}
