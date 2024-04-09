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
