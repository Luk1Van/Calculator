using Calculator_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculation _calculation;

        public CalculatorController(ICalculation calculation)
        {
            _calculation = calculation;
        }

        [HttpPost]
        [ActionName("Addition")]
        public IActionResult Addition([FromBody] Numbers numbers) 
        {
            try
            {
                decimal result = _calculation.Add(numbers.Number2, numbers.Number1);
                return Ok(result.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        [HttpPost]
        [ActionName("Division")]
        public IActionResult Division([FromBody] Numbers numbers)
        {
            try
            {
                decimal result = _calculation.Divide(numbers.Number2, numbers.Number1);
                return Ok(result.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        [HttpPost]
        [ActionName("Multiplication")]
        public IActionResult Multiplication([FromBody] Numbers numbers)
        {
            try
            {
                decimal result = _calculation.Multiply(numbers.Number2, numbers.Number1);
                return Ok(result.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        [HttpPost]
        [ActionName("Substraction")]
        public IActionResult Substraction([FromBody] Numbers numbers)
        {
            try
            {
                decimal result = _calculation.Substract(numbers.Number2, numbers.Number1);
                return Ok(result.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

    }
}
