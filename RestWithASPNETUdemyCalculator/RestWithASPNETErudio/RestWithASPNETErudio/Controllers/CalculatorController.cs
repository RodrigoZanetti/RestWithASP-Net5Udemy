using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETErudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        // metodo soma 
        [HttpGet("sum/{firtNumber}/{secondNumber}")]
       
        public IActionResult Summer(String firtNumber , String secondNumber )
        {
            if( IsNumeric(firtNumber) && IsNumeric(secondNumber) )
            {
                var calc = ConvertToDecimal(firtNumber) + ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());

            }
            return BadRequest("Invalid Input");
        }
        // metodo subtracao 
        [HttpGet("sub/{firtNumber}/{secondNumber}")]
        public IActionResult Subtraction(String firtNumber, String secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var calc = ConvertToDecimal(firtNumber) - ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // metodo multiplicacao 
        [HttpGet("mul/{firtNumber}/{secondNumber}")]
        public IActionResult Multiplication(String firtNumber, String secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var calc = ConvertToDecimal(firtNumber) * ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // metodo multiplicacao 
        [HttpGet("div/{firtNumber}/{secondNumber}")]
        public IActionResult Division(String firtNumber, String secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var calc = ConvertToDecimal(firtNumber) / ConvertToDecimal(secondNumber);
                return Ok(calc.ToString());
            }

            return BadRequest("Invalid Input");
        }


        // metodo media 
        [HttpGet("mean/{firtNumber}/{secondNumber}")]

        public IActionResult Mean(String firtNumber, String secondNumber)
        {
            if (IsNumeric(firtNumber) && IsNumeric(secondNumber))
            {
                var calc = (ConvertToDecimal(firtNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(calc.ToString());

            }
            return BadRequest("Invalid Input");
        }

        // metodo raiz quadrada 
        [HttpGet("square-root/{firtNumber}")]

        public IActionResult SquareRoot(String firtNumber)
        {
            if (IsNumeric(firtNumber)  )
            {
                var calc = Math.Sqrt( (double)ConvertToDecimal(firtNumber) );
                return Ok(calc.ToString());

            }
            return BadRequest("Invalid Input");
        }


        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number)   ;
            return isNumber;

        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }


 



    }
}
