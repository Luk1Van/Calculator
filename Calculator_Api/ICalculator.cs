namespace Calculator_Api
{
    public interface ICalculation
    {
        decimal Add(decimal a, decimal b);
        decimal Divide(decimal a, decimal b);
        decimal Substract(decimal a, decimal b);
        decimal Multiply(decimal a, decimal b);

    }
}
