namespace Calculator_Api
{
    public class Calculation : ICalculation
    {
        public decimal Add(decimal a, decimal b)
        {
            decimal result = a + b;
            return result;
        }

        public decimal Divide(decimal a, decimal b)
        {
            decimal result = a / b;
            return result;
        }

        public decimal Multiply(decimal a, decimal b)
        {
            decimal result = a * b;
            return result;
        }

        public decimal Substract(decimal a, decimal b)
        {
            decimal result = a - b;
            return result;
        }
    }
}
