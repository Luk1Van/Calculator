using Calculator_Api;

namespace Calculator_Test
{
    public class Tests
    {
        private ICalculation _calculator_Api;
        [SetUp]
        public void Setup()
        {
            _calculator_Api = new Calculation();
        }

        [TestCase(2, 3.5, 5.5)]
        [TestCase(-2, 3.5, 1.5)]
        [TestCase(0, 70.8, 70.8)]
        [TestCase(10, 15, 25)]
        public void Add_Test_Compare_Expected(decimal first, decimal second, decimal expected)
        {
            var result = _calculator_Api.Add(first, second);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 2, 0.5)]
        [TestCase(-15, 3, -5)]
        [TestCase(18, 0.5, 36)]
        public void Divide_Test_Compare_Expected(decimal first, decimal second, decimal expected)
        {
            var result = _calculator_Api.Divide(first, second);
            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 2, 2)]
        [TestCase(0, 0.789, 0)]
        [TestCase(-25, 0.5, -12.5)]
        public void Multiply_Test_Compare_Expected(decimal first, decimal second, decimal expected)
        {
            var result = _calculator_Api.Multiply(first, second);
            Assert.AreEqual(expected, result);
        }

        [TestCase(5, 12, -7)]
        [TestCase(23.5, -32.3, 55.8)]
        [TestCase(37, 0.5, 36.5)]
        public void Substract_Test_Compare_Expected(decimal first, decimal second, decimal expected)
        {
            var result = _calculator_Api.Substract(first, second);
            Assert.AreEqual(expected, result);
        }

    }
}