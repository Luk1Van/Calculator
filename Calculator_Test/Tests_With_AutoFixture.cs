using AutoFixture;
using Calculator_Api;
using System.Runtime.ExceptionServices;

namespace Calculator_Test
{
    public class Tests_With_AutoFixture
    {
        private ICalculation _calculator_Api;
        private static Fixture _fixture = new Fixture();

        decimal first;
        decimal second;

        [SetUp]
        public void Setup()
        {
            _calculator_Api = new Calculation();
            first = _fixture.Create<decimal>();
            second = _fixture.Create<decimal>();
        }

        [Test]
        public void Add_Test_AutoFixture()
        {
            var result = _calculator_Api.Add(first, second);
            Assert.AreEqual(first + second, result);
        }

        [Test]
        public void Divivde_Test_AutoFixture()
        {
            var result = _calculator_Api.Divide(first, second);
            Assert.AreEqual(first / second, result);
        }

        [Test]
        public void Multiply_Test_AutoFixture()
        {
            var result = _calculator_Api.Multiply(first, second);
            Assert.AreEqual(first * second, result);
        }

        [Test]
        public void Substract_Test_AutoFixture()
        {
            var result = _calculator_Api.Substract(first, second);
            Assert.AreEqual(first - second, result);
        }
    }
}
